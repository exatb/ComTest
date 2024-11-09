//Набор полезных классов версия 021 (максимально сокращенная)

using System;
using System.Text;
using System.Windows.Forms;

namespace UsefulClasses
{
    /// <summary>
    /// Набор различных полезных функций
    /// </summary>
    static class Useful
    {
        /// <summary>
        /// Возвращает директорию запуска программы с "\" на конце, например c:\temp\
        /// </summary>
        /// <returns>Строка содержащая путь к директории запуска программы</returns>
        public static string BaseDir()
        {
            System.Reflection.Assembly ars = System.Reflection.Assembly.GetEntryAssembly();
            return System.IO.Path.GetDirectoryName(ars.Location) + "\\";
        }

        /// <summary>
        /// Возвращает имя исполняемого файла без расширения
        /// </summary>
        /// <returns>Имя исполняемого файла без расширения</returns>
        public static string ExeName()
        {
            System.Reflection.Assembly ars = System.Reflection.Assembly.GetEntryAssembly();
            return System.IO.Path.GetFileNameWithoutExtension(ars.Location);
        }

        private static Object LockFileObj = new Object();
        private const int MaxLogSize = int.MaxValue; // Максимальный размер лог файла

        /// <summary>
        /// Протоколирует строку s в файле имя_приложения.log в директории запуска программы.
        /// Если размер файла превысил MaxLogSize, то файл копируется в имя_приложения.~log
        /// и запись начинается с начала файла.
        /// </summary>
        /// <param name="s">Строка для записи в лог</param>
        /// <param name="error">Флаг ошибки. Если true, сообщение об ошибке дополнительно выдается пользователю</param>
        /// <param name="exit">Флаг выхода. Если true, прерывает работу программы с соответствующим исключением</param>
        public static void Log(string s, bool error, bool exit)
        {
            lock (LockFileObj) // Блокируем одновременную запись из разных потоков
            {
                string name = Useful.BaseDir() + Useful.ExeName() + ".log";
                System.IO.StreamWriter file = new System.IO.StreamWriter(name, true, Encoding.Default);
                DateTime dt = DateTime.Now;
                if ((error) || (exit))
                    file.WriteLine("Error! " + dt.ToString() + ": ms :" + dt.Millisecond + ": " + s);
                else
                    file.WriteLine(dt.ToString() + ": ms :" + dt.Millisecond + ": " + s);
                file.WriteLine(" ");
                file.Close();
                if (error)
                    System.Windows.Forms.MessageBox.Show(null, s, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                System.IO.FileInfo fi = new System.IO.FileInfo(name);
                if (fi.Length > MaxLogSize)
                {
                    string name_new = Useful.BaseDir() + Useful.ExeName() + ".~log";
                    System.IO.File.Copy(name, name_new, true);
                    System.IO.File.Delete(name);
                }
                if (exit)
                {
#if DEBUG
                    throw new System.Exception(s);
#else                    
                    System.Windows.Forms.Application.Exit();
#endif
                }
            }
        }

        /// <summary>
        /// Протоколирует строку s в файле имя_приложения.log в директории запуска программы.
        /// Если размер файла превысил MaxLogSize, то файл копируется в имя_приложения.~log
        /// и запись начинается с начала файла.
        /// </summary>
        /// <param name="s">Строка для записи в лог</param>
        public static void Log(string s)
        {
            Log(s, false, false);
        }
    }
}
