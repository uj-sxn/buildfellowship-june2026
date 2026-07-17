using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp1.DAL
{
    public interface IGoalRepository
    {
        Task<List<Goal>> GetItemsAsync();
        Task<Goal?> GetItemAsync(int id);
        Task<int> SaveItemAsync(Goal goal);
        Task<int> DeleteItemAsync(Goal goal);
    }
}