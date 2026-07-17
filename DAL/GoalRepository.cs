using MauiApp1.DAL;
using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp1.DAL
{
    public class GoalRepository : IGoalRepository
    {
        private SQLiteAsyncConnection? database;

        // Initialize Database connection (Lazy Initialization)
        private async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await database.CreateTableAsync<GoalEntity>();
        }

        
        // Helper Conversion Functions (Task 6 requirement)
        
        private Goal ToModel(GoalEntity entity)
        {
            if (entity == null) return new Goal();

            return new Goal
            {
                Id = entity.Id,
                Name = entity.Name,
                Motivation = entity.Motivation,
                StartDate = entity.StartDate,
                TargetDate = entity.TargetDate
            };
        }

        private GoalEntity ToEntity(Goal model)
        {
            if (model == null) return new GoalEntity();

            return new GoalEntity
            {
                Id = model.Id,
                Name = model.Name,
                Motivation = model.Motivation,
                StartDate = model.StartDate,
                TargetDate = model.TargetDate
            };
        }

        
        // Repository CRUD Operations
        
        public async Task<List<Goal>> GetItemsAsync()
        {
            await Init();
            var entities = await database!.Table<GoalEntity>().ToListAsync();

            // Convert database GoalEntities into UI Goals
            return entities.Select(entity => ToModel(entity)).ToList();
        }

        public async Task<Goal?> GetItemAsync(int id)
        {
            await Init();
            var entity = await database!.Table<GoalEntity>()
                                        .Where(e => e.Id == id)
                                        .FirstOrDefaultAsync();

            return entity != null ? ToModel(entity) : null;
        }

        public async Task<int> SaveItemAsync(Goal goal)
        {
            await Init();

            // Map incoming UI model data to a database entity structure
            var entity = ToEntity(goal);

            if (entity.Id != 0)
            {
                // Update data existing item
                return await database!.UpdateAsync(entity);
            }
            else
            {
                // Save brand new goal
                int result = await database!.InsertAsync(entity);
                // Update the original goal's ID with the database generated auto-increment ID
                goal.Id = entity.Id;
                return result;
            }
        }

        public async Task<int> DeleteItemAsync(Goal goal)
        {
            await Init();

            // Remove item from database by matching IDs
            return await database!.Table<GoalEntity>()
                                  .DeleteAsync(entity => entity.Id == goal.Id);
        }
    }
}