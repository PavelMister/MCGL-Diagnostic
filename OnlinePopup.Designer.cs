namespace MCGL_Diagnostic
{
    partial class OnlinePopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlinePopup));
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.garants = new System.Windows.Forms.TabPage();
            this.garantBrowser = new System.Windows.Forms.WebBrowser();
            this.helpers = new System.Windows.Forms.TabPage();
            this.helpersBrowser = new System.Windows.Forms.WebBrowser();
            this.profis = new System.Windows.Forms.TabPage();
            this.profisBrowser = new System.Windows.Forms.WebBrowser();
            this.allonline = new System.Windows.Forms.TabPage();
            this.allBrowser = new System.Windows.Forms.WebBrowser();
            this.tabControl5.SuspendLayout();
            this.garants.SuspendLayout();
            this.helpers.SuspendLayout();
            this.profis.SuspendLayout();
            this.allonline.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl5
            // 
            this.tabControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabControl5.Controls.Add(this.garants);
            this.tabControl5.Controls.Add(this.helpers);
            this.tabControl5.Controls.Add(this.profis);
            this.tabControl5.Controls.Add(this.allonline);
            this.tabControl5.Location = new System.Drawing.Point(0, 0);
            this.tabControl5.Multiline = true;
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.ShowToolTips = true;
            this.tabControl5.Size = new System.Drawing.Size(800, 450);
            this.tabControl5.TabIndex = 1;
            this.tabControl5.SelectedIndexChanged += new System.EventHandler(this.Tab1_SelectedIndexChanged);
            // 
            // garants
            // 
            this.garants.Controls.Add(this.garantBrowser);
            this.garants.Location = new System.Drawing.Point(4, 22);
            this.garants.Name = "garants";
            this.garants.Padding = new System.Windows.Forms.Padding(3);
            this.garants.Size = new System.Drawing.Size(792, 424);
            this.garants.TabIndex = 0;
            this.garants.Text = "Гаранты";
            this.garants.UseVisualStyleBackColor = true;
            // 
            // garantBrowser
            // 
            this.garantBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.garantBrowser.Location = new System.Drawing.Point(3, 3);
            this.garantBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.garantBrowser.Name = "garantBrowser";
            this.garantBrowser.Size = new System.Drawing.Size(786, 418);
            this.garantBrowser.TabIndex = 1;
            this.garantBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.GarantsBrowser_DocumentCompleted);
            // 
            // helpers
            // 
            this.helpers.Controls.Add(this.helpersBrowser);
            this.helpers.Location = new System.Drawing.Point(4, 22);
            this.helpers.Name = "helpers";
            this.helpers.Padding = new System.Windows.Forms.Padding(3);
            this.helpers.Size = new System.Drawing.Size(792, 424);
            this.helpers.TabIndex = 1;
            this.helpers.Text = "Хелперы";
            this.helpers.UseVisualStyleBackColor = true;
            // 
            // helpersBrowser
            // 
            this.helpersBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpersBrowser.Location = new System.Drawing.Point(3, 3);
            this.helpersBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.helpersBrowser.Name = "helpersBrowser";
            this.helpersBrowser.Size = new System.Drawing.Size(786, 418);
            this.helpersBrowser.TabIndex = 1;
            this.helpersBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.HelpersBrowser_DocumentCompleted);
            // 
            // profis
            // 
            this.profis.Controls.Add(this.profisBrowser);
            this.profis.Location = new System.Drawing.Point(4, 22);
            this.profis.Name = "profis";
            this.profis.Size = new System.Drawing.Size(792, 424);
            this.profis.TabIndex = 2;
            this.profis.Text = "Профис";
            this.profis.UseVisualStyleBackColor = true;
            // 
            // profisBrowser
            // 
            this.profisBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profisBrowser.Location = new System.Drawing.Point(0, 0);
            this.profisBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.profisBrowser.Name = "profisBrowser";
            this.profisBrowser.Size = new System.Drawing.Size(792, 424);
            this.profisBrowser.TabIndex = 1;
            this.profisBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.ProfisBrowser_DocumentCompleted);
            // 
            // allonline
            // 
            this.allonline.Controls.Add(this.allBrowser);
            this.allonline.Location = new System.Drawing.Point(4, 22);
            this.allonline.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.allonline.Name = "allonline";
            this.allonline.Size = new System.Drawing.Size(792, 424);
            this.allonline.TabIndex = 3;
            this.allonline.Text = "Все игроки онлайн";
            this.allonline.UseVisualStyleBackColor = true;
            // 
            // allBrowser
            // 
            this.allBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allBrowser.Location = new System.Drawing.Point(0, 0);
            this.allBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.allBrowser.Name = "allBrowser";
            this.allBrowser.Size = new System.Drawing.Size(792, 424);
            this.allBrowser.TabIndex = 1;
            this.allBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.AllBrowser_DocumentCompleted);
            // 
            // OnlinePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OnlinePopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Онлайн сообществ";
            this.Load += new System.EventHandler(this.OnlinePopup_Load);
            this.tabControl5.ResumeLayout(false);
            this.garants.ResumeLayout(false);
            this.helpers.ResumeLayout(false);
            this.profis.ResumeLayout(false);
            this.allonline.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage allonline;
        private System.Windows.Forms.TabPage garants;
        private System.Windows.Forms.WebBrowser garantBrowser;
        private System.Windows.Forms.TabPage helpers;
        private System.Windows.Forms.WebBrowser helpersBrowser;
        private System.Windows.Forms.TabPage profis;
        private System.Windows.Forms.WebBrowser profisBrowser;
        private System.Windows.Forms.WebBrowser allBrowser;
    }
}