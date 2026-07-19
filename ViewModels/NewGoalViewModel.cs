using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.DAL;
using MauiApp1.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    // QueryProperty attribute to receive the goal item from MainViewModel
    [QueryProperty(nameof(Goal), "Goal")]
    public partial class NewGoalViewModel : ObservableObject
    {
        private readonly IGoalRepository _goalRepo;

        // Tracks whether we are editing an existing item or creating a new one
        
        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private string motivation = string.Empty;

        [ObservableProperty]
        private System.DateTime targetDate = System.DateTime.Now.AddMonths(1);

        [ObservableProperty]
        private string category = string.Empty;

        [ObservableProperty]
        private Goal _goal;

        [ObservableProperty]
        private string pageTitle = "New Goal";

        
        public NewGoalViewModel(IGoalRepository goalRepo)
        {
            _goalRepo = goalRepo;
        }

        public void OnAppearing()
        {
            if (Goal is not null)
            {
                PageTitle = "Edit Goal";
                Name = Goal.Name;
                Motivation = Goal.Motivation;
                Category = Goal.Category;

                TargetDate = Goal.TargetDate;
            }
        }

        [RelayCommand]
        async Task SaveAsync()
        {
            Goal goal;

            // If Goal is null, it's a brand new goal creation
            if (Goal is null)
            {
                goal = new Goal()
                {
                    Name = Name,
                    Motivation = Motivation,
                    Category = Category,
                    TargetDate = TargetDate,
                    StartDate = System.DateTime.Now
                };
            }
            // If Goal already exists, we are modifying its properties for an update
            else
            {
                goal = Goal;
                goal.Name = Name;
                goal.Motivation = Motivation;
                goal.Category = Category; 
                goal.TargetDate = TargetDate;
            }

            // Call your database access layer to save/update the item securely
            await _goalRepo.SaveItemAsync(goal);

            // Navigate back to the MainPage list view
            await Shell.Current.GoToAsync("..");
        }
    }
}