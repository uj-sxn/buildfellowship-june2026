using MauiApp1.Views;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            Routing.RegisterRoute(nameof(NewGoalPage), typeof(NewGoalPage));
            Routing.RegisterRoute(nameof(Views.NewGoalPage), typeof(Views.NewGoalPage));
        }
    }
}
