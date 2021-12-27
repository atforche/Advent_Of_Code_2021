using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_5
    {
        public Exercise_5
()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\2\\";
            byte[] raw_input = System.IO.File.ReadAllBytes(current_directory + "input.txt");
            string[] input_list;

            // Track the sum of each position
            List<int> position_sums = Enumerable.Repeat(0, input_list[0].Length).ToList();
            foreach (string input in input_list) {
                for (int i = 0; i < input.Length; ++i) {
                    position_sums[i] += (input[i] - '0');
                }
            }

            // Create the gamma_rate
            string gamma_rate = "";
            foreach (int bit in position_sums) {
                if (bit > (input_list.Length / 2)) {
                    gamma_rate += "1";
                } else {
                    gamma_rate += "0";
                }
            }

            int gamma = Convert.ToInt32(gamma_rate, 2);
            int epsilon = ~gamma;

            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine((gamma * epsilon).ToString());
        }
    }
}
