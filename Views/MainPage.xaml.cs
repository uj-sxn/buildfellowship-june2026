namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnGoalTapped(object? sender, TappedEventArgs e)
        {
            Console.WriteLine("navigate to its Detail Page");
        }

        private void OnAddNewGoalClicked(object? sender, EventArgs e)
        {
            Console.WriteLine("navigate to Add Item Page");
        }
    }
}
