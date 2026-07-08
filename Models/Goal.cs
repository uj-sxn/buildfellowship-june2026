namespace MauiApp1.Models
{
    public class Goal
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TargetDate { get; set; }
        public double Progress { get; set; }
        public string Motivation { get; set; }
        public string Steps { get; set; }

        // Adding a Category property if we want to hold the "Hobby" vs "Sport" text
        public string Category { get; set; } 
    }
}