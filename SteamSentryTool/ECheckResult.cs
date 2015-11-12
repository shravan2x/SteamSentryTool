namespace SteamSentryTool
{
    enum ECheckResult
    {
        ConnectFailed,
        SentryMissing,
        Yes,
        No,
        Added,
        CredsWrong,
        AuthCodeExpired,
        AuthCodeInvalid,
        TwoFactorMismatch,
        CannotCheck,
        Cancelled
    }
}
