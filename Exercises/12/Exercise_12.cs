using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_12
    {
        public Exercise_12()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\12\\";
            string raw_input = System.IO.File.ReadAllText(current_directory + "input.txt");

            // Initialize the population
            string[] initial_population = raw_input.Split(',');
            List<int> population = new List<int>();
            for (int i = 0; i < initial_population.Length; ++i) {
                population.Add(Convert.ToInt32(initial_population[i]));
            }

            // Define a DP Array to store the solution for a certain timer at a certain timestep
            // Update Rule: [0, i] -> 1 + [8, i+1] + [6, i+1]
            // All Else: [x, i] -> [x - 1, i + 1]
            int num_timesteps = 256;
            long[,] dp_array = new long[9, num_timesteps];
            
            // Set up the initial conditions
            dp_array[0, num_timesteps - 1] = 1;

            for (int i = num_timesteps - 2; i >= 0; --i) {
                for (int j = 0; j <= 8; ++j) {
                    if (j == 0) {
                        dp_array[j, i] = 1 + dp_array[8, i + 1] + dp_array[6, i + 1];
                        continue;
                    }
                    dp_array[j, i] = dp_array[j - 1, i + 1];
                }
            }

            //print_2d_array(dp_array);

            // Use the DP Array to calculate the finishing population from the starting population
            long final_population_size = 0;
            foreach (int timer in population) {
                final_population_size += dp_array[timer, 0] + 1;
            }
           
            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine(final_population_size.ToString());
        }


        private void print_2d_array(long[,] grid) {
            for (int i = 0; i < grid.GetLength(0); ++i) {
                for (int j = 0; j < grid.GetLength(1); ++j) {
                    Console.Write(grid[i, j].ToString() + "\t");
                }
                Console.Write("\r\n");
            }
            Console.Write("\r\n");
        }
    }
}
