using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_15
    {
        public Exercise_15()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\15\\";
            string[] input = System.IO.File.ReadAllLines(current_directory + "input.txt");
            List<string[]> output_values = new List<string[]>(input.Length);

            // Capture each of the output values
            foreach (string full_val in input) {
                string[] split = full_val.Split(" | ");
                string[] split_output = split[1].Split(" ");
                output_values.Add(split_output);
            }

            // Count the number of 1's, 4's, 7's, and 8's in the output
            Dictionary<int, int> unique_digits = new Dictionary<int, int>() {
                [2] = 1,
                [3] = 7,
                [4] = 4,
                [7] = 9
            };

            int counter = 0;
            for (int i = 0; i < output_values.Count; ++i) {
                for (int j = 0; j < output_values[i].Length; ++j) {
                    if (unique_digits.ContainsKey(output_values[i][j].Length)) {
                        counter++;
                    }
                }
            }
            

            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine(counter);
        }
    }
}
