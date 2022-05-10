using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Microsoft.VisualBasic;
using System.Linq;
using System.IO;

namespace MCGL_Diagnostic
{
    public partial class MCGLForm : Form
    {
        protected string mcglPath;
        public string decisionMessage;
        public static Library lib;
        public string version = "1.0.3";

        public MCGLForm()
        {
            InitializeComponent();
            _MCGLForm = this;
        }
        public static MCGLForm _MCGLForm;

        private void Form1_Load(object sender, EventArgs e)
        {
            lib = new Library();
            lib.CheckUpdate();
            this.LabelVersion.Text = "Версия: " + this.version + " by PavelStudio";
        }

        /// <summary>
        /// Injection form methods.
        /// </summary>
        public void ClearResult()
        {
            this.resultTextBox.Clear();
        }

        public void SetUnsetReadonlyResult()
        {
            this.resultTextBox.ReadOnly = resultTextBox.ReadOnly is true ? false : true;
        }

        public void UpdateResult(string message)
        {
            this.resultTextBox.AppendText(message);
        }

        /// <summary>
        /// Detect path local repository
        /// </summary>
        /// <returns>
        /// String Path to MCGL local repository
        /// </returns>
        private string GetPathToRepository()
        {
            string tempDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MCGL";
            string[] variants = new string[] { @"\MinecraftLauncher", @"\MinecraftLauncher1", @"\MinecraftLauncher2", @"\MinecraftLauncher3", @"\MinecraftLauncher4" };

            foreach(string pathVariant in variants)
            {
                if (System.IO.Directory.Exists(tempDataPath + pathVariant) && System.IO.Directory.Exists(tempDataPath + pathVariant + @"\log") && System.IO.Directory.Exists(tempDataPath + pathVariant + @"\repository"))
                    return tempDataPath + pathVariant;
            }
            
            return "";
        }


        //
        // Actions
        //

        private void GetFolderPath_Click(object sender, EventArgs e)
        {
            this.folderDiaglog.ShowDialog();
            this.mcglPath = this.folderDiaglog.SelectedPath;
           
            if (!System.IO.Directory.Exists(this.mcglPath + @"\log") && !System.IO.Directory.Exists(this.mcglPath + @"\repository"))
            {
                MessageBox.Show("Путь к репозиторию указан неверно!" + Environment.NewLine + @"По указанному пути должны присутствовать папки 'log' и 'repository'", "Ошибка выбранного пути", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.inputPath.Text = this.mcglPath;
        }
       
        public void GetMcglPath()
        {
            string path = this.GetPathToRepository();

            if (String.IsNullOrEmpty(path))
            {
                this.getFolderPath.Visible = true;
                MessageBox.Show("Не найден путь к репозиторию MCGL, укажите его вручную нажав кнопку 'Обзор'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.inputPath.Text = path;
            this.mcglPath = path;
        }

        private void ButtonGetAutoPath_Click(object sender, EventArgs e)
        {
            this.GetMcglPath();
        }

        private async void TestConnectionRep_Click(object sender, EventArgs e)
        {
            this.testConnectionRep.Enabled = false;
            
            this.ClearResult();

            MCGLForm._MCGLForm.UpdateResult("======= Тест запущен =======" + Environment.NewLine);
            int AvailableMcglUrls = await lib.SumPageSizesAsync();
            MCGLForm._MCGLForm.UpdateResult("======= Тест завершен ======" + Environment.NewLine);

            if (AvailableMcglUrls == 0)
            {
                await lib.GetDecision("ERR_CONN");
            }

            this.testConnectionRep.Enabled = true;
        }


        private void ButtonCrashPlugin_Click(object sender, EventArgs e)
        {
            this.GetMcglPath();
            
            if ( ! System.IO.Directory.Exists(this.mcglPath + @"\repository\mclient\plugins"))
            {
                MessageBox.Show("Ошибка" + Environment.NewLine + @"У Вас отстутствует папка 'plugins' в локальных файла, возможно у Вас ошибка в другом?", "Ошибка выбранного пути", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Нажмите 'Да' если желаете очистить папку с плагинами для исправления ошибки входа в игру", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    System.IO.Directory.Delete(this.mcglPath + @"\repository\mclient\plugins", true);
                    MessageBox.Show("Папка 'plugins' в локальном репозитории была успешно удалена!");
                } catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                    MessageBox.Show("Произошла непредвиденная ошибка при удалении папки 'plugins'!");
                }
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private async void ButtonNoSound_Click(object sender, EventArgs e)
        {
            await lib.GetDecision("ERR_NO_SOUND");
        }

        public static string ShowDialog(string text, string caption, string buttonTag = "Задать", string defaultText = "")
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 15, Text = text, Width = 500, Height = 30 };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Text = defaultText };
            Button confirmation = new Button() { Text = buttonTag, Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Отмена", Left = 250, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }



        public static string[] ShowDialogArgs(string text, string caption, string buttonTag = "Задать", string defaultText = "")
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 15, Text = text, Width = 500, Height = 30 };
            Label loginLabel = new Label() { Left = 25, Top = 52, Width = 45, Height = 15, Text = "Логин:" };
            Label passwordLabel = new Label() { Left = 25, Top = 82, Width = 45, Height = 15, Text = "Пароль:" };
            TextBox textBox = new TextBox() { Left = 70, Top = 50, Width = 250, Text = defaultText };
            TextBox textBox2 = new TextBox() { Left = 70, Top = 80, Width = 250, Text = defaultText };
            Button confirmation = new Button() { Text = buttonTag, Left = 350, Width = 100, Top = 120, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Отмена", Left = 250, Width = 100, Top = 120, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(loginLabel);
            prompt.Controls.Add(passwordLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(textBox2);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? new string[2] { textBox.Text, textBox2.Text } : new string[0] { };
        }

        public static string ShowDialogTextarea(string text, string caption, string buttonTag = "Задать")
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 350,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 15, Text = text, Width = 500, Height = 30 };
            RichTextBox textBox = new RichTextBox() { Left = 50, Top = 50, Width = 400, Height = 200 };
            Button confirmation = new Button() { Text = buttonTag, Left = 350, Width = 100, Top = 260, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Отмена", Left = 250, Width = 100, Top = 260, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void ButtonChangeRam_Click(object sender, EventArgs e)
        {
            string value = ShowDialog("Укажите количество выделяемой оперативной памяти для клиента\r\n--Пример: 2", "Значение в ГБ");

            if (String.IsNullOrEmpty(value))
            {
                return;
            }
            bool isNumber = int.TryParse(value, out int numericValue);

            if (!isNumber || numericValue > 32)
            {
                MessageBox.Show("Вы указали неверное значение ГБ, возможное значение от 1 до 32");
                return;
            }
        
            for (int i = 0; i < 100; i++)
            {
                string currentValue = (i - 1).ToString();
                string keyName = @"HKEY_CURRENT_USER\SOFTWARE\MCGL\MinecraftLauncher2\Profile" + currentValue;
                string valueName = "javaopts";
                string valueString = "-Xmx" + value + "G";
                Microsoft.Win32.Registry.SetValue(keyName, valueName, valueString, Microsoft.Win32.RegistryValueKind.String);
            }
        }

        private void ClearJavaOpt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                string currentValue = (i - 1).ToString();
                string keyName = @"SOFTWARE\MCGL\MinecraftLauncher2\Profile" + currentValue;
            
                try
                {
                    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, true))
                    {
                        if (key == null) { }
                        else
                        {
                            key.DeleteValue("javaopts");
                        }
                    }
                } 
                catch {}
            }
        }

        private void ButtonSetJavaOpts_Click(object sender, EventArgs e)
        {
            string value = ShowDialog("Задайте параметр javaopts, если вы не знаете что это такое, нажмите отмену!\r\n -- Пример параметра -Xmx2G -Xmx1024mb", "Изменение параметра javaopts");

            if (String.IsNullOrEmpty(value))
            {
                return;
            }
           
            for (int i = 0; i < 100; i++)
            {
                string currentValue = (i - 1).ToString();
                string keyName = @"HKEY_CURRENT_USER\SOFTWARE\MCGL\MinecraftLauncher2\Profile" + currentValue;
                string valueName = "javaopts";
                string valueString = value;
                Microsoft.Win32.Registry.SetValue(keyName, valueName, valueString, Microsoft.Win32.RegistryValueKind.String);
            }
        }

        private void ButtonClearCache_Click(object sender, EventArgs e)
        {
            this.GetMcglPath();

            if (!System.IO.Directory.Exists(this.mcglPath + @"\repository\mclient\cache") && !System.IO.Directory.Exists(this.mcglPath + @"\repository\mclient\mapcache"))
            {
                MessageBox.Show("Ошибка" + Environment.NewLine + @"Директории с кешем не обнаружено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Нажмите 'Да' если желаете удалить кеш клиента", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (System.IO.Directory.Exists(this.mcglPath + @"\repository\mclient\cache"))
                    {
                        System.IO.Directory.Delete(this.mcglPath + @"\repository\mclient\cache", true);
                    }
                    if (System.IO.Directory.Exists(this.mcglPath + @"\repository\mclient\mapcache"))
                    {
                        System.IO.Directory.Delete(this.mcglPath + @"\repository\mclient\mapcache", true);
                    }
                    MessageBox.Show("Директории 'cache' и 'mapcache' были успешно удалены!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                    MessageBox.Show("Произошла непредвиденная ошибка при удалении директорий 'cache' и 'mapcache'!");
                }
            } else if (result == DialogResult.No){}
        }

        private void ButtonClearConfig_Click(object sender, EventArgs e)
        {
            this.GetMcglPath();

            if (!System.IO.File.Exists(this.mcglPath + @"\repository\mclient\options.txt"))
            {
                MessageBox.Show("Ошибка" + Environment.NewLine + @"Файл с настройками не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Нажмите 'Да' если желаете удалить настройки клиента, профили не будут удалены!", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    System.IO.File.Delete(this.mcglPath + @"\repository\mclient\options.txt");
                    MessageBox.Show("Файл настроек 'options.txt' был успешно удален!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                    MessageBox.Show("Произошла непредвиденная ошибка при удалении файла 'options.txt'!");
                }
            } else if (result == DialogResult.No){}
        }

        private void ButtonGetOnlineDialog_Click(object sender, EventArgs e)
        {
            OnlinePopup popup = new OnlinePopup();
            DialogResult dialogresult = popup.ShowDialog();
        }

        private void ButtonCheckLog_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.mcglPath))
            {
                string path = this.GetPathToRepository();

                if (String.IsNullOrEmpty(path))
                {
                    this.getFolderPath.Visible = true;
                    MessageBox.Show("Не найден путь к репозиторию MCGL, укажите его вручную нажав кнопку 'Обзор'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.inputPath.Text = path;
                this.mcglPath = path;
            }

            MessageBox.Show(mcglPath + @"\log");
            var lastFileByName = System.IO.Directory
               .GetFiles(mcglPath + @"\log", "*.log")
               .Select(f =>
               {
                   var n = new System.IO.FileInfo(f);
                   long epochTicks = new DateTime(n.CreationTimeUtc.Year, n.CreationTimeUtc.Month, n.CreationTimeUtc.Day, n.CreationTimeUtc.Hour, n.CreationTimeUtc.Minute, 0).Ticks;
                   long unixTime = ((DateTime.UtcNow.Ticks - epochTicks) / TimeSpan.TicksPerSecond);

                   string unixTimestamp = unixTime.ToString();
                  
                   return !String.IsNullOrEmpty(unixTimestamp)
                       ? new { Date = unixTimestamp, FileName = f }
                       : null;
               })
               .Where(it => it != null)
               .OrderBy(it => it.Date)
               .First()?
               .FileName;

            MessageBox.Show(lastFileByName);
        }

        protected int GetLineByArray(string[] Lines, string word)
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains(word))
                {
                    return i;
                }
            }

            return 0;
        }

        private void ButtonReadLog_Click(object sender, EventArgs e)
        {
            string log = ShowDialogTextarea("Скопируйте в тектовое поле Ваш Лог\r\nЧто бы получить лог, нажмите \"Запуск с консолью\" в лаунчере", "Копирование лога", "Прочитать лог");
  
            string[] lines = log.Split(
                new string[] { "\n" },
                StringSplitOptions.None
            );
            int linesCount = lines.Length;

            if (String.IsNullOrEmpty(log))
            {
                return;
            }

            if (log.Contains("Error: Unable to access jarfile Minecraft.jar"))
            {
                if (String.IsNullOrEmpty(this.mcglPath))
                {
                    string path = this.GetPathToRepository();

                    if (String.IsNullOrEmpty(path))
                    {
                        this.getFolderPath.Visible = true;
                        MessageBox.Show("Не найден путь к репозиторию MCGL, укажите его вручную нажав кнопку 'Обзор'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    this.inputPath.Text = path;
                    this.mcglPath = path;
                }

                mcglPath = "";

                this.resultTextBox.Text = "Не найден файл клиента \"Minecraft.jar\" или у пользователя отстутствуют права на чтение этой директории!";
                return;
            }

            int found = GetLineByArray(lines, "Loading: net.java.games.input.DirectAndRawInputEnvironmentPlugin");
            if (found > 0 && found+3 > linesCount)
            {
                this.resultTextBox.Text = "Проблема с драйвером или его устройством, попробуйте отключить все внешние устройства и повторить попытку.\r\nПример устройства: Bluetooth адаптер или-же устройство подключенное с помощью Bluetooth.";
                return;
            }

            MessageBox.Show("К сожалению ошибка не была обнаружена в данном логе!");
        }



        private string GetJavaInstallationPath()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
           
            if (String.IsNullOrEmpty(environmentPath) || !environmentPath.Contains("jre"))
            {
                string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
                using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(javaKey))
                {
                    string currentVersion = rk.GetValue("CurrentVersion").ToString();
                    using (Microsoft.Win32.RegistryKey key = rk.OpenSubKey(currentVersion))
                    {
                        environmentPath = key.GetValue("JavaHome").ToString();
                    }
                }
            }

            if (String.IsNullOrEmpty(environmentPath) || !environmentPath.Contains("jre"))
            {
                string tempDataPath = lib.ProgramFilesx86();
                string[] variants = new string[] { @"\Project Galaxy", @"\Minecraft Galaxy", @"\MCGL" };

                string clientJavaPath = "";
                foreach (string pathVariant in variants)
                {
                    if (System.IO.Directory.Exists(tempDataPath + pathVariant) && System.IO.Directory.Exists(tempDataPath + pathVariant + @"\jreAMD64"))
                        clientJavaPath = tempDataPath + pathVariant;
                }

                if (Environment.Is64BitOperatingSystem && !String.IsNullOrEmpty(clientJavaPath))
                {
                    environmentPath = clientJavaPath + @"\jreAMD64";
                } else {
                    environmentPath = clientJavaPath + @"\jrex86";
                }
            }
            

            return environmentPath;
        }

        private void ButtonLoginWithoutLauncher_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(this.mcglPath))
            {
                string path = this.GetPathToRepository();

            
            
                if (String.IsNullOrEmpty(path))
                {
                    this.getFolderPath.Visible = true;
                    MessageBox.Show("Не найден путь к репозиторию MCGL, укажите его вручную нажав кнопку 'Обзор'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.inputPath.Text = path;
                this.mcglPath = path;
            }
            
            string javaPath = this.GetJavaInstallationPath();
            if (String.IsNullOrEmpty(javaPath))
            {
                MessageBox.Show("Путь к Java не найден, возможно JAVA была не установлена, или установлена некорректно!");
                return;
            }

            string[] values = ShowDialogArgs("Введенные данные не сохраняются и не передаются!", "Вход в клиент MCGL", "Вход");
            if (values.Length == 0 || values.Length == 2 && values[0].Length == 0 || values.Length == 2 && values[1].Length == 0)
            {
                return;
            }

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = javaPath + @"\bin\javaw.exe";
            p.StartInfo.WorkingDirectory = this.mcglPath + @"\repository\mclient\";
            p.StartInfo.Arguments = "-Xmx1024M -Xms512M -jar Minecraft.jar " + values[0] + " " + values[1];
            p.Start();
        }
    }
}
