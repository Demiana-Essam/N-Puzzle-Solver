using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Solver_GUI
{
    class game_State
    {
        public game_State parent;
        public int[,] game_matrix;
        public int x_blank;
        public int y_blank;
        public int Heuristic_Cost; //Total cost (sum of Hamming & Manhattan)
        public int Expansion_Level;
        public int from;
        private int Hamming_priority;
        private int Manhattan_priority;
        private int size;

        //implementation of Swap function
        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        //Root constructor (without X & Y blank of child)
        public game_State(int size, game_State parent, int[,] game_matrix,
                            int x_blank, int y_blank, int Expansion_order)
        {
            this.from = -1;
            this.size = size;
            this.parent = parent;
            this.game_matrix = game_matrix.Clone() as int[,];
            this.x_blank = x_blank;
            this.y_blank = y_blank;
            this.Expansion_Level = Expansion_order; //Level
            this.Hamming_priority = -1;
            this.Manhattan_priority = -1;
            this.Heuristic_Cost = int.MaxValue;
        }

        //New game states Constructor (to be used during search with new X & Y Blank values)
        public game_State(int size, game_State parent, int[,] game_matrix, int x_blank, int y_blank,
                            int x_blank_child, int y_blank_child, int Expansion_order)
        {
            this.from = -1;
            this.size = size;
            this.parent = parent;
            this.game_matrix = new int[size, size];
            this.Expansion_Level = Expansion_order;
            this.Hamming_priority = -1;
            this.Manhattan_priority = -1;
            this.Heuristic_Cost = int.MaxValue;
            //copying Game matrix from parameters to the object variable
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.game_matrix[i, j] = game_matrix[i, j];
                }
            }

            //sliding a value to generate the new state of puzzle
            Swap(ref this.game_matrix[x_blank, y_blank], ref this.game_matrix[x_blank_child, y_blank_child]);

            //Update the indices of blank value in the new game state object
            this.x_blank = x_blank_child;
            this.y_blank = y_blank_child;
        }

        //calculate and set Total (Heuristic) cost 
        public void set_Heuristic_Cost(int Hamming, int Manhattan, int priority_fn)
        {
            this.Hamming_priority = Hamming;
            this.Manhattan_priority = Manhattan;

            if (priority_fn == 1)
            {
                Heuristic_Cost = Hamming + Expansion_Level;
            }
            else
            {
                Heuristic_Cost = Manhattan + Expansion_Level;
            }
        }

        public bool is_solved()
        {
            if (Hamming_priority == 0 || Manhattan_priority == 0)
            {
                return true;
            }
            return false;
        }
        public void display_state()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("[");
                for (int j = 0; j < size; j++)
                {
                    if (j == (size - 1))
                    {
                        Console.Write(game_matrix[i, j] + " ");
                    }
                    else
                        Console.Write(game_matrix[i, j] + " ,");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }

    }
}
