using Microsoft.Identity.Client;
using RepayablClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepayablClient.Shared.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //public ICommand LoginCommand { get; set; }
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";
        private string _loginUser;

        public string LoginUser
        {
            get { return _loginUser; }
            set
            {
                _loginUser = value;
                RaisePropertyChanged();
            }
        }
        public LoginViewModel()
        {
            Title = "Login Page";
            LoginUser = "Attempt to Login";
            _ = LoginCommandExecutedAsync();
            //LoginCommand = new AsyncCommand(LoginCommandExecutedAsync);
        }

        private async Task LoginCommandExecutedAsync()
        {

            AuthenticationResult authResult = null;
            IEnumerable<IAccount> accounts = await App.publicClientApplication.GetAccountsAsync().ConfigureAwait(false);
            IAccount firstAccount = accounts.FirstOrDefault();
            try
            {
                authResult = await App.publicClientApplication.AcquireTokenSilent(Consts.Scopes, firstAccount)
                                                        .ExecuteAsync();
            }
            catch (MsalUiRequiredException ex)
            {
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");
                try
                {
                    authResult = await App.publicClientApplication.AcquireTokenInteractive(Consts.Scopes)
                       .ExecuteAsync();
                }
                catch (MsalException msalex)
                {
                    // await DisplayMessageAsync($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
                }
            }
            catch
            {
                //  await DisplayMessageAsync($"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}");
                return;
            }
            if (authResult != null)
            {
                var content = await GetHttpContentWithTokenAsync(graphAPIEndpoint,
                                                            authResult.AccessToken).ConfigureAwait(false);

                LoginUser = content;

            }
        }
        public async Task<string> GetHttpContentWithTokenAsync(string url, string token)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;
            try
            {
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
                // Add the token in Authorization header
                request.Headers.Authorization =
                  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}


