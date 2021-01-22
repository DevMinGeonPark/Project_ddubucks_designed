using System.Threading.Tasks;
using DDubucks.Services.Authentication;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace DDubucks.ViewModels
{
    public class LottieAnimationPageViewModel : ViewModelBase
    {
        #region private member area
        private IAuthenticationService authenticationService;
        private DelegateCommand authenticationCheckCommand;
        #endregion

        public LottieAnimationPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            Title = "Animation Page";
            this.authenticationService = authenticationService;

        }

        #region Command Area
        public DelegateCommand AuthenticationCheckCommand =>
        authenticationCheckCommand ?? (authenticationCheckCommand =
                                      new DelegateCommand
                                        (
                                          async () =>
                                          {
                                              await Task.Delay(5000); //animation wait time
                                              //SNS로긴 정보가 있으면
                                              if (await authenticationService.UserIsAuthenticatedAndValidAsync()) 
                                              {
                                                  
                                                  var user = AppSettings.User;
                                                  var p = new NavigationParameters
                                                  {
                                                      { "user", user }
                                                  };
                                                  

                                                  await NavigationService.NavigateAsync("app:///TestPage", p);
                                                  //await NavigationService.NavigateAsync("NavigationPage/TestPage");
                                              }
                                              else//SNS로긴 정보가 없으면
                                              {
                                                  await NavigationService.NavigateAsync("app:///LoginPage");
                                              }
                                          }
                                         )
                                      );
        #endregion
    }
}