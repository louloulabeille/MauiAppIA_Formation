using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppIA_Formation.Infrastructure.ModelConfiguration;
using MauiAppIA_Formation.Infrastructure.Options;
using MauiAppIA_Formation.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MauiAppIA_Formation.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        #region public Properties
        public IOptions<ApiConfig>? ApiConfig { get; set; }
        #endregion

        #region Properties ObservableProperty
        [ObservableProperty]
        public partial string Question { get; set; }

        [ObservableProperty]
        public partial string Response { get; set; }
        #endregion

        #region method Relaycommand
        /// <summary>
        /// Envoie la question à l'API et récupère la réponse pour l'afficher dans la vue
        /// </summary>
        [RelayCommand]
        public async Task SendApiQuestion()
        {
            try
            {
                if (ApiConfig is null || string.IsNullOrEmpty(Question)) return;

                // - TODO : envoyer la question à l'api et récupérer la réponse
                HttpClient httpClient = new()
                {
                    BaseAddress = new Uri(ApiConfig.Value.BaseUrl!)
                };

                string token = ApiConfig.Value.Key ?? string.Empty;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                MistalAPIData data = new()
                {
                    Agent_id = ApiConfig.Value.Agent_Id,
                    Agent_Version = ApiConfig.Value.Agent_Version,
                    Inputs = [
                        new Input() { Role = "user", Content = Question }
                    ]
                };
                string jsonData = JsonSerializer.Serialize(data).ToLower();
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, mediaType: "application/json");

                using var result = await httpClient.PostAsync(ApiConfig.Value.Url!, content);

                if (result.IsSuccessStatusCode)
                {
                    var jsonResponse = await result.Content.ReadAsStringAsync();
                    MessageResult? message = JsonSerializer.Deserialize<MessageResult>(jsonResponse, JsonOptions.GetJsonOptions());
                    if (message is not null)
                    {
                        Response = message.Message ?? string.Empty;
                    }
                }
                else
                {
                    Response = $"Error: {result.StatusCode} \n {result.Content} \n {result.Headers} \n {result.ReasonPhrase}";
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
