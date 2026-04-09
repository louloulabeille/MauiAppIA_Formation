using MauiAppIA_Formation.Infrastructure.ModelConfiguration;
using MauiAppIA_Formation.Infrastructure.Options;
using MauiAppIA_Formation.Models;
using MauiAppIA_Formation.ViewModel;
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
        public MainPage(IOptions<ApiConfig> api, MainViewModel mainViewModel)
        {
            InitializeComponent();

            // - passe les valeurs de la configuration de l'api dans la page par injection dépendance 
            _api = api;
            mainViewModel.ApiConfig = _api;
            BindingContext = mainViewModel;

        }
        #endregion

        #region event handler clicled
       /* private async void OnSendClicked(object? sender, EventArgs e)
        {
            

        }*/
        #endregion
    }
}
