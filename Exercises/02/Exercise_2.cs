using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_2
    {
        public Exercise_2()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\2\\";
            string[] input_list = System.IO.File.ReadAllLines(current_directory + "input.txt");

            // Convert the input from strings to ints
            List<int> numeric_input = new List<int>();
            for (int i = 0; i < input_list.Length; ++i) {
                numeric_input.Add(Int32.Parse(input_list[i]));
            }

            // Perform the actual calculation
            int counter = 0;
            int current_sum = 0;
            int previous_sum = 0;

            for (int i = 0; i < numeric_input.Count; ++i) {

                // Build up the initial sliding window
                if (i < 3) {
                    current_sum += numeric_input[i];
                    previous_sum = current_sum;
                    continue;
                }

                // Update the current sum
                current_sum -= numeric_input[i - 3];
                current_sum += numeric_input[i];

                // Check against the previous sum
                if (current_sum > previous_sum) {
                    counter += 1;
                }

                // Update the previous sum
                previous_sum = current_sum;

            }

            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine(counter.ToString());
        }
    }
}
