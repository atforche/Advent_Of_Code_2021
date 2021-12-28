using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_6
    {
        public Exercise_6()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\6\\";
            string[] input_list = System.IO.File.ReadAllLines(current_directory + "input.txt");

            int oxygen_rating = calculate_criteria(ref input_list, "oxygen");
            int co2_rating = calculate_criteria(ref input_list, "co2");
            
            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine((oxygen_rating * co2_rating).ToString());
        }


        private int most_common_bit(ref List<string> input_list, int position) {
            // Track the sum of each position
            int position_sum = 0;
            foreach (string input in input_list) {
                position_sum += (input[position] - '0');
            }

            if (position_sum >= (input_list.Count / 2.0)) {
                return 1;
            }
            return 0;
        }


        private int least_common_bit(ref List<string> input_list, int position) {
            bool ret_val = Convert.ToBoolean(this.most_common_bit(ref input_list, position));
            return Convert.ToInt32(!ret_val);
        }


        private int calculate_criteria(ref string[] input_list, string type) {

            List<string> current_list = new List<string>(input_list);
            int current_position = 0;

            while (current_list.Count > 1) {
                List<string> filtered = new List<string>();

                int criteria = type == "oxygen" ? most_common_bit(ref current_list, current_position) : least_common_bit(ref current_list, current_position);

                for (int i = 0; i < current_list.Count; ++i) {
                    if ((current_list[i][current_position] - '0') == criteria) {
                        filtered.Add(current_list[i]);
                    }
                }

                // Update the current list and position
                current_list = new List<string>(filtered);
                current_position += 1;
            }

            return Convert.ToInt32(current_list[0], 2);
        }
    }
}
