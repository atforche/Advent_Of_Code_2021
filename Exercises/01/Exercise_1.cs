using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_1
    {
        public Exercise_1()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\1\\";
            string[] input_list = System.IO.File.ReadAllLines(current_directory + "input.txt");

            // Convert the input from strings to ints
            List<int> numeric_input = new List<int>();
            for (int i = 0; i < input_list.Length; ++i) {
                numeric_input.Add(Int32.Parse(input_list[i]));
            }

            // Perform the actual calculation
            int counter = 0;
            for (int i = 0; i < numeric_input.Count - 1; ++i) {
                if (numeric_input[i] < numeric_input[i+1]) {
                    counter++;
                }
            }

            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine(counter.ToString());
        }
    }
}
