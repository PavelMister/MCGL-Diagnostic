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
    public partial class Popup : Form
    {
        public Popup()
        {
            InitializeComponent();
        }

        private void Popup_Load(object sender, EventArgs e)
        {

        }
        
        public void SetMessage(string message)
        {
            if ( ! message.Contains('%'))
            {
                this.popupText.AppendText(message);
                this.popupText.ScrollToCaret();
                return;
            }
            string[] messages = message.Split('%');

            this.popupText.Clear();
            foreach (string line in messages)
            {
                if ( ! String.IsNullOrEmpty(this.popupText.Text))
                {
                    this.popupText.AppendText(Environment.NewLine);
                    this.popupText.ScrollToCaret();
                }
                this.popupText.AppendText(line);
                this.popupText.ScrollToCaret();
            }
        }

        private void PopupText_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
        

    }
}
