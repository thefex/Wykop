namespace Wykop.ApiProvider.Common
{
    public static class WykopApiConfiguration
    {
        public static string ApiKey { get; private set; }
        public static string ApiSecret { get; private set; }
        public static string ApplicationName { get; private set; }
        public static uint ConnectionRetryCount { get; private set; }
        public static bool IsConnectionRetryEnabled { get; private set; }

        public static void SetApiKey(string apiKey)
        {
            ApiKey = apiKey;
        }

        public static void SetApiSecret(string apiSecret)
        {
            ApiSecret = apiSecret;
        }

        public static void SetApplicationName(string applicationName)
        {
            ApplicationName = applicationName;
        }

        public static void EnableRetryOnConnectionError(uint retryCount = 2)
        {
            ConnectionRetryCount = retryCount;
            IsConnectionRetryEnabled = true;
        }

        public static void DisableRetryOnConnectionError()
        {
            ConnectionRetryCount = 0;
            IsConnectionRetryEnabled = false;
        }

        public static bool IsConfigured()
        {
            return !string.IsNullOrEmpty(ApiKey) && !string.IsNullOrEmpty(ApiSecret) && !string.IsNullOrEmpty(ApplicationName);
        }
    }
}