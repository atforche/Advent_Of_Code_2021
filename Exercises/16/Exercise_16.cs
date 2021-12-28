using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_16
    {
        public Exercise_16() {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\16\\";
            string[] input = System.IO.File.ReadAllLines(current_directory + "input.txt");
            List<List<string>> output_values = new List<List<string>>(input.Length);
            List<List<string>> input_values = new List<List<string>>(input.Length);

            // Capture each of the input and output values
            foreach (string full_val in input) {
                string[] split = full_val.Split(" | ");

                string[] split_input = split[0].Split(" ");
                input_values.Add(new List<string>(split_input));

                string[] split_output = split[1].Split(" ");
                output_values.Add(new List<string>(split_output));
            }

            List<int> decoded_outputs = new List<int>();
            for (int i = 0; i < output_values.Count; ++i) {
                Dictionary<int, string> identified_values = identify_digits(input_values[i]);

                // Debugging Print Statement
                //foreach (int key in identified_values.Keys) {
                //    Console.WriteLine(key.ToString() + ": " + identified_values[key]);
                //}

                string decoded_output_string = "";
                foreach (string output in output_values[i]) {
                    foreach (int digit in identified_values.Keys) {
                        if (string_distance(identified_values[digit], output) == 0) {
                            decoded_output_string += (char) ('0' + digit);
                            break;
                        }
                    }
                }

                decoded_outputs.Add(Convert.ToInt32(decoded_output_string));
            }

            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine(decoded_outputs.Sum());
        }


        private int string_distance(string str1, string str2) {
            Dictionary<char, int> encoding1 = new Dictionary<char, int>();
            Dictionary<char, int> encoding2 = new Dictionary<char, int>();

            foreach (char character in str1) {
                if (!encoding1.ContainsKey(character)) {
                    encoding1.Add(character, 1);
                } else {
                    encoding1[character]++;
                }
            }

            foreach (char character in str2) {
                if (!encoding2.ContainsKey(character)) {
                    encoding2.Add(character, 1);
                }
                else {
                    encoding2[character]++;
                }
            }

            int distance = 0;
            foreach (char key in encoding1.Keys) {
                if (encoding2.ContainsKey(key)) {
                    distance += Math.Abs(encoding1[key] - encoding2[key]);
                    encoding2.Remove(key);
                } else {
                    distance += encoding1[key];
                }
            }

            foreach (char key in encoding2.Keys) {
                distance += encoding2[key];
            }


            return distance;

        }


        private Dictionary<int, string> identify_digits(List<string> input_values) {

            // Track each unique combination of letters identified
            Dictionary<int, string> identified_digits = new Dictionary<int, string>();

            // First identify the digits given by length
            for (int i = input_values.Count - 1; i >= 0; --i) {
                if (input_values[i].Length == 2) {
                    identified_digits.Add(1, input_values[i]);
                    input_values.RemoveAt(i);
                }
                else if (input_values[i].Length == 3) {
                    identified_digits.Add(7, input_values[i]);
                    input_values.RemoveAt(i);
                }
                else if (input_values[i].Length == 4) {
                    identified_digits.Add(4, input_values[i]);
                    input_values.RemoveAt(i);
                }
                else if (input_values[i].Length == 7) {
                    identified_digits.Add(8, input_values[i]);
                    input_values.RemoveAt(i);
                }
            }

            // Now identify the 3
            for (int i = 0; i < input_values.Count; ++i) {
                if (string_distance(identified_digits[7], input_values[i]) == 2) {
                    identified_digits.Add(3, input_values[i]);
                    input_values.RemoveAt(i);
                }
            }

            // Now identify the 9
            for (int i = 0; i < input_values.Count; ++i) {
                if (string_distance(identified_digits[3], input_values[i]) == 1) {
                    identified_digits.Add(9, input_values[i]);
                    input_values.RemoveAt(i);
                }
            }

            // Now identify the 0
            for (int i = 0; i < input_values.Count; ++i) {
                if (string_distance(identified_digits[7], input_values[i]) == 3) {
                    identified_digits.Add(0, input_values[i]);
                    input_values.RemoveAt(i);
                }
            }

            // Now identify the 6
            for (int i = 0; i < input_values.Count; ++i) {
                if (input_values[i].Length == 6) {
                    identified_digits.Add(6, input_values[i]);
                    input_values.RemoveAt(i);
                }
            }

            // Now identify the 5
            for (int i = 0; i < input_values.Count; ++i) {
                if (string_distance(identified_digits[9], input_values[i]) == 1) {
                    identified_digits.Add(5, input_values[i]);
                    input_values.RemoveAt(i);
                }
            }

            // Now identify the 2
            identified_digits.Add(2, input_values[0]);

            // Return the dictionary of each digit
            return identified_digits;
        }
    }
}
