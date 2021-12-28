using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_13
    {
        public Exercise_13()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\13\\";
            string raw_input = System.IO.File.ReadAllText(current_directory + "input.txt");
            string[] split_input = raw_input.Split(",");

            // Convert the input to a list of numbers
            List<int> positions = new List<int>(split_input.Length);
            foreach (string num in split_input) {
                positions.Add(Convert.ToInt32(num));
            }

            // Calculate the final position and the total fuel required to get there
            int final_position = calculate_median(positions);
            int total_fuel = 0;
            for (int i = 0; i < positions.Count; ++i) {
                total_fuel += Math.Abs(positions[i] - final_position);
            }
           
            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine(total_fuel.ToString());
        }


        private int calculate_median(List<int> list) {
            list.Sort();
            if (list.Count % 2 == 0) {
                return Convert.ToInt32(Math.Round((list[(list.Count / 2) - 1] + list[list.Count / 2]) / 2.0));
            }
            return list[list.Count / 2];
        }
    }
}
