using AKSoftware.WebApi.Client;

namespace project.Client.Services
{
    public class ServiceBase
    {
        public string BaseURL { get; set; }

        public ServiceClient Client { get; set; } = new ServiceClient();

        public string AccessToken
        {
            get => Client.AccessToken;
            set
            {
                Client.AccessToken = value;
            }
        }
    }
}