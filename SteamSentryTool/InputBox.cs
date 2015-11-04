using System.Windows.Forms;

namespace SteamSentryTool
{
    static class InputBox
    {
        public static string AskAuth(string emailDomain)
        {
            AuthForm form = new AuthForm("Enter the auth code sent to the email at " + emailDomain);

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Dispose();
                return form.GetInput();
            }
            else
            {
                form.Dispose();
                return null;
            }
        }

        public static string AskTwoFactor()
        {
            AuthForm form = new AuthForm("Enter the 2 factor auth code from your authenticator app");

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Dispose();
                return form.GetInput();
            }
            else
            {
                form.Dispose();
                return null;
            }
        }
    }
}
