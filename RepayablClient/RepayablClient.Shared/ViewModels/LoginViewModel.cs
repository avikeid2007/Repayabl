using AsyncCommands;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using RepayablClient.Shared.Models;
using RepayablClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace RepayablClient.Shared.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; set; }
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";
        private string _loginUser;
        private bool _isBusy;
        private Member _currentUser;
        private Visibility _isSignUp1Visible;
        private Visibility _isSignUp2Visible;
        private Visibility _isBusyVisible;
        public LoginViewModel()
        {
            Title = "Login Page";
            LoginUser = "Attempt to Login";
            //_ = CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => await LoginCommandExecutedAsync());
            //_ = LoginCommandExecutedAsync();
            LoginCommand = new AsyncCommand(LoginCommandExecutedAsync);
            IsSignUp1Visible = Visibility.Collapsed;
            IsBusyVisible = Visibility.Visible;
        }
        public Visibility IsSignUp1Visible
        {
            get { return _isSignUp1Visible; }
            set
            {
                _isSignUp1Visible = value;
                RaisePropertyChanged();
            }
        }
        public Visibility IsSignUp2Visible
        {
            get { return _isSignUp2Visible; }
            set
            {
                _isSignUp2Visible = value;
                RaisePropertyChanged();
            }
        }
        public Visibility IsBusyVisible
        {
            get { return _isBusyVisible; }
            set
            {
                _isBusyVisible = value;
                RaisePropertyChanged();
            }
        }
        public Member CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                RaisePropertyChanged();
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }
        public string LoginUser
        {
            get { return _loginUser; }
            set
            {
                _loginUser = value;
                RaisePropertyChanged();
            }
        }


        private async Task LoginCommandExecutedAsync()
        {
            IsBusy = true;
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
#if __ANDROID__
                   .WithParentActivityOrWindow(App.ParentWindow)
#endif 
                       .ExecuteAsync();
                }
                catch (MsalException msalex)
                {
                }
                catch (Exception exx)
                {
                }
            }
            catch
            {
                return;
            }
            if (authResult != null)
            {
                try
                {
                    LoginUser = "User" + authResult.Account.Username;
                    var content = await GetHttpContentWithTokenAsync(graphAPIEndpoint,
                                                                authResult.AccessToken).ConfigureAwait(false);
                    CurrentUser = JsonConvert.DeserializeObject<Member>(content);
                    IsBusyVisible = Visibility.Collapsed;
                    IsSignUp1Visible = Visibility.Visible;
                }
                catch (Exception ex)
                {

                }
            }
            IsBusy = false;
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
