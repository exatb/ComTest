using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Xml.Serialization;
using UsefulClasses;

namespace ComTest
{
    public partial class ComForm : Form
    {
        public ComForm()
        {
            InitializeComponent();
        }

        // Обработчик события загрузки формы
        private void ComForm_Load(object sender, EventArgs e)
        {
            // Заполнение выпадающего списка доступными портами
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                foreach (string s in ports)
                    comboBoxSelectPort.Items.Add(s);
                comboBoxSelectPort.SelectedIndex = comboBoxSelectPort.Items.Count - 1; // Выбор последнего COM порта
            }

            // Установка стандартной скорости передачи
            comboBoxSelectBaundRate.SelectedIndex = 6;

            // Десериализация команд из XML и заполнение listBox
            FileStream fs = new FileStream(Useful.BaseDir() + "commands.xml", FileMode.Open);
            XmlSerializer xml = new XmlSerializer(typeof(List<string>));
            List<string> ls = (List<string>)xml.Deserialize(fs);
            if (ls != null && ls.Count != 0)
            {
                listBoxCmd.Items.Clear();
                foreach (string s in ls)
                    listBoxCmd.Items.Add(s);
            }
            fs.Close();
        }

        // Переменные для обработки данных
        string s1 = "";
        string s2 = "";
        bool finds_d = false;
        bool finds = false;
        bool showhex = true;
        bool disabled = true;

        // Обработчик события получения данных из последовательного порта
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (disabled) return;
            int read = serialPort1.BytesToRead;
            if (read == 0) return;

            byte[] buf = new byte[read];
            int readed = serialPort1.Read(buf, 0, read);
            s1 = "";

            for (int i = 0; i < readed; i++)
            {
                s1 += buf[i].ToString("X2") + " "; // Преобразование байтов в шестнадцатеричный формат
                if ((buf[i] != 0x0D) && (buf[i] != 0x0A))
                    s2 += Convert.ToChar(buf[i]);

                if (buf[i] == 0x0D) finds_d = true;

                if (buf[i] == 0x0A && finds_d)
                {
                    finds = true;
                    showhex = false;
                    Invoke(upd);
                    s2 = "";
                    finds = false;
                    showhex = true;
                }

                finds_d = false;
            }
            Invoke(upd);
        }

        // Делегат для обновления UI
        private delegate void upddel();
        upddel upd;
        const int MaxListBoxItems = 200;

        // Метод обновления listBox
        private void update()
        {
            if (showhex)
            {
                if (listBoxInputHEX.Items.Count >= MaxListBoxItems)
                    listBoxInputHEX.Items.Clear();

                listBoxInputHEX.Items.Add(s1);
                listBoxInputHEX.SelectedIndex = listBoxInputHEX.Items.Count - 1;
            }

            if (finds)
            {
                if (listBoxInputStr.Items.Count >= MaxListBoxItems)
                    listBoxInputStr.Items.Clear();

                listBoxInputStr.Items.Add(s2);
                listBoxInputStr.SelectedIndex = listBoxInputStr.Items.Count - 1;
                Useful.Log(s2);
            }
        }

        // Обработчик события нажатия кнопки открытия/закрытия последовательного порта
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                // Установка делегата обновления и активация элементов управления при открытии порта
                upd = update;
                comboBoxSelectPort.Enabled = false;
                comboBoxSelectBaundRate.Enabled = false;
                buttonSendHEX.Enabled = true;
                buttonSendStr.Enabled = true;
                buttonSendStrCRLF.Enabled = true;
                listBoxCmd.Enabled = true;
                buttonAddCmd.Enabled = true;
                buttonDelCmd.Enabled = true;
                buttonClear.Enabled = true;
                textBoxSend.Enabled = true;

                int baud = Convert.ToInt32((string)comboBoxSelectBaundRate.SelectedItem);
                string name = (string)comboBoxSelectPort.SelectedItem;

                serialPort1.PortName = name;
                serialPort1.BaudRate = baud;
                serialPort1.DtrEnable = checkBoxDTR.Checked;
                serialPort1.Open();
                disabled = false;
                buttonOpen.Text = "Close";
            }
            else
            {
                // Деактивация элементов управления и закрытие порта
                disabled = true;
                serialPort1.Close();
                comboBoxSelectPort.Enabled = true;
                comboBoxSelectBaundRate.Enabled = true;
                buttonSendHEX.Enabled = false;
                buttonSendStr.Enabled = false;
                buttonSendStrCRLF.Enabled = false;
                listBoxCmd.Enabled = false;
                buttonAddCmd.Enabled = false;
                buttonDelCmd.Enabled = false;
                buttonClear.Enabled = false;
                textBoxSend.Enabled = false;
                buttonOpen.Text = "Open";
            }
        }

        // Обработчик события закрытия формы для сохранения команд
        private void ComForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                disabled = true;
                serialPort1.Close();
            }

            // Сериализация команд в XML
            FileStream fs = new FileStream(Useful.BaseDir() + "commands.xml", FileMode.Create);
            XmlSerializer xml = new XmlSerializer(typeof(List<string>));
            List<string> ls = new List<string>();

            for (int i = 0; i < listBoxCmd.Items.Count; i++)
                ls.Add(listBoxCmd.Items[i].ToString());

            xml.Serialize(fs, ls);
            fs.Close();
        }

        // Кнопка отправки команды в формате HEX
        private void buttonSendHEX_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) return;

            string s = textBoxSend.Text;
            string t = "";
            byte[] buf = new byte[(s.Length + 1) / 3];
            bool find = false;
            int cnt = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    t += s[i];
                    find = false;
                }
                else find = true;

                if (i == s.Length - 1)
                    find = true;

                if (find)
                {
                    try
                    {
                        buf[cnt++] = Convert.ToByte(t, 16);
                    }
                    catch (Exception ex)
                    {
                        Useful.Log("Ошибка преобразования: " + ex.Message);
                    }

                    t = "";
                }
            }

            if (cnt > 0)
                serialPort1.Write(buf, 0, cnt);
        }

        // Кнопка отправки строки без CRLF
        private void buttonSendStr_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) return;

            string s = textBoxSend.Text;
            int sz = s.Length;
            byte[] buf = new byte[sz];

            for (int i = 0; i < s.Length; i++)
                buf[i] = (byte)s[i];

            if (sz > 0)
                serialPort1.Write(buf, 0, sz);
        }

        // Кнопка очистки обоих listBox
        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxInputHEX.Items.Clear();
            listBoxInputStr.Items.Clear();
        }

        // Кнопка отправки строки с CRLF
        private void buttonSendStrCRLF_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) return;

            string s = textBoxSend.Text + "\r\n";
            int sz = s.Length;
            byte[] buf = new byte[sz];

            for (int i = 0; i < s.Length; i++)
                buf[i] = (byte)s[i];

            if (sz > 0)
                serialPort1.Write(buf, 0, sz);
        }

        // Обработчик выбора команды в listBox
        private void listBoxCmd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) return;

            string s = (string)listBoxCmd.SelectedItem;
            if (s != "^Z")
            {
                textBoxSend.Text = s;
                s += "\r\n";
                int sz = s.Length;
                byte[] buf = new byte[sz];

                for (int i = 0; i < s.Length; i++)
                    buf[i] = (byte)s[i];

                if (sz > 0)
                    serialPort1.Write(buf, 0, sz);
            }
            else
            {
                byte[] buf = new byte[1];
                buf[0] = 0x1A;
                serialPort1.Write(buf, 0, 1);
            }
        }

        // Обработчик события нажатия клавиши в текстовом поле для отправки строки по Enter
        private void textBoxSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)(e.KeyChar)) == 13)
            {
                if (!serialPort1.IsOpen) return;

                string s = textBoxSend.Text + "\r\n";
                int sz = s.Length;
                byte[] buf = new byte[sz];

                for (int i = 0; i < s.Length; i++)
                    buf[i] = (byte)s[i];

                if (sz > 0)
                    serialPort1.Write(buf, 0, sz);
            }
        }

        // Обработчик изменения состояния флажка DTR
        private void checkBoxDTR_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.DtrEnable = checkBoxDTR.Checked;
        }

        // Кнопка добавления команды в список
        private void buttonAddCmd_Click(object sender, EventArgs e)
        {
            if (textBoxSend.Text != "")
                listBoxCmd.Items.Add(textBoxSend.Text);
        }

        // Кнопка удаления выбранной команды из списка
        private void buttonDelCmd_Click(object sender, EventArgs e)
        {
            int n = listBoxCmd.SelectedIndex;

            if (n == -1) return;

            listBoxCmd.Items.RemoveAt(n);
        }
    }
}
