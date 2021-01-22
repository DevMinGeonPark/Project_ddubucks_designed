using Prism.Navigation;
using DDubucks.Models;

namespace DDubucks.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Private Fields
        private User user;
        #endregion

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "DDubucks";
        }

        #region Property Area

        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }


        #endregion

        #region override method area
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("user"))
                User = (User)parameters["user"];
        }
        #endregion
    }
}
