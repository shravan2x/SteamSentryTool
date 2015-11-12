using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SteamSentryTool
{
    public partial class MainForm : Form
    {
        public delegate string GetSaveLocation();
        public GetSaveLocation SaveDelegate;

        public MainForm()
        {
            InitializeComponent();

            SaveDelegate = new GetSaveLocation(GetSaveLocationMethod);
            UsernameBox.Select();
        }

        private void SelectorButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog selector = new OpenFileDialog();
            
            if (selector.ShowDialog() != DialogResult.OK)
                return;
            if (selector.SafeFileName.Contains(".") && !selector.SafeFileName.EndsWith(".ssfn") && !selector.SafeFileName.EndsWith(".bin") && !selector.SafeFileName.EndsWith(".sentry"))
                if (MessageBox.Show("This does not appear to be a sentry file. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
            
            SelectorBox.Text = selector.FileName;
            SelectorCancelButton.Enabled = true;
            AddButton.Text = "Add";
        }

        private void SelectorCancelButton_Click(object sender, EventArgs e)
        {
            SelectorBox.Text = "";
            SelectorCancelButton.Enabled = false;
            AddButton.Text = "Create";
        }

        private void UsernameBox_Click(object sender, EventArgs e)
        {
            UsernameBox.SelectionStart = 0;
            UsernameBox.SelectionLength = UsernameBox.Text.Length;
        }

        private void PasswordBox_Click(object sender, EventArgs e)
        {
            PasswordBox.SelectionStart = 0;
            PasswordBox.SelectionLength = PasswordBox.Text.Length;
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "")
            {
                MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (PasswordBox.Text == "")
            {
                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SelectorGrouper.Enabled = false;
            CredsGrouper.Enabled = false;
            WorkingBar.Style = ProgressBarStyle.Marquee;

            BackgroundWorker runner = new BackgroundWorker();
            runner.DoWork += RunChecker;
            runner.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender2, e2) =>
            {
                WorkingBar.Style = ProgressBarStyle.Blocks;
                CredsGrouper.Enabled = true;
                SelectorGrouper.Enabled = true;
            });
            runner.RunWorkerAsync();
        }

        private void RunChecker(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            EOperationType type = (SelectorBox.Text == "") ? EOperationType.CheckCreds : EOperationType.CheckSentry;
            SentryOperator sentryOperator = new SentryOperator(UsernameBox.Text, PasswordBox.Text, SelectorBox.Text, type, this);

            switch (sentryOperator.StartSteam())
            {
                case ECheckResult.Yes:
                    MessageBox.Show("Sentry is linked to account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case ECheckResult.No:
                    if (type == EOperationType.CheckCreds)
                        MessageBox.Show("Credentials are valid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sentry is not linked to account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case ECheckResult.CredsWrong:
                    MessageBox.Show("Credentials are wrong.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case ECheckResult.CannotCheck:
                    MessageBox.Show("Cannot check since Two-Factor authentication is enabled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case ECheckResult.SentryMissing:
                    MessageBox.Show("Sentry file is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ECheckResult.ConnectFailed:
                    MessageBox.Show("Could not connect to Steam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "")
            {
                MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (PasswordBox.Text == "")
            {
                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SelectorGrouper.Enabled = false;
            CredsGrouper.Enabled = false;
            WorkingBar.Style = ProgressBarStyle.Marquee;

            BackgroundWorker runner = new BackgroundWorker();
            runner.DoWork += RunAdder;
            runner.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender2, e2) =>
            {
                WorkingBar.Style = ProgressBarStyle.Blocks;
                CredsGrouper.Enabled = true;
                SelectorGrouper.Enabled = true;
            });
            runner.RunWorkerAsync();
        }

        private void RunAdder(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            EOperationType type = (SelectorBox.Text == "") ? EOperationType.CreateSentry : EOperationType.AddToSentry;
            SentryOperator sentryOperator = new SentryOperator(UsernameBox.Text, PasswordBox.Text, SelectorBox.Text, type, this);

            switch (sentryOperator.StartSteam())
            {
                case ECheckResult.Added:
                    if (type == EOperationType.CreateSentry)
                        MessageBox.Show("Sentry created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sentry added to account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case ECheckResult.Yes:
                    MessageBox.Show("Sentry is already linked to account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case ECheckResult.No:
                    MessageBox.Show("FATAL : ECheckResult.No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ECheckResult.CredsWrong:
                    MessageBox.Show("Credentials are wrong.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case ECheckResult.AuthCodeExpired:
                    MessageBox.Show("Auth code expired.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case ECheckResult.AuthCodeInvalid:
                    MessageBox.Show("Auth code invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case ECheckResult.TwoFactorMismatch:
                    MessageBox.Show("Two factor code invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case ECheckResult.SentryMissing:
                    MessageBox.Show("Sentry file is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ECheckResult.ConnectFailed:
                    MessageBox.Show("Could not connect to Steam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ECheckResult.Cancelled:
                    break;
            }
        }

        private string GetSaveLocationMethod()
        {
            SaveFileDialog saver = new SaveFileDialog();
            saver.ShowDialog();

            SelectorBox.Text = saver.FileName;
            SelectorCancelButton.Enabled = true;
            AddButton.Text = "Add";

            return saver.FileName;
        }
    }
}
