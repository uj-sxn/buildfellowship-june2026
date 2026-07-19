using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class NewGoalPage : ContentPage
    {
        public NewGoalPage(NewGoalViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is NewGoalViewModel vm)
            {
                vm.OnAppearing();
            }
        }
    }
}