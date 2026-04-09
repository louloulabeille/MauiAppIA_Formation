using MauiAppIA_Formation.Infrastructure.ModelConfiguration;
using MauiAppIA_Formation.Infrastructure.Options;
using MauiAppIA_Formation.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MauiAppIA_Formation
{
    public partial class MainPage : ContentPage
    {
        #region private readonly properties
        private readonly IOptions<ApiConfig> _api;
        #endregion

        #region constructeur
        public MainPage(IOptions<ApiConfig> api)
        {
            InitializeComponent();

            // - passe les valeurs de la configuration de l'api dans la page par injection dépendance 
            _api = api;

        }
        #endregion

        #region event handler clicled
        private async void OnSendClicked(object? sender, EventArgs e)
        {
            HttpClient httpClient = new() { 
                BaseAddress = new Uri(_api.Value.BaseUrl!)
            };

            string token = _api.Value.Key ?? string.Empty;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            MistalAPIData data = new()
            {
                Agent_id = _api.Value.Agent_Id,
                Agent_Version = _api.Value.Agent_Version,
                Imputs = new List<Imput>()
                {
                    new Imput() { Role = "user", Content = "Hello, how are you?" }
                }
            };
            Console.WriteLine(JsonSerializer.Serialize(data).ToLower());
            HttpContent content = new StringContent(JsonSerializer.Serialize(data).ToLower(), Encoding.UTF8 , mediaType:"application/json");

            using var result = await httpClient.PostAsync(_api.Value.Url!,content);


            if (result.IsSuccessStatusCode)
            {
                var jsonResponse = await result.Content.ReadAsStringAsync();
                MessageResult? message= JsonSerializer.Deserialize<MessageResult>(jsonResponse, JsonOptions.GetJsonOptions());
                if(message is not null)
                {
                    ResponseLabel.Text = message.Message;
                }
            }
            else
            {
                Console.WriteLine($"{result.StatusCode}");
            }

        }
        #endregion
    }
}
