using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_14
    {
        public Exercise_14()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\14\\";
            string raw_input = System.IO.File.ReadAllText(current_directory + "input.txt");
            string[] split_input = raw_input.Split(",");

            // Convert the input to a list of numbers
            List<int> positions = new List<int>(split_input.Length);
            foreach (string num in split_input) {
                positions.Add(Convert.ToInt32(num));
            }

            // Calculate the final position and the total fuel required to get there
            int current_best_final_position = 0;
            int current_best_fuel_usage = int.MaxValue;
            for (int i = 0; i < positions.Max(); ++i) {
                int current_fuel_usage = 0;
                for (int j = 0; j < positions.Count; ++j) {
                    int difference = Math.Abs(positions[j] - i);
                    current_fuel_usage += (difference * (difference + 1)) / 2;
                }

                if (current_fuel_usage < current_best_fuel_usage) {
                    current_best_fuel_usage = current_fuel_usage;
                    current_best_final_position = i;
                }
            }

            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine(current_best_fuel_usage);
        }
    }
}
