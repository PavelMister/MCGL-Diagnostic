namespace MCGL_Diagnostic
{
    partial class MCGLForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        /// 


        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCGLForm));
            this.buttonGetAutoPath = new System.Windows.Forms.Button();
            this.inputPath = new System.Windows.Forms.TextBox();
            this.folderDiaglog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.getFolderPath = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.networkTest = new System.Windows.Forms.TabPage();
            this.testConnectionRep = new System.Windows.Forms.Button();
            this.crash = new System.Windows.Forms.TabPage();
            this.buttonCrashPlugin = new System.Windows.Forms.Button();
            this.gameProblems = new System.Windows.Forms.TabPage();
            this.ButtonReadLog = new System.Windows.Forms.Button();
            this.buttonCheckLog = new System.Windows.Forms.Button();
            this.buttonNoSound = new System.Windows.Forms.Button();
            this.settingClient = new System.Windows.Forms.TabPage();
            this.buttonClearConfig = new System.Windows.Forms.Button();
            this.buttonClearCache = new System.Windows.Forms.Button();
            this.buttonSetJavaOpts = new System.Windows.Forms.Button();
            this.clearJavaOpt = new System.Windows.Forms.Button();
            this.buttonChangeRam = new System.Windows.Forms.Button();
            this.otherTab = new System.Windows.Forms.TabPage();
            this.ButtonLoginWithoutLauncher = new System.Windows.Forms.Button();
            this.onlinePopularGroups = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.networkTest.SuspendLayout();
            this.crash.SuspendLayout();
            this.gameProblems.SuspendLayout();
            this.settingClient.SuspendLayout();
            this.otherTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetAutoPath
            // 
            resources.ApplyResources(this.buttonGetAutoPath, "buttonGetAutoPath");
            this.buttonGetAutoPath.Name = "buttonGetAutoPath";
            this.buttonGetAutoPath.UseVisualStyleBackColor = true;
            this.buttonGetAutoPath.Click += new System.EventHandler(this.ButtonGetAutoPath_Click);
            // 
            // inputPath
            // 
            resources.ApplyResources(this.inputPath, "inputPath");
            this.inputPath.Name = "inputPath";
            this.inputPath.ReadOnly = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // getFolderPath
            // 
            resources.ApplyResources(this.getFolderPath, "getFolderPath");
            this.getFolderPath.Name = "getFolderPath";
            this.getFolderPath.UseVisualStyleBackColor = true;
            this.getFolderPath.Click += new System.EventHandler(this.GetFolderPath_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.networkTest);
            this.tabControl1.Controls.Add(this.crash);
            this.tabControl1.Controls.Add(this.gameProblems);
            this.tabControl1.Controls.Add(this.settingClient);
            this.tabControl1.Controls.Add(this.otherTab);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // networkTest
            // 
            this.networkTest.Controls.Add(this.testConnectionRep);
            resources.ApplyResources(this.networkTest, "networkTest");
            this.networkTest.Name = "networkTest";
            this.networkTest.UseVisualStyleBackColor = true;
            // 
            // testConnectionRep
            // 
            this.testConnectionRep.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.testConnectionRep, "testConnectionRep");
            this.testConnectionRep.Name = "testConnectionRep";
            this.testConnectionRep.UseVisualStyleBackColor = false;
            this.testConnectionRep.Click += new System.EventHandler(this.TestConnectionRep_Click);
            // 
            // crash
            // 
            this.crash.Controls.Add(this.buttonCrashPlugin);
            resources.ApplyResources(this.crash, "crash");
            this.crash.Name = "crash";
            this.crash.UseVisualStyleBackColor = true;
            // 
            // buttonCrashPlugin
            // 
            this.buttonCrashPlugin.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonCrashPlugin, "buttonCrashPlugin");
            this.buttonCrashPlugin.Name = "buttonCrashPlugin";
            this.buttonCrashPlugin.UseVisualStyleBackColor = false;
            this.buttonCrashPlugin.Click += new System.EventHandler(this.ButtonCrashPlugin_Click);
            // 
            // gameProblems
            // 
            this.gameProblems.Controls.Add(this.ButtonReadLog);
            this.gameProblems.Controls.Add(this.buttonCheckLog);
            this.gameProblems.Controls.Add(this.buttonNoSound);
            resources.ApplyResources(this.gameProblems, "gameProblems");
            this.gameProblems.Name = "gameProblems";
            this.gameProblems.UseVisualStyleBackColor = true;
            // 
            // ButtonReadLog
            // 
            this.ButtonReadLog.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.ButtonReadLog, "ButtonReadLog");
            this.ButtonReadLog.Name = "ButtonReadLog";
            this.ButtonReadLog.UseVisualStyleBackColor = false;
            this.ButtonReadLog.Click += new System.EventHandler(this.ButtonReadLog_Click);
            // 
            // buttonCheckLog
            // 
            this.buttonCheckLog.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonCheckLog, "buttonCheckLog");
            this.buttonCheckLog.Name = "buttonCheckLog";
            this.buttonCheckLog.UseVisualStyleBackColor = false;
            this.buttonCheckLog.Click += new System.EventHandler(this.ButtonCheckLog_Click);
            // 
            // buttonNoSound
            // 
            this.buttonNoSound.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonNoSound, "buttonNoSound");
            this.buttonNoSound.Name = "buttonNoSound";
            this.buttonNoSound.UseVisualStyleBackColor = false;
            this.buttonNoSound.Click += new System.EventHandler(this.ButtonNoSound_Click);
            // 
            // settingClient
            // 
            this.settingClient.Controls.Add(this.buttonClearConfig);
            this.settingClient.Controls.Add(this.buttonClearCache);
            this.settingClient.Controls.Add(this.buttonSetJavaOpts);
            this.settingClient.Controls.Add(this.clearJavaOpt);
            this.settingClient.Controls.Add(this.buttonChangeRam);
            resources.ApplyResources(this.settingClient, "settingClient");
            this.settingClient.Name = "settingClient";
            this.settingClient.UseVisualStyleBackColor = true;
            // 
            // buttonClearConfig
            // 
            this.buttonClearConfig.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonClearConfig, "buttonClearConfig");
            this.buttonClearConfig.Name = "buttonClearConfig";
            this.buttonClearConfig.UseVisualStyleBackColor = false;
            this.buttonClearConfig.Click += new System.EventHandler(this.ButtonClearConfig_Click);
            // 
            // buttonClearCache
            // 
            this.buttonClearCache.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonClearCache, "buttonClearCache");
            this.buttonClearCache.Name = "buttonClearCache";
            this.buttonClearCache.UseVisualStyleBackColor = false;
            this.buttonClearCache.Click += new System.EventHandler(this.ButtonClearCache_Click);
            // 
            // buttonSetJavaOpts
            // 
            this.buttonSetJavaOpts.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonSetJavaOpts, "buttonSetJavaOpts");
            this.buttonSetJavaOpts.Name = "buttonSetJavaOpts";
            this.buttonSetJavaOpts.UseVisualStyleBackColor = false;
            this.buttonSetJavaOpts.Click += new System.EventHandler(this.ButtonSetJavaOpts_Click);
            // 
            // clearJavaOpt
            // 
            this.clearJavaOpt.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.clearJavaOpt, "clearJavaOpt");
            this.clearJavaOpt.Name = "clearJavaOpt";
            this.clearJavaOpt.UseVisualStyleBackColor = false;
            this.clearJavaOpt.Click += new System.EventHandler(this.ClearJavaOpt_Click);
            // 
            // buttonChangeRam
            // 
            this.buttonChangeRam.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonChangeRam, "buttonChangeRam");
            this.buttonChangeRam.Name = "buttonChangeRam";
            this.buttonChangeRam.UseVisualStyleBackColor = false;
            this.buttonChangeRam.Click += new System.EventHandler(this.ButtonChangeRam_Click);
            // 
            // otherTab
            // 
            this.otherTab.Controls.Add(this.ButtonLoginWithoutLauncher);
            this.otherTab.Controls.Add(this.onlinePopularGroups);
            resources.ApplyResources(this.otherTab, "otherTab");
            this.otherTab.Name = "otherTab";
            this.otherTab.UseVisualStyleBackColor = true;
            // 
            // ButtonLoginWithoutLauncher
            // 
            this.ButtonLoginWithoutLauncher.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.ButtonLoginWithoutLauncher, "ButtonLoginWithoutLauncher");
            this.ButtonLoginWithoutLauncher.Name = "ButtonLoginWithoutLauncher";
            this.ButtonLoginWithoutLauncher.UseVisualStyleBackColor = false;
            this.ButtonLoginWithoutLauncher.Click += new System.EventHandler(this.ButtonLoginWithoutLauncher_Click);
            // 
            // onlinePopularGroups
            // 
            this.onlinePopularGroups.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.onlinePopularGroups, "onlinePopularGroups");
            this.onlinePopularGroups.Name = "onlinePopularGroups";
            this.onlinePopularGroups.UseVisualStyleBackColor = false;
            this.onlinePopularGroups.Click += new System.EventHandler(this.ButtonGetOnlineDialog_Click);
            // 
            // resultTextBox
            // 
            resources.ApplyResources(this.resultTextBox, "resultTextBox");
            this.resultTextBox.BackColor = System.Drawing.Color.Black;
            this.resultTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.resultTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.resultTextBox.Name = "resultTextBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LabelVersion);
            this.panel1.Controls.Add(this.buttonGetAutoPath);
            this.panel1.Controls.Add(this.inputPath);
            this.panel1.Controls.Add(this.getFolderPath);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // LabelVersion
            // 
            resources.ApplyResources(this.LabelVersion, "LabelVersion");
            this.LabelVersion.Name = "LabelVersion";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.label1);
            this.panel2.Name = "panel2";
            // 
            // MCGLForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "MCGLForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.networkTest.ResumeLayout(false);
            this.crash.ResumeLayout(false);
            this.gameProblems.ResumeLayout(false);
            this.settingClient.ResumeLayout(false);
            this.otherTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonGetAutoPath;
        public System.Windows.Forms.TextBox inputPath;
        public System.Windows.Forms.FolderBrowserDialog folderDiaglog;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button getFolderPath;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage networkTest;
        public System.Windows.Forms.Button testConnectionRep;
        public System.Windows.Forms.TabPage crash;
        public System.Windows.Forms.RichTextBox resultTextBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonCrashPlugin;
        public System.Windows.Forms.TabPage gameProblems;
        public System.Windows.Forms.Button buttonNoSound;
        public System.Windows.Forms.TabPage settingClient;
        public System.Windows.Forms.Button clearJavaOpt;
        public System.Windows.Forms.Button buttonChangeRam;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button buttonSetJavaOpts;
        public System.Windows.Forms.Button buttonClearCache;
        public System.Windows.Forms.Button buttonClearConfig;
        private System.Windows.Forms.TabPage otherTab;
        public System.Windows.Forms.Button onlinePopularGroups;
        public System.Windows.Forms.Button buttonCheckLog;
        public System.Windows.Forms.Button ButtonReadLog;
        private System.Windows.Forms.Label LabelVersion;
        public System.Windows.Forms.Button ButtonLoginWithoutLauncher;
    }
}

