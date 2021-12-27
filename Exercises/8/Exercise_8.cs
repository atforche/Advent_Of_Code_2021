using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_Of_Code_2021.Exercises
{
    class Exercise_8
    {
        public Exercise_8()
        {
            // Read in the input
            string current_directory = "C:\\Users\\atfor\\OneDrive\\Desktop\\Code_Projects\\Advent_of_Code_2021\\Exercises\\8\\";
            string raw_input = System.IO.File.ReadAllText(current_directory + "input.txt");
            string[] split_input = raw_input.Split("\r\n\r\n");

            // Process the input
            string[] called_numbers_as_text = split_input[0].Split(',');
            List<int> called_numbers = new List<int>();
            for (int i = 0; i < called_numbers_as_text.Length; ++i) {
                called_numbers.Add(Convert.ToInt32(called_numbers_as_text[i]));
            }

            List<int[,]> boards = new List<int[,]>();
            for (int i = 1; i < split_input.Length; ++i) {
                boards.Add(process_bingo_board(split_input[i]));
            }

            // Evaluate each of the boards
            int longest_victory = 0;
            int winning_total = 0;
            foreach (int[,] board in boards) {
                int[] results = evalute_board_victory(ref called_numbers, board);
                if (results[0] > longest_victory) {
                    longest_victory = results[0];
                    winning_total = results[1];
                }
            }


            // Write the output to disk
            using StreamWriter file = new StreamWriter(current_directory + "output.txt");
            file.WriteLine((winning_total * called_numbers[longest_victory]).ToString());
        }


        private int[,] process_bingo_board(string bingo_board) {

            int[,] board = {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };
                
            string[] rows = bingo_board.Split("\r\n");
            for (int i = 0; i < rows.Length; ++i) {
                string[] numbers = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < numbers.Length; ++j) {
                    board[i, j] = Convert.ToInt32(numbers[j]);
                }
            }

            return board;
        }


        private int[] position_on_board(int[,] board, int digit) {
            for (int i = 0; i < board.GetLength(0); ++i) {
                for (int j = 0; j < board.GetLength(1); ++j) {
                    if (board[i, j] == digit) {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }


        private int[] evalute_board_victory(ref List<int> called_numbers, int[,] board) {

            int[] row_counts = { 0, 0, 0, 0, 0 };
            int[] col_counts = { 0, 0, 0, 0, 0 };

            int turn = 0;
            for (; turn < called_numbers.Count; ++turn) {
                int[] position = position_on_board(board, called_numbers[turn]);
                
                if (position[0] == -1) {
                    continue;
                }

                board[position[0], position[1]] = -1;
                row_counts[position[0]] += 1;
                col_counts[position[1]] += 1;

                bool finished = false;
                foreach (int count in row_counts) {
                    if (count == 5) {
                        finished = true;
                    }
                }

                foreach (int count in col_counts) {
                    if (count == 5) {
                        finished = true;
                    }
                }

                if (finished) {
                    break;
                }
            }

            int finishing_total = 0;
            for (int i = 0; i < board.GetLength(0); ++i) {
                for (int j = 0; j < board.GetLength(1); ++j) {
                    if (board[i, j] == -1) {
                        continue;
                    }
                    finishing_total += board[i, j];
                }
            }

            return new int[] { turn, finishing_total };
        }
    }
}
