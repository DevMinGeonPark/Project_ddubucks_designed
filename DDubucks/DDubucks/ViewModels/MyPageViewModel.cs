using Prism.Navigation;
using DDubucks.Models;

namespace DDubucks.ViewModels
{
    public class MyPageViewModel : ViewModelBase
    {
        public MyPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "MyPage";
        }
    }
}
