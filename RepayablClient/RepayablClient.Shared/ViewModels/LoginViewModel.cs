using AsyncCommands;
using Microsoft.Identity.Client;
using RepayablClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RepayablClient.Shared.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; set; }
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";
        public LoginViewModel()
        {
            Title = "Login Page";
            LoginCommand = new AsyncCommand(LoginCommandExecutedAsync);
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
                // A MsalUiRequiredException happened on AcquireTokenSilent.
                // This indicates you need to call AcquireTokenInteractive to acquire a token
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

                // Go back to the UI thread to make changes to the UI
                //    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                //    {
                //        ResultText.Text = content;
                //        DisplayBasicTokenInfo(authResult);
                //        this.SignOutButton.Visibility = Visibility.Visible;
                //    });
                //}


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


