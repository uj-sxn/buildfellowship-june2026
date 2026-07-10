using MauiApp1.ViewModels;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void OnGoalTapped(object? sender, TappedEventArgs e)
        {
            Console.WriteLine("navigate to its Detail Page");
        }
    }
}
