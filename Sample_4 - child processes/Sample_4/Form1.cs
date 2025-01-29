using System;
using System.Management;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Дочерним называется процесс, запущенный из другого процесса, который, в свою очередь, становиться
// для него родительским.

// Поскольку исполняемый код отдельных процессов не связан, то нет опасности, что ошибки 
// исполнения в одном процессе, приведут к закрытию другого, что
// вносит некоторую степень стабильности программного комплекса. 
//  исполнения в одном процессе, приведут к закрытию другого, что

// В операционной системе Windows предусмотрены способы межпроцессного взаимодействия:
// например, DDE (Dynamic Data Exchange – динамический обмен данными) или
// MMF (memory-mapped-files или файлы, проецируемые в память).
// DDE и MMF представляют собой программные интерфейсы, которые реализованы на Win32 API.
// К сожалению, нет "управляемого варианта" библиотек DDE Management Library и
// Memory-Mapped-Files Management, как, например, System.Management для WMI
// интерфейса. Поэтому, в любом случае, при использовании DDE-интерфейса или просто используя
// систему сообщений операционной системы, взаимодействие сводиться к вызову неуправляемых API функций
// (как привило использование SendMessage, в большинстве случаев, проще).

// Для того, чтобы использовать некоторую системную функцию (функцию Win32 API), её необходимо
// выгрузить в приложение. Одним из способов является использование атрибута DllImport при описании метода класса.

// Пример манипулирования дочерними процессами некоторого основного процесса
namespace Sample_4
{
    public partial class Form1 : Form
    {
        private const uint WM_SETTEXT = 0x0C; // индификатор сообщения WM_SETTEXT

        private List<Process> _childProcesses = new List<Process>();
        private int _counterChildProcesses = 0;
        private List<string> _exeFiles = new List<string>();

        // Через данный метод будем менять заголов у созданных окон
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, int wParam,
            [MarshalAs(UnmanagedType.LPStr)] string lParam);

        private delegate void ProcessDelegate(Process proc);

        public Form1()
        {
            InitializeComponent();
            LoadAvialableAssemblies(true);
        }

        #region === Private Methods ===
        /// <summary>
        /// Загружает доступыне сборки из домашней директории проекта
        /// </summary>
        private void LoadAvialableAssemblies(bool isView = false)
        {
            // Получить название сборки приложения 
            string fileNameForExcept = new FileInfo(Application.ExecutablePath).Name;
            fileNameForExcept = fileNameForExcept.Substring(0,
                fileNameForExcept.IndexOf("."));

            string[] exeFiles = Directory.GetFiles(Application.StartupPath, "*.exe");

            _exeFiles.Clear();
            foreach (string exeFile in exeFiles)
            {
                string fName = new FileInfo(exeFile).Name;

                if (fName.IndexOf(fileNameForExcept) == -1)
                {
                    _exeFiles.Add(exeFile);
                }
            }

            Logger("Данные загруженны!");

            if (isView)
                UpdateViewAvailableBuilds();
        }

        /// <summary>
        /// Запустить и сохранить процесс
        /// </summary>
        /// <param name="assamblyName"></param>
        private void RunProcess(string assamblyName)
        {
            Process proc = Process.Start(assamblyName);
            _childProcesses.Add(proc);

            if(Process.GetCurrentProcess().Id == GetParrentProcessId(proc.Id))
            {
                Logger($"Процесс: {proc.ProcessName} - является дочерним!");
            }

            proc.EnableRaisingEvents = true;
            proc.Exited += Proc_Exited;

            SetChildWindowText(proc.MainWindowHandle, $"Дочереный процесс №{++_counterChildProcesses}");
        }

        private int GetParrentProcessId(int id)
        {
            int parentID = -1;

            using (ManagementObject obj = new ManagementObject("win32_process.handle=" + id.ToString()))
            {
                obj.Get();
                parentID = Convert.ToInt32(obj["ParentProcessId"]);
            }

            return parentID;
        }

        private void SetChildWindowText(IntPtr mainWindowHandle, string text)
        {
            SendMessage(mainWindowHandle, WM_SETTEXT, 0, text);
        }

        private void UpdateViewAvailableBuilds()
        {
            textBox_AvailableBuilds.Text = "";
            comboBox_AvialableApps.Items.Clear();
            comboBox_AvialableApps.SelectedIndex = -1;

            foreach (var fname in _exeFiles)
            {
                string name = new FileInfo(fname).Name;

                comboBox_AvialableApps.Items.Add(name);
                textBox_AvailableBuilds.Text += name + "\r\n"; 
            }
        }

        private void UpdateViewRunProcesses(int pid_exclude = -1)
        {
            textBox_RunningProcesses.Text = ""; 
            comboBox_RunningApp.Items.Clear();
            comboBox_RunningApp.SelectedIndex = -1;

            foreach (var p in _childProcesses)
            {
                if(p.Id != pid_exclude)
                {
                    textBox_RunningProcesses.Text += $"{p.Id}: {p.ProcessName}" + "\r\n";
                    comboBox_RunningApp.Items.Add($"{p.Id}: {p.ProcessName}");
                }
            }
        }

        private void ExecuteOnProcessesByName(string ProcessName, ProcessDelegate func)
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);            

            foreach (var process in processes)
                if (Process.GetCurrentProcess().Id == GetParrentProcessId(process.Id))
                    func(process);
        }

        private void ExecuteOnProcessesByID(int PID, ProcessDelegate func)
        {
            Process proc = Process.GetProcessById(PID);

            if(proc != null)
            {
                func(proc);
            }
            else
            {
                Logger("ExecuteOnProcessesByID: proc is null!");
            }
        }

        private void Logger(string message, EViewPortLogger viewPort = EViewPortLogger.ToolStripLabel)
        {
            Logger(message, "Информация!", viewPort);
        }

        private void Logger(string message, string header, EViewPortLogger viewPort = EViewPortLogger.ToolStripLabel)
        {
            switch (viewPort)
            {
                case EViewPortLogger.ToolStripLabel:
                    toolStripLabel_Log.Text = message;
                    break;

                case EViewPortLogger.MessageBox:
                    MessageBox.Show(message, "Информация!");
                    break;
            }
        }
        #endregion

        #region === Funcs For Delegate ===
        private void Kill(Process proc)
        {
            proc.Kill();
        }

        private void CloseMainWindow(Process proc)
        {
            proc.CloseMainWindow();
        }

        private void Refresh(Process proc)
        {
            proc.Refresh();
        }
        #endregion

        #region === Event Handlers ===
        private void Proc_Exited(object sender, EventArgs e)
        {
            Process proc = (Process)sender;
            _childProcesses.Remove(proc);
            _counterChildProcesses--;

            proc.Exited -= Proc_Exited;

            int i = 0;
            foreach (var p in _childProcesses)
            {
                SetChildWindowText(p.MainWindowHandle, $"Дочереный процесс №{++i}");
            }

            // TODO:
            // Для вывода/обновления информации о запущенных процесса в текущем приложении,
            // после того как дочернее окно/процесс закрыт на крестик в самом окне, т.е. не 
            // через кнопку "Stop" или "Close Window", необходимо данному приложению/потоку
            // сообщиить об данном этом изменении. Для этого используются методы синхронизации 
            // данных между потоками. 
        }
        #endregion

        #region === UI Evenr Hendlers ===
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                foreach (var p in _childProcesses)
                {
                    p.CloseMainWindow();
                    p.Kill();
                }
            }
            catch(Exception ex)
            {
                Logger(ex.Message, "Вызвано исключение!", EViewPortLogger.MessageBox);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox_AvialableApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AvialableApps.SelectedIndex == -1)
                return;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            toolStripLabel_SelectedButton.Text = "Srart Btn";

            if (comboBox_AvialableApps.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите приложение для запуска!", "Внимание!");
                return;
            }

            try
            {
                RunProcess(comboBox_AvialableApps.SelectedItem.ToString());
                UpdateViewRunProcesses();
            }
            catch (Exception ex)
            {
                Logger(ex.Message, "Вызвано исключение!", EViewPortLogger.MessageBox);
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            toolStripLabel_SelectedButton.Text = "Stop Btn";

            if (comboBox_RunningApp.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите запущенное приложение!", "Внимание!");
                return;
            }

            try
            {
                //string name = comboBox_AvialableApps.SelectedItem.ToString().Split(':')[0];
                //ExecuteOnProcessesByName(name, Kill);

                int pid = _childProcesses[comboBox_RunningApp.SelectedIndex].Id;
                UpdateViewRunProcesses(pid);
                ExecuteOnProcessesByID(pid, Kill);
                // UpdateViewRunProcesses(); //- невесгда срабатывает. Proc_Exited?
            }
            catch (Exception ex)
            {
                Logger(ex.Message, "Вызвано исключение!", EViewPortLogger.MessageBox);
            }
        }

        private void button_CloseWindow_Click(object sender, EventArgs e)
        {
            toolStripLabel_SelectedButton.Text = "CloseWindow Btn";

            if (comboBox_RunningApp.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите запущенное приложение!", "Внимание!");
                return;
            }

            try
            {
                //string name = comboBox_AvialableApps.SelectedItem.ToString().Split(':')[0];
                //ExecuteOnProcessesByName(name, CloseMainWindow);

                int pid = _childProcesses[comboBox_RunningApp.SelectedIndex].Id;
                ExecuteOnProcessesByID(pid, CloseMainWindow);
                UpdateViewRunProcesses(); 
            }
            catch (Exception ex)
            {
                Logger(ex.Message, "Вызвано исключение!", EViewPortLogger.MessageBox);
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            toolStripLabel_SelectedButton.Text = "Refresh Btn";

            if (comboBox_RunningApp.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите запущенное приложение!", "Внимание!");
                return;
            }

            try
            {
                //string name = comboBox_AvialableApps.SelectedItem.ToString().Split(':')[0];
                //ExecuteOnProcessesByName(name, Refresh);

                int pid = _childProcesses[comboBox_RunningApp.SelectedIndex].Id;
                ExecuteOnProcessesByID(pid, Refresh);
            }
            catch (Exception ex)
            {
                Logger(ex.Message, "Вызвано исключение!", EViewPortLogger.MessageBox);
            }
        }

        private void button_RunApp_Click(object sender, EventArgs e)
        {
            toolStripLabel_SelectedButton.Text = "RunApp Btn";

            if (textBox_NameApp.Text == "")
            {
                MessageBox.Show("Выберите запущенное приложение!", "Внимание!");
                return;
            }

            try
            {
                string nameApp = textBox_NameApp.Text;
                RunProcess(nameApp);
                UpdateViewRunProcesses();
            }
            catch (Exception ex)
            {
                Logger(ex.Message, "Вызвано исключение!", EViewPortLogger.MessageBox);
            }
        }
        #endregion
    }

    #region === Utilities ===
    public enum EViewPortLogger
    {
        MessageBox,
        ToolStripLabel
    }
    #endregion
}
