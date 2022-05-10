using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCGL_Diagnostic
{
    public partial class OnlinePopup : Form
    {
        public static Library lib;

        public IEnumerable<HtmlElement> LinkElements { get; private set; }

        public OnlinePopup()
        {
            InitializeComponent();
        }
        

        private void OnlinePopup_Load(object sender, EventArgs e)
        {
            lib = new Library();
            this.garantBrowser.DocumentText = lib.GetOnline(1);
        }

        private void GarantsBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            foreach (HtmlElement link in garantBrowser.Document.GetElementsByTagName("a")) link.Click += (s, args) => { System.Diagnostics.Process.Start(link.GetAttribute("href")); };
        }

        private void HelpersBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            foreach (HtmlElement link in garantBrowser.Document.GetElementsByTagName("a")) link.Click += (s, args) => { System.Diagnostics.Process.Start(link.GetAttribute("href")); };
        }

        private void ProfisBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            foreach (HtmlElement link in garantBrowser.Document.GetElementsByTagName("a")) link.Click += (s, args) => { System.Diagnostics.Process.Start(link.GetAttribute("href")); };
        }

        private void AllBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            foreach (HtmlElement link in garantBrowser.Document.GetElementsByTagName("a")) link.Click += (s, args) => { System.Diagnostics.Process.Start(link.GetAttribute("href")); };
        }



        private void Tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl5.SelectedTab == tabControl5.TabPages["garants"])
            {
                this.garantBrowser.DocumentText = lib.GetOnline(1);
            }
            else
            if (tabControl5.SelectedTab == tabControl5.TabPages["helpers"])
            {
                this.helpersBrowser.DocumentText = lib.GetOnline(2);
            }
            else
            if (tabControl5.SelectedTab == tabControl5.TabPages["profis"])
            {
                this.profisBrowser.DocumentText = lib.GetOnline(3);
            }
            else
            if (tabControl5.SelectedTab == tabControl5.TabPages["allonline"])
            {
                this.allBrowser.DocumentText = lib.GetOnline(999);
            } 
            else
            {
                this.garantBrowser.DocumentText = lib.GetOnline(1);
            }
        }
    }
}
