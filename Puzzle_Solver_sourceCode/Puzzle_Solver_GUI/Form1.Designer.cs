
namespace Puzzle_Solver_GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.welcome_panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Manhattan_radio = new System.Windows.Forms.RadioButton();
            this.Hamming_radio = new System.Windows.Forms.RadioButton();
            this.Console_solver_btn = new System.Windows.Forms.Button();
            this.GUI_solver_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Next_Move = new System.Windows.Forms.Button();
            this.auto_solving = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.moves_num = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.solved_label = new System.Windows.Forms.Label();
            this.game_panel = new System.Windows.Forms.Panel();
            this.priority_label = new System.Windows.Forms.Label();
            this.restart_btn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.solving_T_millS_label = new System.Windows.Forms.Label();
            this.total_moves_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.solving_T_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.puzzle_path_textBox = new System.Windows.Forms.ComboBox();
            this.welcome_panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.game_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcome_panel
            // 
            this.welcome_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("welcome_panel.BackgroundImage")));
            this.welcome_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.welcome_panel.Controls.Add(this.puzzle_path_textBox);
            this.welcome_panel.Controls.Add(this.label6);
            this.welcome_panel.Controls.Add(this.groupBox1);
            this.welcome_panel.Controls.Add(this.Console_solver_btn);
            this.welcome_panel.Controls.Add(this.GUI_solver_btn);
            this.welcome_panel.Controls.Add(this.label3);
            this.welcome_panel.Location = new System.Drawing.Point(0, 0);
            this.welcome_panel.Name = "welcome_panel";
            this.welcome_panel.Size = new System.Drawing.Size(985, 665);
            this.welcome_panel.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(287, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(378, 37);
            this.label6.TabIndex = 5;
            this.label6.Text = "Enter Puzzle txt file path/name";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Manhattan_radio);
            this.groupBox1.Controls.Add(this.Hamming_radio);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(309, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Solving Priority function";
            // 
            // Manhattan_radio
            // 
            this.Manhattan_radio.AutoSize = true;
            this.Manhattan_radio.Location = new System.Drawing.Point(201, 56);
            this.Manhattan_radio.Name = "Manhattan_radio";
            this.Manhattan_radio.Size = new System.Drawing.Size(101, 24);
            this.Manhattan_radio.TabIndex = 1;
            this.Manhattan_radio.TabStop = true;
            this.Manhattan_radio.Text = "Manhattan";
            this.Manhattan_radio.UseVisualStyleBackColor = true;
            // 
            // Hamming_radio
            // 
            this.Hamming_radio.AutoSize = true;
            this.Hamming_radio.Location = new System.Drawing.Point(39, 56);
            this.Hamming_radio.Name = "Hamming_radio";
            this.Hamming_radio.Size = new System.Drawing.Size(96, 24);
            this.Hamming_radio.TabIndex = 0;
            this.Hamming_radio.TabStop = true;
            this.Hamming_radio.Text = "Hamming";
            this.Hamming_radio.UseVisualStyleBackColor = true;
            // 
            // Console_solver_btn
            // 
            this.Console_solver_btn.Location = new System.Drawing.Point(101, 503);
            this.Console_solver_btn.Name = "Console_solver_btn";
            this.Console_solver_btn.Size = new System.Drawing.Size(361, 64);
            this.Console_solver_btn.TabIndex = 2;
            this.Console_solver_btn.Text = "Console Solver";
            this.Console_solver_btn.UseVisualStyleBackColor = true;
            this.Console_solver_btn.Click += new System.EventHandler(this.Console_solver_btn_Click);
            // 
            // GUI_solver_btn
            // 
            this.GUI_solver_btn.Location = new System.Drawing.Point(514, 503);
            this.GUI_solver_btn.Name = "GUI_solver_btn";
            this.GUI_solver_btn.Size = new System.Drawing.Size(361, 64);
            this.GUI_solver_btn.TabIndex = 1;
            this.GUI_solver_btn.Text = "GUI Solver";
            this.GUI_solver_btn.UseVisualStyleBackColor = true;
            this.GUI_solver_btn.Click += new System.EventHandler(this.GUI_solver_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(170, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(650, 50);
            this.label3.TabIndex = 0;
            this.label3.Text = "Welcome to A* Search Puzzle Solver";
            // 
            // Next_Move
            // 
            this.Next_Move.Location = new System.Drawing.Point(582, 559);
            this.Next_Move.Name = "Next_Move";
            this.Next_Move.Size = new System.Drawing.Size(361, 64);
            this.Next_Move.TabIndex = 0;
            this.Next_Move.Text = "Next Move";
            this.Next_Move.UseVisualStyleBackColor = true;
            this.Next_Move.Click += new System.EventHandler(this.Next_Move_Click);
            // 
            // auto_solving
            // 
            this.auto_solving.BackColor = System.Drawing.Color.LimeGreen;
            this.auto_solving.Location = new System.Drawing.Point(582, 467);
            this.auto_solving.Name = "auto_solving";
            this.auto_solving.Size = new System.Drawing.Size(361, 64);
            this.auto_solving.TabIndex = 1;
            this.auto_solving.Text = "Auto Solve";
            this.auto_solving.UseVisualStyleBackColor = false;
            this.auto_solving.Click += new System.EventHandler(this.auto_solving_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(132, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 62);
            this.label1.TabIndex = 2;
            this.label1.Text = "Puzzle Solver";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(180, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "A* Search Algorithm";
            // 
            // moves_num
            // 
            this.moves_num.AutoSize = true;
            this.moves_num.BackColor = System.Drawing.Color.Transparent;
            this.moves_num.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.moves_num.ForeColor = System.Drawing.Color.Gainsboro;
            this.moves_num.Location = new System.Drawing.Point(846, 371);
            this.moves_num.Name = "moves_num";
            this.moves_num.Size = new System.Drawing.Size(52, 62);
            this.moves_num.TabIndex = 4;
            this.moves_num.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(624, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 62);
            this.label4.TabIndex = 5;
            this.label4.Text = "Moves #";
            // 
            // solved_label
            // 
            this.solved_label.AutoSize = true;
            this.solved_label.BackColor = System.Drawing.Color.Transparent;
            this.solved_label.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.solved_label.ForeColor = System.Drawing.Color.LimeGreen;
            this.solved_label.Location = new System.Drawing.Point(582, 299);
            this.solved_label.Name = "solved_label";
            this.solved_label.Size = new System.Drawing.Size(0, 41);
            this.solved_label.TabIndex = 7;
            // 
            // game_panel
            // 
            this.game_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("game_panel.BackgroundImage")));
            this.game_panel.Controls.Add(this.priority_label);
            this.game_panel.Controls.Add(this.restart_btn);
            this.game_panel.Controls.Add(this.label7);
            this.game_panel.Controls.Add(this.solving_T_millS_label);
            this.game_panel.Controls.Add(this.total_moves_label);
            this.game_panel.Controls.Add(this.label8);
            this.game_panel.Controls.Add(this.solving_T_label);
            this.game_panel.Controls.Add(this.label5);
            this.game_panel.Controls.Add(this.solved_label);
            this.game_panel.Controls.Add(this.label1);
            this.game_panel.Controls.Add(this.Next_Move);
            this.game_panel.Controls.Add(this.label4);
            this.game_panel.Controls.Add(this.auto_solving);
            this.game_panel.Controls.Add(this.moves_num);
            this.game_panel.Controls.Add(this.label2);
            this.game_panel.Location = new System.Drawing.Point(0, 0);
            this.game_panel.Name = "game_panel";
            this.game_panel.Size = new System.Drawing.Size(985, 665);
            this.game_panel.TabIndex = 3;
            // 
            // priority_label
            // 
            this.priority_label.AutoSize = true;
            this.priority_label.BackColor = System.Drawing.Color.Transparent;
            this.priority_label.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priority_label.ForeColor = System.Drawing.Color.White;
            this.priority_label.Location = new System.Drawing.Point(604, 175);
            this.priority_label.Name = "priority_label";
            this.priority_label.Size = new System.Drawing.Size(316, 50);
            this.priority_label.TabIndex = 15;
            this.priority_label.Text = "Manhatan Priority";
            // 
            // restart_btn
            // 
            this.restart_btn.BackColor = System.Drawing.Color.Transparent;
            this.restart_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("restart_btn.BackgroundImage")));
            this.restart_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.restart_btn.FlatAppearance.BorderSize = 0;
            this.restart_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restart_btn.Location = new System.Drawing.Point(22, 27);
            this.restart_btn.Name = "restart_btn";
            this.restart_btn.Size = new System.Drawing.Size(35, 35);
            this.restart_btn.TabIndex = 14;
            this.restart_btn.UseVisualStyleBackColor = false;
            this.restart_btn.Click += new System.EventHandler(this.restart_btn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(808, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 28);
            this.label7.TabIndex = 13;
            this.label7.Text = "/";
            // 
            // solving_T_millS_label
            // 
            this.solving_T_millS_label.AutoSize = true;
            this.solving_T_millS_label.BackColor = System.Drawing.Color.Transparent;
            this.solving_T_millS_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.solving_T_millS_label.ForeColor = System.Drawing.Color.White;
            this.solving_T_millS_label.Location = new System.Drawing.Point(712, 34);
            this.solving_T_millS_label.Name = "solving_T_millS_label";
            this.solving_T_millS_label.Size = new System.Drawing.Size(31, 28);
            this.solving_T_millS_label.TabIndex = 12;
            this.solving_T_millS_label.Text = "-1";
            // 
            // total_moves_label
            // 
            this.total_moves_label.AutoSize = true;
            this.total_moves_label.BackColor = System.Drawing.Color.Transparent;
            this.total_moves_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.total_moves_label.ForeColor = System.Drawing.Color.White;
            this.total_moves_label.Location = new System.Drawing.Point(788, 80);
            this.total_moves_label.Name = "total_moves_label";
            this.total_moves_label.Size = new System.Drawing.Size(31, 28);
            this.total_moves_label.TabIndex = 11;
            this.total_moves_label.Text = "-1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(648, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 28);
            this.label8.TabIndex = 10;
            this.label8.Text = "Total Moves #";
            // 
            // solving_T_label
            // 
            this.solving_T_label.AutoSize = true;
            this.solving_T_label.BackColor = System.Drawing.Color.Transparent;
            this.solving_T_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.solving_T_label.ForeColor = System.Drawing.Color.White;
            this.solving_T_label.Location = new System.Drawing.Point(854, 36);
            this.solving_T_label.Name = "solving_T_label";
            this.solving_T_label.Size = new System.Drawing.Size(31, 28);
            this.solving_T_label.TabIndex = 9;
            this.solving_T_label.Text = "-1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(534, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "Real Solving Time:";
            // 
            // puzzle_path_textBox
            // 
            this.puzzle_path_textBox.FormattingEnabled = true;
            this.puzzle_path_textBox.Location = new System.Drawing.Point(309, 214);
            this.puzzle_path_textBox.Name = "puzzle_path_textBox";
            this.puzzle_path_textBox.Size = new System.Drawing.Size(333, 28);
            this.puzzle_path_textBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.welcome_panel);
            this.Controls.Add(this.game_panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.welcome_panel.ResumeLayout(false);
            this.welcome_panel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.game_panel.ResumeLayout(false);
            this.game_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel welcome_panel;
        private System.Windows.Forms.Button GUI_solver_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Console_solver_btn;
        private System.Windows.Forms.Button Next_Move;
        private System.Windows.Forms.Button auto_solving;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label moves_num;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label solved_label;
        private System.Windows.Forms.Panel game_panel;
        private System.Windows.Forms.Label total_moves_label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label solving_T_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Manhattan_radio;
        private System.Windows.Forms.RadioButton Hamming_radio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label solving_T_millS_label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button restart_btn;
        private System.Windows.Forms.Label priority_label;
        private System.Windows.Forms.ComboBox puzzle_path_textBox;
    }
}

