using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public partial class NewGoalViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string motivation;

        [ObservableProperty]
        private System.DateTime targetDate = System.DateTime.Now.AddMonths(1);

        [ObservableProperty]
        private string category;

        [RelayCommand]
        async Task SaveAsync()
        {
            // Here you would normally save the goal to a database or pass it back to the MainViewModel.
            // For now, we will simply navigate back exactly as instructed in the workshop.
            await Shell.Current.GoToAsync("..");
        }
    }
}