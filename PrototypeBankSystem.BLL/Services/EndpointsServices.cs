namespace PrototypeBankSystem.BLL.Services
{
    public static class EndpointsServices
    {
        public const string Api = "api";
        public const string Client = $"{Api}/clients";
        public const string Credit = $"{Api}/credit";
        public const string Deposit = $"{Api}/deposit";
        public const string ClientCard = $"{Api}/clientcards";
        public const string History = $"{Api}/history";
        public const string Login = $"{Api}/login";
    }
}
