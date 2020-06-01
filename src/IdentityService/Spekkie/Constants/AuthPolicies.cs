namespace Spekkie.Constants
{
    // Needs to be public so the view can access it
    public static class AuthPolicies
    {
        public const string SpekkieAccountViewAllPolicy = "SpekkieAccountViewAllPolicy";
        public const string SpekkieAccountRemovePolicy = "SpekkieAccountRemovePolicy";
        public const string SpekkieAccountClaimViewAllPolicy = "SpekkieAccountClaimViewAllPolicy";
        public const string SpekkieAccountClaimAddPolicy = "SpekkieAccountClaimAddPolicy";
        public const string SpekkieAccountClaimRemovePolicy = "SpekkieAccountClaimRemovePolicy";
        public const string SpekkieSettingsViewAllPolicy = "SpekkieSettingsViewAllPolicy";
        public const string SpekkieSettingsCanEnableDisableRegisterPolicy = "SpekkieSettingsCanEnableDisableRegisterPolicy";
    }
}