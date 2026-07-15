using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using MauiApp1.Models;

namespace MauiApp1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<Goal> Goals { get; }

        public MainViewModel()
        {
            Goals = new ObservableCollection<Goal> {
                new Goal()
                {
                    Name = "Exam",
                    Motivation = "There are no shortcuts to any place worth going.",
                    TargetDate = System.DateTime.Parse("July 30, 2025"),
                    Progress = 0.5,
                },
                new Goal()
                {
                    Name = "Fitness",
                    Motivation = "Strength does not come from what you can do. It comes from overcoming the things you once thought you couldn’t.",
                    TargetDate = System.DateTime.Parse("October 30, 2025"),
                    Progress = 0.2
                },
                new Goal()
                {
                    Name = "Learn Piano",
                    Motivation = "Practice makes progress.",
                    TargetDate = System.DateTime.Parse("December 01, 2025"),
                    Progress = 0.1
                },
                new Goal()
                {
                    Name = "Read 10 Books",
                    Motivation = "A reader lives a thousand lives before he/she dies.",
                    TargetDate = System.DateTime.Parse("December 31, 2025"),
                    Progress = 0.4
                },
                new Goal()
                {
                    Name = "Meditation Habit",
                    Motivation = "Peace comes from within. Do not seek it without.",
                    TargetDate = System.DateTime.Parse("September 10, 2025"),
                    Progress = 0.7
                }
            };
        }

        [RelayCommand]
        async Task GoToAddAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.NewGoalPage));
        }

        [RelayCommand]
        async Task GoToDetailAsync(Goal goal)
        {
            if (goal is null)
                return;

            await Shell.Current.GoToAsync(nameof(Views.DetailPage), true,
                new Dictionary<string, object>
                {
                    { "Goal", goal }
                });
        }
    }
}