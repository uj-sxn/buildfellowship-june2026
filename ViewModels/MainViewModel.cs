using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using MauiApp1.Models;
using MauiApp1.DAL;
using MauiApp1.Views;

namespace MauiApp1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IGoalRepository _goalRepo;
        public ObservableCollection<Goal> Goals { get; }

        public MainViewModel(IGoalRepository goalRepo)
        {
            _goalRepo = goalRepo;
            Goals = new ObservableCollection<Goal>(); 
        
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

        // Workshop 5 - Task 8 : Access Functions
        [RelayCommand]
        async Task DeleteAsync(Goal goal)
        {
            if (goal == null)
                return;

            Debug.WriteLine($"Delete - {goal.Name}");
            await _goalRepo.DeleteItemAsync(goal);

            // Refresh the local list so the UI updates
            await GetGoalsAsync();
        }

        // Adding this helper method to refresh data from the repository
        [RelayCommand]
        public async Task GetGoalsAsync()
        {
            // Fetch the updated list from the SQLite database
            var items = await _goalRepo.GetItemsAsync();

            // Clear the old hardcoded/cached goals and load the new ones
            Goals.Clear();
            foreach (var item in items)
            {
                Goals.Add(item);
            }
        }

        [RelayCommand]
        async Task GoToEditAsync(Goal goal)
        {
            if (goal is null)
                return;
            await Shell.Current.GoToAsync($"{nameof(Views.NewGoalPage)}", true,
                new Dictionary<string, object>
                {
                  { "Goal", goal },
                });
        }

    }
}