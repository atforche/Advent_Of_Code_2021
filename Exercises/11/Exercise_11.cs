using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_11
    {
        public Exercise_11()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\11\\";
            string raw_input = System.IO.File.ReadAllText(current_directory + "input.txt");

            // Initialize the population
            string[] initial_population = raw_input.Split(',');
            List<int> population = new List<int>();
            for (int i = 0; i < initial_population.Length; ++i) {
                population.Add(Convert.ToInt32(initial_population[i]));
            }

            // Simulate the population
            int num_timesteps = 80;
            for (int i = 0; i < num_timesteps; ++i) {
                int current_count = population.Count;
                for (int j = 0; j < current_count; ++j) {
                    if (population[j] == 0) {
                        population[j] = 6;
                        population.Add(8);
                        continue;
                    }
                    population[j] -= 1;
                }
            }
            

            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine((population.Count).ToString());
        }        
    }
}
