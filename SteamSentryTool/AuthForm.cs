using System;
using System.Windows.Forms;

namespace SteamSentryTool
{
    public partial class AuthForm : Form
    {
        public AuthForm(string text)
        {
            InitializeComponent();

            AuthLabel.Text = text;
        }

        public string GetInput()
        {
            return AuthcodeBox.Text;
        }

        private void AuthcodeBox_TextChanged(object sender, EventArgs e)
        {
            AuthcodeBox.Text = AuthcodeBox.Text.ToUpper();
            AuthcodeBox.SelectionStart = AuthcodeBox.Text.Length;
        }

        private void AuthLabel_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
