namespace ComTest
{
    partial class ComForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxSelectPort = new System.Windows.Forms.ComboBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.listBoxInputHEX = new System.Windows.Forms.ListBox();
            this.comboBoxSelectBaundRate = new System.Windows.Forms.ComboBox();
            this.labelPortSelect = new System.Windows.Forms.Label();
            this.labelBaundRate = new System.Windows.Forms.Label();
            this.labelInputStr = new System.Windows.Forms.Label();
            this.buttonSendHEX = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.listBoxInputStr = new System.Windows.Forms.ListBox();
            this.buttonSendStr = new System.Windows.Forms.Button();
            this.labelHEX = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSendStrCRLF = new System.Windows.Forms.Button();
            this.listBoxCmd = new System.Windows.Forms.ListBox();
            this.checkBoxDTR = new System.Windows.Forms.CheckBox();
            this.buttonAddCmd = new System.Windows.Forms.Button();
            this.buttonDelCmd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // comboBoxSelectPort
            // 
            this.comboBoxSelectPort.FormattingEnabled = true;
            this.comboBoxSelectPort.Location = new System.Drawing.Point(138, 31);
            this.comboBoxSelectPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSelectPort.Name = "comboBoxSelectPort";
            this.comboBoxSelectPort.Size = new System.Drawing.Size(131, 24);
            this.comboBoxSelectPort.TabIndex = 0;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(10, 13);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(109, 42);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // listBoxInputHEX
            // 
            this.listBoxInputHEX.FormattingEnabled = true;
            this.listBoxInputHEX.HorizontalScrollbar = true;
            this.listBoxInputHEX.ItemHeight = 16;
            this.listBoxInputHEX.Location = new System.Drawing.Point(10, 366);
            this.listBoxInputHEX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxInputHEX.Name = "listBoxInputHEX";
            this.listBoxInputHEX.Size = new System.Drawing.Size(539, 148);
            this.listBoxInputHEX.TabIndex = 2;
            // 
            // comboBoxSelectBaundRate
            // 
            this.comboBoxSelectBaundRate.FormattingEnabled = true;
            this.comboBoxSelectBaundRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxSelectBaundRate.Location = new System.Drawing.Point(293, 31);
            this.comboBoxSelectBaundRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSelectBaundRate.Name = "comboBoxSelectBaundRate";
            this.comboBoxSelectBaundRate.Size = new System.Drawing.Size(127, 24);
            this.comboBoxSelectBaundRate.TabIndex = 3;
            // 
            // labelPortSelect
            // 
            this.labelPortSelect.AutoSize = true;
            this.labelPortSelect.Location = new System.Drawing.Point(136, 10);
            this.labelPortSelect.Name = "labelPortSelect";
            this.labelPortSelect.Size = new System.Drawing.Size(31, 16);
            this.labelPortSelect.TabIndex = 4;
            this.labelPortSelect.Text = "Port";
            // 
            // labelBaundRate
            // 
            this.labelBaundRate.AutoSize = true;
            this.labelBaundRate.Location = new System.Drawing.Point(290, 10);
            this.labelBaundRate.Name = "labelBaundRate";
            this.labelBaundRate.Size = new System.Drawing.Size(46, 16);
            this.labelBaundRate.TabIndex = 5;
            this.labelBaundRate.Text = "Baund";
            // 
            // labelInputStr
            // 
            this.labelInputStr.AutoSize = true;
            this.labelInputStr.Location = new System.Drawing.Point(8, 158);
            this.labelInputStr.Name = "labelInputStr";
            this.labelInputStr.Size = new System.Drawing.Size(72, 16);
            this.labelInputStr.TabIndex = 6;
            this.labelInputStr.Text = "Input String";
            // 
            // buttonSendHEX
            // 
            this.buttonSendHEX.Enabled = false;
            this.buttonSendHEX.Location = new System.Drawing.Point(10, 109);
            this.buttonSendHEX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendHEX.Name = "buttonSendHEX";
            this.buttonSendHEX.Size = new System.Drawing.Size(225, 36);
            this.buttonSendHEX.TabIndex = 7;
            this.buttonSendHEX.Text = "Send as HEX string (55 0F C0...)";
            this.buttonSendHEX.UseVisualStyleBackColor = true;
            this.buttonSendHEX.Click += new System.EventHandler(this.buttonSendHEX_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Enabled = false;
            this.textBoxSend.Location = new System.Drawing.Point(10, 81);
            this.textBoxSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(410, 22);
            this.textBoxSend.TabIndex = 8;
            this.textBoxSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSend_KeyPress);
            // 
            // listBoxInputStr
            // 
            this.listBoxInputStr.FormattingEnabled = true;
            this.listBoxInputStr.HorizontalScrollbar = true;
            this.listBoxInputStr.ItemHeight = 16;
            this.listBoxInputStr.Location = new System.Drawing.Point(10, 178);
            this.listBoxInputStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxInputStr.Name = "listBoxInputStr";
            this.listBoxInputStr.Size = new System.Drawing.Size(539, 164);
            this.listBoxInputStr.TabIndex = 10;
            // 
            // buttonSendStr
            // 
            this.buttonSendStr.Enabled = false;
            this.buttonSendStr.Location = new System.Drawing.Point(242, 109);
            this.buttonSendStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendStr.Name = "buttonSendStr";
            this.buttonSendStr.Size = new System.Drawing.Size(115, 36);
            this.buttonSendStr.TabIndex = 11;
            this.buttonSendStr.Text = "Send as string";
            this.buttonSendStr.UseVisualStyleBackColor = true;
            this.buttonSendStr.Click += new System.EventHandler(this.buttonSendStr_Click);
            // 
            // labelHEX
            // 
            this.labelHEX.AutoSize = true;
            this.labelHEX.Location = new System.Drawing.Point(8, 346);
            this.labelHEX.Name = "labelHEX";
            this.labelHEX.Size = new System.Drawing.Size(65, 16);
            this.labelHEX.TabIndex = 12;
            this.labelHEX.Text = "Input HEX";
            // 
            // buttonClear
            // 
            this.buttonClear.Enabled = false;
            this.buttonClear.Location = new System.Drawing.Point(440, 13);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(109, 42);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSendStrCRLF
            // 
            this.buttonSendStrCRLF.Enabled = false;
            this.buttonSendStrCRLF.Location = new System.Drawing.Point(362, 109);
            this.buttonSendStrCRLF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendStrCRLF.Name = "buttonSendStrCRLF";
            this.buttonSendStrCRLF.Size = new System.Drawing.Size(188, 36);
            this.buttonSendStrCRLF.TabIndex = 14;
            this.buttonSendStrCRLF.Text = "Send as string + CR + LF";
            this.buttonSendStrCRLF.UseVisualStyleBackColor = true;
            this.buttonSendStrCRLF.Click += new System.EventHandler(this.buttonSendStrCRLF_Click);
            // 
            // listBoxCmd
            // 
            this.listBoxCmd.Enabled = false;
            this.listBoxCmd.FormattingEnabled = true;
            this.listBoxCmd.ItemHeight = 16;
            this.listBoxCmd.Location = new System.Drawing.Point(556, 14);
            this.listBoxCmd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxCmd.Name = "listBoxCmd";
            this.listBoxCmd.Size = new System.Drawing.Size(223, 500);
            this.listBoxCmd.TabIndex = 29;
            this.listBoxCmd.SelectedIndexChanged += new System.EventHandler(this.listBoxCmd_SelectedIndexChanged);
            // 
            // checkBoxDTR
            // 
            this.checkBoxDTR.AutoSize = true;
            this.checkBoxDTR.Location = new System.Drawing.Point(293, 60);
            this.checkBoxDTR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxDTR.Name = "checkBoxDTR";
            this.checkBoxDTR.Size = new System.Drawing.Size(58, 20);
            this.checkBoxDTR.TabIndex = 34;
            this.checkBoxDTR.Text = "DTR";
            this.checkBoxDTR.UseVisualStyleBackColor = true;
            this.checkBoxDTR.CheckedChanged += new System.EventHandler(this.checkBoxDTR_CheckedChanged);
            // 
            // buttonAddCmd
            // 
            this.buttonAddCmd.Enabled = false;
            this.buttonAddCmd.Location = new System.Drawing.Point(440, 81);
            this.buttonAddCmd.Name = "buttonAddCmd";
            this.buttonAddCmd.Size = new System.Drawing.Size(50, 23);
            this.buttonAddCmd.TabIndex = 35;
            this.buttonAddCmd.Text = "+";
            this.buttonAddCmd.UseVisualStyleBackColor = true;
            this.buttonAddCmd.Click += new System.EventHandler(this.buttonAddCmd_Click);
            // 
            // buttonDelCmd
            // 
            this.buttonDelCmd.Enabled = false;
            this.buttonDelCmd.Location = new System.Drawing.Point(499, 81);
            this.buttonDelCmd.Name = "buttonDelCmd";
            this.buttonDelCmd.Size = new System.Drawing.Size(50, 23);
            this.buttonDelCmd.TabIndex = 36;
            this.buttonDelCmd.Text = "-";
            this.buttonDelCmd.UseVisualStyleBackColor = true;
            this.buttonDelCmd.Click += new System.EventHandler(this.buttonDelCmd_Click);
            // 
            // ComForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 524);
            this.Controls.Add(this.buttonDelCmd);
            this.Controls.Add(this.buttonAddCmd);
            this.Controls.Add(this.checkBoxDTR);
            this.Controls.Add(this.listBoxCmd);
            this.Controls.Add(this.buttonSendStrCRLF);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labelHEX);
            this.Controls.Add(this.buttonSendStr);
            this.Controls.Add(this.listBoxInputStr);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.buttonSendHEX);
            this.Controls.Add(this.labelInputStr);
            this.Controls.Add(this.labelBaundRate);
            this.Controls.Add(this.labelPortSelect);
            this.Controls.Add(this.comboBoxSelectBaundRate);
            this.Controls.Add(this.listBoxInputHEX);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.comboBoxSelectPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ComForm";
            this.ShowIcon = false;
            this.Text = "ComTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComForm_FormClosing);
            this.Load += new System.EventHandler(this.ComForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBoxSelectPort;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.ListBox listBoxInputHEX;
        private System.Windows.Forms.ComboBox comboBoxSelectBaundRate;
        private System.Windows.Forms.Label labelPortSelect;
        private System.Windows.Forms.Label labelBaundRate;
        private System.Windows.Forms.Label labelInputStr;
        private System.Windows.Forms.Button buttonSendHEX;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.ListBox listBoxInputStr;
        private System.Windows.Forms.Button buttonSendStr;
        private System.Windows.Forms.Label labelHEX;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSendStrCRLF;
        private System.Windows.Forms.ListBox listBoxCmd;
        private System.Windows.Forms.CheckBox checkBoxDTR;
        private System.Windows.Forms.Button buttonAddCmd;
        private System.Windows.Forms.Button buttonDelCmd;
    }
}

