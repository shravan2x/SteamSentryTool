using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using SteamKit2;

namespace SteamSentryTool
{
    class SentryOperator
    {
        private SteamClient _steamClient;
        private CallbackManager _manager;

        private SteamUser _steamUser;

        private bool _isRunning;

        private readonly string _username, _password, _sentryLoc;
        private string _authCode, _twoFactorAuth;

        private readonly EOperationType _operation;
        private ECheckResult _checkResult;

        private readonly MainForm _mainForm;

        public SentryOperator(string username, string password, string sentryLoc, EOperationType operation, MainForm mainForm)
        {
            _username = username;
            _password = password;
            _sentryLoc = sentryLoc;
            _operation = operation;
            _mainForm = mainForm;
        }

        public ECheckResult StartSteam()
        {
            _steamClient = new SteamClient();
            _manager = new CallbackManager(_steamClient);
            _steamUser = _steamClient.GetHandler<SteamUser>();

            _manager.Subscribe<SteamClient.ConnectedCallback>(OnConnected);
            _manager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);
            _manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
            _manager.Subscribe<SteamUser.UpdateMachineAuthCallback>(OnMachineAuth);

            _isRunning = true;
            _steamClient.Connect();

            while (_isRunning)
                _manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));

            if (_operation == EOperationType.CreateSentry)
                Thread.Sleep(500);

            _steamClient.Disconnect();
            return _checkResult;
        }

        private void OnConnected(SteamClient.ConnectedCallback callback)
        {
            if (callback.Result != EResult.OK)
            {
                _checkResult = ECheckResult.ConnectFailed;
                _isRunning = false;
                return;
            }

            byte[] sentryHash = null;
            if (File.Exists(_sentryLoc))
            {
                byte[] sentryFile = File.ReadAllBytes(_sentryLoc);
                sentryHash = CryptoHelper.SHAHash(sentryFile);
            }
            else if (_operation == EOperationType.CheckSentry || _operation == EOperationType.AddToSentry)
            {
                _checkResult = ECheckResult.SentryMissing;
                _isRunning = false;
                return;
            }
            
            _steamUser.LogOn(new SteamUser.LogOnDetails
            {
                Username = _username,
                Password = _password,
                AuthCode = _authCode,
                TwoFactorCode = _twoFactorAuth,
                SentryFileHash = sentryHash,
            });
        }

        private void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            _steamClient.Connect();
        }

        private void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            bool isSteamGuard = callback.Result == EResult.AccountLogonDenied;
            bool is2FA = callback.Result == EResult.AccountLoginDeniedNeedTwoFactor;

            if (isSteamGuard || is2FA)
            {
                if (_operation == EOperationType.CheckCreds)
                {
                    _checkResult = ECheckResult.No;
                    _isRunning = false;
                    return;
                }

                if (_operation == EOperationType.CheckSentry)
                {
                    _checkResult = is2FA ? ECheckResult.CannotCheck : ECheckResult.No;
                    _isRunning = false;
                    return;
                }

                if (is2FA)
                {
                    _twoFactorAuth = InputBox.AskTwoFactor();

                    if (_twoFactorAuth != null)
                        return;
                }
                else
                {
                    _authCode = InputBox.AskAuth(callback.EmailDomain);

                    if (_authCode != null)
                        return;
                }

                _checkResult = ECheckResult.Cancelled;
                _isRunning = false;
                return;
            }

            if (callback.Result == EResult.ExpiredLoginAuthCode)
            {
                _checkResult = ECheckResult.AuthCodeExpired;
                _isRunning = false;
                return;
            }
            
            if (callback.Result == EResult.InvalidLoginAuthCode)
            {
                _checkResult = ECheckResult.AuthCodeInvalid;
                _isRunning = false;
                return;
            }

            if (callback.Result == EResult.TwoFactorCodeMismatch)
            {
                _checkResult = ECheckResult.TwoFactorMismatch;
                _isRunning = false;
                return;
            }
            
            if (callback.Result != EResult.OK)
            {
                _checkResult = ECheckResult.CredsWrong;
                _isRunning = false;
                return;
            }

            if (_operation != EOperationType.CreateSentry)
            {
                if (_operation == EOperationType.AddToSentry && (_authCode != null || _twoFactorAuth != null))
                    _checkResult = ECheckResult.Added;
                else
                    _checkResult = ECheckResult.Yes;

                _isRunning = false;
                return;
            }
        }

        private void OnMachineAuth(SteamUser.UpdateMachineAuthCallback callback)
        {
            string fileName = (string) _mainForm.Invoke(_mainForm.SaveDelegate);

            int fileSize;
            byte[] sentryHash;
            using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Seek(callback.Offset, SeekOrigin.Begin);
                fs.Write(callback.Data, 0, callback.BytesToWrite);
                fileSize = (int) fs.Length;

                fs.Seek(0, SeekOrigin.Begin);
                using (SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider())
                {
                    sentryHash = sha.ComputeHash(fs);
                }
            }

            // inform the steam servers that we're accepting this sentry file
            _steamUser.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
            {
                JobID = callback.JobID,

                FileName = callback.FileName,

                BytesWritten = callback.BytesToWrite,
                FileSize = fileSize,
                Offset = callback.Offset,

                Result = EResult.OK,
                LastError = 0,

                OneTimePassword = callback.OneTimePassword,

                SentryFileHash = sentryHash,
            });

            _checkResult = ECheckResult.Added;
            _isRunning = false;
        }
    }
}
