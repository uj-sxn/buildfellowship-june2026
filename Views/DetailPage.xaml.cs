using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(DetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}