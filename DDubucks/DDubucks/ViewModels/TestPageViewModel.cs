using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using DDubucks.Models;


namespace DDubucks.ViewModels
{
    public class TestPageViewModel : ViewModelBase
    {
        private User user;

        public TestPageViewModel(INavigationService navigationService)
        : base(navigationService)
        {
            Title = "TestPageVIewModel";
        }

        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("user"))
                User = (User)parameters["user"];
        }

    }
}
