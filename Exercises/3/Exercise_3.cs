using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_3
    {
        public Exercise_3()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\3\\";
            string[] input_list = System.IO.File.ReadAllLines(current_directory + "input.txt");

            int current_position = 0;
            int current_depth = 0;

            for (int i = 0; i < input_list.Length; ++i) {
                string[] direction = input_list[i].Split(' ');
                
                if (direction[0] == "forward") {
                    current_position += Int32.Parse(direction[1]);
                } else if (direction[0] == "down") {
                    current_depth += Int32.Parse(direction[1]);
                } else if (direction[0] == "up") {
                    current_depth -= Int32.Parse(direction[1]);
                }
            }

            int result = current_position * current_depth;

            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine(result.ToString());
        }
    }
}
