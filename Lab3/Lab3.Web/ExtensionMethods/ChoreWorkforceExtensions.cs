using System;
using Lab3.Objects;

namespace Lab3.Web.ExtensionMethods
{
    public static class ChoreWorkforceExtensions
    {
        public static void AddLaborer(this ChoreWorkforce workforce, string name, int age, int difficulty)
        {
            workforce.Laborers.Add(new ChoreLaborer() { Name = name, Age = age, Difficulty = difficulty });
        }

        public static void AddRandomLaborer(this ChoreWorkforce workforce)
        {
            string[] names = { "James", "Sophia", "Michael", "Emma", "John", "Olivia", "David", "Isabella", "Robert", "Mia", "William" };
            Random random = new Random();

            string randomName = names[random.Next(names.Length)];
            int randomAge = random.Next(7, 19);
            int randomDifficulty = random.Next(1, 11);

            if (randomDifficulty == 10)
            {
                workforce.Laborers.Add(null);
            }
            else
            {
                workforce.Laborers.Add(new ChoreLaborer() { Name = randomName, Age = randomAge, Difficulty = randomDifficulty });
            }
        }
    }
}
