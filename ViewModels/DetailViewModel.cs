using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Models;

namespace MauiApp1.ViewModels
{
    [QueryProperty(nameof(Goal), "Goal")]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Goal goal;
    }
}