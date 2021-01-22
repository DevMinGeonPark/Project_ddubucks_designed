using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;
using DDubucks.Models;
using DDubucks.Services.Authentication;

namespace DDubucks.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region private member area
        private IPageDialogService dialogService;
        private IAuthenticationService authenticationService;
        private DelegateCommand<SNSProvider?> snsSignInCommand;

        #endregion

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            Title = "Login Page";
            this.dialogService = dialogService;
            this.authenticationService = authenticationService;
            MessagingInit();
        }

        #region Command Area
        public DelegateCommand<SNSProvider?> SNSSignInCommand =>
                                    snsSignInCommand ?? (snsSignInCommand =
                                                         new DelegateCommand<SNSProvider?>
                                                             (
                                                                async (SNSProvider? snsProvider) =>
                                                                {
                                                                    IsBusy = true;
                                                                    try
                                                                    {
                                                                        if (snsProvider.HasValue)
                                                                        {
                                                                            await authenticationService.LoginWithSNSAsync(snsProvider.Value);
                                                                        }
                                                                    }
                                                                    catch (Exception ex) when (ex is WebException || ex is HttpRequestException)
                                                                    {
                                                                        await dialogService.DisplayAlertAsync("네트웍 에러 입니다.", "에러", "Ok");
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Debug.WriteLine($"Error in: {ex}");
                                                                    }
                                                                    finally
                                                                    {
                                                                        IsBusy = false;
                                                                    }
                                                                }
                                                            )
                                                        );
        #endregion

        #region Messaging Setting Area
        void MessagingInit()
        {
            MessagingCenter.Subscribe<User, bool>(this, MessengerKey.AuthenticationRequested, OnAuthenticationChanged);
        }

        private async void OnAuthenticationChanged(User user, bool isLogin)
        {
            if (isLogin)
            {
                NavigationParameters p = new NavigationParameters
                {
                    { "user", user }
                };

                await NavigationService.NavigateAsync("app:///TestPage", p);

                //await NavigationService.NavigateAsync("NavigationPage/MainPage", p);
            }
        }
        #endregion
    }

}