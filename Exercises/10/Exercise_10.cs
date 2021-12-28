using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_10
    {
        public Exercise_10()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\10\\";
            string[] split_input = System.IO.File.ReadAllLines(current_directory + "input.txt");

            // Initialize the Grid
            int[,] grid = new int[1000, 1000];

            // Process each line and populate the grid
            for (int i = 0; i < split_input.Length; ++i) {
                string[] location_pair = split_input[i].Split(" -> ");
                string[] origin = location_pair[0].Split(',');
                string[] destination = location_pair[1].Split(',');

                int starting_x = Convert.ToInt32(origin[0]);
                int starting_y = Convert.ToInt32(origin[1]);
                int ending_x = Convert.ToInt32(destination[0]);
                int ending_y = Convert.ToInt32(destination[1]);

                add_line(ref grid, starting_x, starting_y, ending_x, ending_y);
                //print_2d_array(grid);
            }

            // Find the largest element in the grid
            int overlap_count = 0;
            for (int i = 0; i < grid.GetLength(0); ++i) {
                for (int j = 0; j < grid.GetLength(1); ++j) {
                    if (grid[i,j] > 1) {
                        overlap_count += 1;
                    }
                }
            }

            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine(overlap_count.ToString());
        }


        private void add_line(ref int[,] grid, int start_x, int start_y, int end_x, int end_y) {

            // Calculate how far the line moves in any direction
            int x_diff = end_x - start_x;
            int y_diff = end_y - start_y;
            int total_movement = Math.Max(Math.Abs(x_diff), Math.Abs(y_diff));

            // Increment the areas along the line
            int current_x = start_x;
            int current_y = start_y;
            for (int i = 0; i < total_movement + 1; ++i) {
                grid[current_x, current_y] += 1;

                if (total_movement != 0) {
                    current_x = current_x + (x_diff / total_movement);
                    current_y = current_y + (y_diff / total_movement);
                }
            }
        }


        private void print_2d_array(int[,] grid) {
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
