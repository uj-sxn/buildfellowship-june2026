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
    }
}