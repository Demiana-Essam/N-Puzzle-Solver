using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace Puzzle_Solver_GUI
{
    public partial class Form1 : Form
    {
        static int[,] Goal;
        static int Matrix_Size;
        static int moves_counter = 0;
        static int tries_counter = 0;
        static int funtion_selected;
        static int x_blank = -1, y_blank = -1;
        static Stopwatch solver_Stopwatch;
        static List<game_State> shortest_path;
        static List<Button> GUI_puzzle_btns;
        static bool is_Console = false;
        static string file_path;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shortest_path = new List<game_State>();
            GUI_puzzle_btns = new List<Button>();

            file_path= "99 Puzzle - 1.txt";
            //Sample - Solvable 
            puzzle_path_textBox.Text = file_path;
            puzzle_path_textBox.Items.Add("--Sample Tests - Solvable--");
            puzzle_path_textBox.Items.Add("8 Puzzle (1).txt");
            puzzle_path_textBox.Items.Add("8 Puzzle (2).txt");
            puzzle_path_textBox.Items.Add("8 Puzzle (3).txt");
            puzzle_path_textBox.Items.Add("15 Puzzle - 1.txt");
            puzzle_path_textBox.Items.Add("24 Puzzle 1.txt");
            puzzle_path_textBox.Items.Add("24 Puzzle 2.txt");
            //Sample - unsolvable
            puzzle_path_textBox.Items.Add("--Sample Tests - Unsolvable--");
            puzzle_path_textBox.Items.Add("8 Puzzle - Case 1.txt");
            puzzle_path_textBox.Items.Add("8 Puzzle(2) - Case 1.txt");
            puzzle_path_textBox.Items.Add("8 Puzzle(3) - Case 1.txt");
            puzzle_path_textBox.Items.Add("15 Puzzle - Case 2.txt");
            puzzle_path_textBox.Items.Add("15 Puzzle - Case 3.txt");
            //Complete solvable Manhattan & Hamming
            puzzle_path_textBox.Items.Add("--Complete Tests - Solvable--");
            puzzle_path_textBox.Items.Add("50 Puzzle.txt");
            puzzle_path_textBox.Items.Add("99 Puzzle - 1.txt");
            puzzle_path_textBox.Items.Add("99 Puzzle - 2.txt");
            puzzle_path_textBox.Items.Add("9999 Puzzle.txt");
            //Complete solvable Manhattan Only
            puzzle_path_textBox.Items.Add("--Complete Tests - Manhattan Only--");
            puzzle_path_textBox.Items.Add("15 Puzzle 1.txt");
            puzzle_path_textBox.Items.Add("15 Puzzle 3.txt");
            puzzle_path_textBox.Items.Add("15 Puzzle 4.txt");
            //Complete - unsolvable
            puzzle_path_textBox.Items.Add("--Complete Tests - Unsolvable--");
            puzzle_path_textBox.Items.Add("15 Puzzle 1 - Unsolvable.txt");
            puzzle_path_textBox.Items.Add("99 Puzzle - Unsolvable Case 1.txt");
            puzzle_path_textBox.Items.Add("99 Puzzle - Unsolvable Case 2.txt");
            puzzle_path_textBox.Items.Add("9999 Puzzle  - Unsolvable Case.txt");
            //Complete - v Large
            puzzle_path_textBox.Items.Add("--Complete Tests - V.Large--");
            puzzle_path_textBox.Items.Add("TEST.txt");

            groupBox1.Controls.Add(this.Hamming_radio);
            groupBox1.Controls.Add(this.Manhattan_radio);
            Manhattan_radio.Checked = true;
        }
        private void GUI_solver_btn_Click(object sender, EventArgs e)
        {
            file_path = puzzle_path_textBox.Text;
            try
            {
                FileStream file = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                StreamReader s_Reader = new StreamReader(file);
                string line;

                if (s_Reader == null) //if its not open
                {
                    throw new Exception("Unable to open file.");
                }
                //Read First Line to get Matrix Size
                line = s_Reader.ReadLine();
                Matrix_Size = int.Parse(line);
                Console.WriteLine("Matrix size: " + Matrix_Size + "\n");

                if (Matrix_Size > 10)
                {
                    s_Reader.Close();
                    file.Close();
                    MessageBox.Show("Sorry, The Puzzle is too large to display- Please use Console Solver.");
                    Application.Restart();
                    Environment.Exit(0);

                }
                //To skip the empty line
                s_Reader.ReadLine();

                //declaring 2D array
                int[,] game_mat = new int[Matrix_Size, Matrix_Size];

                // reading data from text file
                string[] temp_row = new string[Matrix_Size];
                for (int i = 0; i < Matrix_Size; i++)
                {
                    line = s_Reader.ReadLine();
                    temp_row = line.Split(" ");
                    for (int j = 0; j < Matrix_Size; j++)
                    {
                        game_mat[i, j] = int.Parse(temp_row[j]);
                    }
                }

                //Closing file & stream reader 
                s_Reader.Close();
                file.Close();

                //Generate Goal matrex
                Goal = new int[Matrix_Size, Matrix_Size];
                int temp_counter = 1;
                for (int i = 0; i < Matrix_Size; i++)
                {
                    for (int j = 0; j < Matrix_Size; j++)
                    {
                        if (i == (Matrix_Size - 1) && j == (Matrix_Size - 1))
                        {
                            //to set the last value in the matrix (Blank value) = 0 
                            Goal[i, j] = 0;
                            break;
                        }
                        Goal[i, j] = temp_counter;
                        temp_counter++;
                    }
                }

                //Finding Blank value index in initial matrix
                bool position_found = false;
                for (int i = 0; i < Matrix_Size; i++)
                {
                    for (int j = 0; j < Matrix_Size; j++)
                    {
                        if (game_mat[i, j] == 0)
                        {
                            x_blank = i;
                            y_blank = j;
                            position_found = true;
                            break;
                        }
                    }
                    if (position_found)
                        break;
                }

                //set puzzle block size (Dynamically)
                int button_size = 470 / Matrix_Size;
                //selecting Priority function based on user choice
                if (Hamming_radio.Checked)
                {
                    funtion_selected = 1;
                    priority_label.Text = "Hamming priority";
                }
                else
                {
                    funtion_selected = 2;
                    priority_label.Text = "Manhattan priority";
                }
                solver_Stopwatch = Stopwatch.StartNew();
                if (is_solvable(game_mat))
                {
                    solve(game_mat, Matrix_Size, x_blank, y_blank);
                }
                else
                {
                    MessageBox.Show("This Puzzle is unsolvable");
                    Application.Restart();
                }

                for (int i = 0; i < Matrix_Size; i++)
                {
                    for (int j = 0; j < Matrix_Size; j++)
                    {
                        CreateDynamicButton(((j * button_size) + 52), ((i * button_size) + 163), button_size, game_mat[i, j]);
                    }
                }

                solving_T_label.Text = (solver_Stopwatch.ElapsedMilliseconds / (float)1000).ToString() + " sec";
                solving_T_millS_label.Text = (solver_Stopwatch.ElapsedMilliseconds).ToString() + " ms";
                total_moves_label.Text = (moves_counter - 1).ToString();
                welcome_panel.Hide();
            }
            catch
            {
                MessageBox.Show("Invalid path, Please try again (.../fileName.txt)");
            }

        }
        private void Console_solver_btn_Click(object sender, EventArgs e)
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();


            is_Console = true;
            GUI_solver_btn.Enabled = false;

            file_path = puzzle_path_textBox.Text;
            try
            {
                FileStream file = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                StreamReader s_Reader = new StreamReader(file);
                string line;

                if (s_Reader == null) //if its not open
                {
                    throw new Exception("Unable to open file.");
                }
                //Open Console
                AllocConsole();
                //Read First Line to get Matrix Size
                line = s_Reader.ReadLine();
                Matrix_Size = int.Parse(line);
                Console.WriteLine("Matrix size: " + Matrix_Size + "\n");

                //To skip the empty line
                s_Reader.ReadLine();

                //declaring 2D array
                int[,] game_mat = new int[Matrix_Size, Matrix_Size];

                // reading data from text file
                string[] temp_row = new string[Matrix_Size];
                for (int i = 0; i < Matrix_Size; i++)
                {
                    line = s_Reader.ReadLine();
                    temp_row = line.Split(" ");
                    for (int j = 0; j < Matrix_Size; j++)
                    {
                        game_mat[i, j] = int.Parse(temp_row[j]);
                    }
                }

                //Closing file & stream reader 
                s_Reader.Close();
                file.Close();

                //Generate Goal matrex
                Goal = new int[Matrix_Size, Matrix_Size];
                int temp_counter = 1;
                for (int i = 0; i < Matrix_Size; i++)
                {
                    for (int j = 0; j < Matrix_Size; j++)
                    {
                        if (i == (Matrix_Size - 1) && j == (Matrix_Size - 1))
                        {
                            //to set the last value in the matrix (Blank value) = 0 
                            Goal[i, j] = 0;
                            break;
                        }
                        Goal[i, j] = temp_counter;
                        temp_counter++;
                    }
                }

                //Finding Blank value index in initial matrix
                bool position_found = false;
                for (int i = 0; i < Matrix_Size; i++)
                {
                    for (int j = 0; j < Matrix_Size; j++)
                    {
                        if (game_mat[i, j] == 0)
                        {
                            x_blank = i;
                            y_blank = j;
                            position_found = true;
                            break;
                        }
                    }
                    if (position_found)
                        break;
                }
                if (Hamming_radio.Checked)
                {
                    funtion_selected = 1;
                }
                else
                {

                    funtion_selected = 2;
                }
                if (funtion_selected == 1)
                {
                    Console.WriteLine("Selected Priority function: Hamming");
                }
                else
                {
                    Console.WriteLine("Selected Priority function: Manhattan");
                }

                //Time Measure to solve the puzzle using A* algorithm
                solver_Stopwatch = Stopwatch.StartNew();
                if (is_solvable(game_mat))
                {
                    Console.WriteLine("\nSolving Started: \n");
                    solve(game_mat, Matrix_Size, x_blank, y_blank);
                }
                else
                {
                    Console.WriteLine("Puzzle is not solvable");
                    return;
                }
                Console.WriteLine("Solving Time is: " + (solver_Stopwatch.ElapsedMilliseconds) + " ms / " + (solver_Stopwatch.ElapsedMilliseconds / (float)1000) + " sec");
                //Console.WriteLine("Total Number of Tries: "+ tries_counter);
            }
            catch
            {
                MessageBox.Show("Invalid path, Please try again (.../fileName.txt)");
            }
        }
        static bool is_solvable(int[,] game_matrix)
        {

            int Count = calc_Inversions(game_matrix);


            if (Matrix_Size % 2 != 0 && Count % 2 == 0)
                return true;

            else
            {
                int pos = Matrix_Size - x_blank;
                if (pos % 2 != 0)
                    return Count % 2 == 0;
                else
                    return Count % 2 != 0;
            }


        }
        static int calc_Inversions(int[,] game_matrix)
        {

            List<int> one_D_arr = new List<int>();
            for (int i = 0; i < Matrix_Size; i++)
            {
                for (int j = 0; j < Matrix_Size; j++)
                {
                    if (game_matrix[i, j] != 0)
                    {
                        one_D_arr.Add(game_matrix[i, j]);
                    }
                }
            }


            int Count = 0;
            int list_size = one_D_arr.Count;

            for (int i = 0; i < list_size - 1; i++)
            {

                for (int j = i + 1; j < list_size; j++)
                {
                    if (one_D_arr[i] > one_D_arr[j])
                    {
                        Count++;
                    }
                }
            }
            return Count;
        }
        static void solve(int[,] initial_mat, int Matrix_Size, int x_blank, int y_blank)
        {
            PriorityQueue<game_State, int> qu = new PriorityQueue<game_State, int>();

            game_State initial_State = new game_State(Matrix_Size, null, initial_mat, x_blank, y_blank, 0);
            calculate_Heuristic_Cost(initial_State);

            qu.Enqueue(initial_State, initial_State.Heuristic_Cost);

            // bottom, left, top, right
            int[] move_Directions = { 1, 0, -1, 0, 0, -1, 0, 1 };
            int x_move_safty = 0;
            int y_move_safty = 0;

            while (qu.TryDequeue(out game_State current_Game_state, out int H_cost))
            {
                if (current_Game_state.is_solved())
                {
                    solver_Stopwatch.Stop();
                    printPath(current_Game_state);
                    Console.WriteLine("Number of moves: " + (moves_counter - 1));
                    CreateFile();
                    return;
                }
                // bottom, left, top, right
                for (int i = 0; i < 4; i++)
                {
                    x_move_safty = current_Game_state.x_blank + move_Directions[i];
                    y_move_safty = current_Game_state.y_blank + move_Directions[i + 4];
                    if (x_move_safty >= 0 && x_move_safty < Matrix_Size && y_move_safty >= 0 && y_move_safty < Matrix_Size && current_Game_state.from != i)
                    {
                        game_State next_Move = new game_State(Matrix_Size, current_Game_state, current_Game_state.game_matrix, current_Game_state.x_blank, current_Game_state.y_blank, x_move_safty, y_move_safty, (current_Game_state.Expansion_Level + 1));
                        next_Move.from = (i + 2) % 4;
                        calculate_Heuristic_Cost(next_Move);
                        qu.Enqueue(next_Move, next_Move.Heuristic_Cost);

                    }
                }
                //tries_counter++;
            }
        }
        static void calculate_Heuristic_Cost(game_State current_state)
        {
            int Manhattan = int.MaxValue;
            int Wrong_Positions = int.MaxValue;

            // Hamming
            if (funtion_selected == 1)
            {
                Wrong_Positions = 0;
                for (int i = 0; i < Matrix_Size; i++)
                {
                    for (int j = 0; j < Matrix_Size; j++)
                    {
                        if (current_state.game_matrix[i, j] != Goal[i, j] && current_state.game_matrix[i, j] != 0)
                        {
                            Wrong_Positions++;
                        }
                    }
                }
            }
            //manhattan
            if (funtion_selected == 2)
            {
                Manhattan = 0;
                for (int k = 0; k < Matrix_Size; k++)
                {
                    for (int n = 0; n < Matrix_Size; n++)
                    {
                        if (current_state.game_matrix[k, n] != Goal[k, n] && current_state.game_matrix[k, n] != 0)
                        {

                            int real_J = (current_state.game_matrix[k, n] - 1) % Matrix_Size;
                            int real_i = (current_state.game_matrix[k, n] - 1) / Matrix_Size;
                            Manhattan += (Math.Abs(real_i - k) + Math.Abs(real_J - n));
                        }
                    }
                }
            }

            current_state.set_Heuristic_Cost(Wrong_Positions, Manhattan, funtion_selected);
        }
        static void printPath(game_State goal_State)
        {
            if (goal_State == null)
                return;
            //Print the path from root to Goal
            printPath(goal_State.parent);

            Console.WriteLine("Move #" + moves_counter);
            if (is_Console)
            {
                goal_State.display_state();
            }
            shortest_path.Add(goal_State);
            moves_counter++;
            Console.WriteLine();
        }
        private void CreateDynamicButton(int pos_x,int pos_y,int size,int text)
        { 
            Button puzzle_Block = new Button();
            GUI_puzzle_btns.Add(puzzle_Block);

            puzzle_Block.Height = size;
            puzzle_Block.Width = size;
            puzzle_Block.BackColor = Color.AliceBlue;
            puzzle_Block.ForeColor = Color.Black;
            puzzle_Block.Location = new Point(pos_x, pos_y);
            if(text!=0)
                puzzle_Block.Text = text.ToString();
            puzzle_Block.Name = "Dynamic_Puzzle_Button"+text;
            puzzle_Block.Font = new Font("Georgia", 12);
 
            game_panel.Controls.Add(puzzle_Block);

        }

        static int num_clicks = 1;
        private void Next_Move_Click(object sender, EventArgs e)
        {
            if (num_clicks < moves_counter)
            {
                int counter = 0;
                for (int i = 0; i < Matrix_Size; i++)
                {
                    for (int j = 0; j < Matrix_Size; j++)
                    {
                        GUI_puzzle_btns[counter].Text = shortest_path[num_clicks].game_matrix[i, j] != 0 ? shortest_path[num_clicks].game_matrix[i, j].ToString() : "";
                        game_panel.Controls.Add(GUI_puzzle_btns[counter]);
                        counter++;
                    }

                }
                moves_num.Text = (num_clicks).ToString();
                num_clicks++;
            }
            else
            {
                solved_label.Text = "Puzzle Solved Successfully";
            }
            
        }
        Timer auto_solver_timer = new Timer();
        private void auto_solving_Click(object sender, EventArgs e)
        {
            
            auto_solver_timer.Interval = 250;
            EventHandler ev = new EventHandler(auto_Next_move_Tick);
            auto_solver_timer.Tick += ev;
            auto_solver_timer.Start();
        }
        private void auto_Next_move_Tick(object sender, EventArgs e)
        {
            if (num_clicks == (moves_counter))
            {
                auto_solver_timer.Enabled = false;
            }
            Next_Move.PerformClick();
        }

        private void restart_btn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        static void CreateFile()
        {
            string solved_file_path = @"Solutions\"+file_path.Remove(file_path.Length - 4) + " solution.txt";
            try
            {
                FileStream sb = new FileStream(solved_file_path, FileMode.OpenOrCreate);
                using (StreamWriter sr = new StreamWriter(sb))
                {

                    int create_counter = 0;
                    foreach (game_State s in shortest_path)
                    {

                        sr.WriteLine("Move #" + create_counter);
                        for (int i = 0; i < Matrix_Size; i++)
                        {
                            for (int j = 0; j < Matrix_Size; j++)
                            {
                                sr.Write(s.game_matrix[i, j] + " ");
                            }
                            sr.WriteLine();
                        }
                        create_counter++;
                        sr.WriteLine();
                    }
                    sr.WriteLine("Total number of moves: " + (create_counter - 1));
                    sr.WriteLine("Solving time: " + solver_Stopwatch.ElapsedMilliseconds + " ms      /      " + (solver_Stopwatch.ElapsedMilliseconds / (float)1000) + " Sec");
                }
            }
            catch
            {
                File.Delete(solved_file_path);
                MessageBox.Show("Error in saving Solution File");
            }
        }
    }
}
