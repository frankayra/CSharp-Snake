namespace Snake
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb_field = new System.Windows.Forms.PictureBox();
            this.nud_rows = new System.Windows.Forms.NumericUpDown();
            this.pb_Direction = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.level_progress_bar = new System.Windows.Forms.ProgressBar();
            this.lbl_level_number = new System.Windows.Forms.Label();
            this.nud_cols = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.gb_game_play = new System.Windows.Forms.GroupBox();
            this.tb_speed = new System.Windows.Forms.TrackBar();
            this.pb_pause_game = new System.Windows.Forms.PictureBox();
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.lbl_points = new System.Windows.Forms.Label();
            this.lbl_label_points = new System.Windows.Forms.Label();
            this.lbl_label_lifes = new System.Windows.Forms.Label();
            this.lbl_lifes = new System.Windows.Forms.Label();
            this.btn_brown_color = new System.Windows.Forms.Button();
            this.btn_deepsky_color = new System.Windows.Forms.Button();
            this.btn_yellow_color = new System.Windows.Forms.Button();
            this.btn_red_color = new System.Windows.Forms.Button();
            this.btn_cyan_color = new System.Windows.Forms.Button();
            this.btn_black_color = new System.Windows.Forms.Button();
            this.btn_darkviolet_color = new System.Windows.Forms.Button();
            this.btn_gold_color = new System.Windows.Forms.Button();
            this.btn_crimson_color = new System.Windows.Forms.Button();
            this.btn_deeppink_color = new System.Windows.Forms.Button();
            this.btn_fuchsia_color = new System.Windows.Forms.Button();
            this.btn_springgreen_color = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.respawn_timer = new System.Windows.Forms.Timer(this.components);
            this.lbl_time_to_respawn = new System.Windows.Forms.Label();
            this.btn_make_big_camera = new System.Windows.Forms.Button();
            this.btn_make_little_camera = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Direction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cols)).BeginInit();
            this.gb_game_play.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pause_game)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_field
            // 
            this.pb_field.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pb_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_field.Location = new System.Drawing.Point(353, 24);
            this.pb_field.Name = "pb_field";
            this.pb_field.Size = new System.Drawing.Size(650, 650);
            this.pb_field.TabIndex = 0;
            this.pb_field.TabStop = false;
            this.pb_field.Paint += new System.Windows.Forms.PaintEventHandler(this.Pb_field_Paint);
            // 
            // nud_rows
            // 
            this.nud_rows.Location = new System.Drawing.Point(12, 28);
            this.nud_rows.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_rows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_rows.Name = "nud_rows";
            this.nud_rows.Size = new System.Drawing.Size(48, 20);
            this.nud_rows.TabIndex = 1;
            this.nud_rows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // pb_Direction
            // 
            this.pb_Direction.Location = new System.Drawing.Point(21, 578);
            this.pb_Direction.Name = "pb_Direction";
            this.pb_Direction.Size = new System.Drawing.Size(100, 100);
            this.pb_Direction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Direction.TabIndex = 2;
            this.pb_Direction.TabStop = false;
            this.pb_Direction.Paint += new System.Windows.Forms.PaintEventHandler(this.Pb_Direction_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Direccion";
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // level_progress_bar
            // 
            this.level_progress_bar.Location = new System.Drawing.Point(12, 50);
            this.level_progress_bar.Name = "level_progress_bar";
            this.level_progress_bar.Size = new System.Drawing.Size(320, 23);
            this.level_progress_bar.TabIndex = 4;
            // 
            // lbl_level_number
            // 
            this.lbl_level_number.AutoSize = true;
            this.lbl_level_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_level_number.Location = new System.Drawing.Point(15, 12);
            this.lbl_level_number.Name = "lbl_level_number";
            this.lbl_level_number.Size = new System.Drawing.Size(119, 31);
            this.lbl_level_number.TabIndex = 6;
            this.lbl_level_number.Text = "Nivel # 1";
            this.lbl_level_number.Visible = false;
            // 
            // nud_cols
            // 
            this.nud_cols.Location = new System.Drawing.Point(12, 54);
            this.nud_cols.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_cols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_cols.Name = "nud_cols";
            this.nud_cols.Size = new System.Drawing.Size(48, 20);
            this.nud_cols.TabIndex = 7;
            this.nud_cols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button1.Location = new System.Drawing.Point(83, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 46);
            this.button1.TabIndex = 8;
            this.button1.Text = "Jugar!!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // gb_game_play
            // 
            this.gb_game_play.Controls.Add(this.button1);
            this.gb_game_play.Controls.Add(this.nud_rows);
            this.gb_game_play.Controls.Add(this.nud_cols);
            this.gb_game_play.Location = new System.Drawing.Point(51, 144);
            this.gb_game_play.Name = "gb_game_play";
            this.gb_game_play.Size = new System.Drawing.Size(200, 100);
            this.gb_game_play.TabIndex = 9;
            this.gb_game_play.TabStop = false;
            this.gb_game_play.Text = "Caracteristicas del Juego";
            // 
            // tb_speed
            // 
            this.tb_speed.Location = new System.Drawing.Point(228, 633);
            this.tb_speed.Maximum = 21;
            this.tb_speed.Minimum = 2;
            this.tb_speed.Name = "tb_speed";
            this.tb_speed.Size = new System.Drawing.Size(104, 45);
            this.tb_speed.TabIndex = 10;
            this.tb_speed.Value = 2;
            this.tb_speed.ValueChanged += new System.EventHandler(this.Tb_speed_ValueChanged);
            // 
            // pb_pause_game
            // 
            this.pb_pause_game.Location = new System.Drawing.Point(228, 527);
            this.pb_pause_game.Name = "pb_pause_game";
            this.pb_pause_game.Size = new System.Drawing.Size(100, 100);
            this.pb_pause_game.TabIndex = 11;
            this.pb_pause_game.TabStop = false;
            this.pb_pause_game.Visible = false;
            this.pb_pause_game.Click += new System.EventHandler(this.Pb_pause_game_Click);
            this.pb_pause_game.Paint += new System.Windows.Forms.PaintEventHandler(this.Pb_pause_game_Paint);
            // 
            // Timer2
            // 
            this.Timer2.Interval = 1000;
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // lbl_points
            // 
            this.lbl_points.AutoSize = true;
            this.lbl_points.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_points.Location = new System.Drawing.Point(142, 463);
            this.lbl_points.Name = "lbl_points";
            this.lbl_points.Size = new System.Drawing.Size(29, 31);
            this.lbl_points.TabIndex = 12;
            this.lbl_points.Text = "0";
            this.lbl_points.Visible = false;
            // 
            // lbl_label_points
            // 
            this.lbl_label_points.AutoSize = true;
            this.lbl_label_points.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_label_points.Location = new System.Drawing.Point(15, 463);
            this.lbl_label_points.Name = "lbl_label_points";
            this.lbl_label_points.Size = new System.Drawing.Size(121, 31);
            this.lbl_label_points.TabIndex = 13;
            this.lbl_label_points.Text = "Puntaje :";
            // 
            // lbl_label_lifes
            // 
            this.lbl_label_lifes.AutoSize = true;
            this.lbl_label_lifes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_label_lifes.Location = new System.Drawing.Point(15, 422);
            this.lbl_label_lifes.Name = "lbl_label_lifes";
            this.lbl_label_lifes.Size = new System.Drawing.Size(97, 31);
            this.lbl_label_lifes.TabIndex = 15;
            this.lbl_label_lifes.Text = "Vidas :";
            // 
            // lbl_lifes
            // 
            this.lbl_lifes.AutoSize = true;
            this.lbl_lifes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lifes.Location = new System.Drawing.Point(142, 422);
            this.lbl_lifes.Name = "lbl_lifes";
            this.lbl_lifes.Size = new System.Drawing.Size(29, 31);
            this.lbl_lifes.TabIndex = 16;
            this.lbl_lifes.Text = "0";
            this.lbl_lifes.Visible = false;
            // 
            // btn_brown_color
            // 
            this.btn_brown_color.BackColor = System.Drawing.Color.Brown;
            this.btn_brown_color.Location = new System.Drawing.Point(311, 295);
            this.btn_brown_color.Name = "btn_brown_color";
            this.btn_brown_color.Size = new System.Drawing.Size(36, 23);
            this.btn_brown_color.TabIndex = 17;
            this.btn_brown_color.UseVisualStyleBackColor = false;
            this.btn_brown_color.Click += new System.EventHandler(this.Btn_brown_color_Click);
            // 
            // btn_deepsky_color
            // 
            this.btn_deepsky_color.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_deepsky_color.Location = new System.Drawing.Point(311, 324);
            this.btn_deepsky_color.Name = "btn_deepsky_color";
            this.btn_deepsky_color.Size = new System.Drawing.Size(36, 23);
            this.btn_deepsky_color.TabIndex = 18;
            this.btn_deepsky_color.UseVisualStyleBackColor = false;
            this.btn_deepsky_color.Click += new System.EventHandler(this.Btn_deepsky_color_Click);
            // 
            // btn_yellow_color
            // 
            this.btn_yellow_color.BackColor = System.Drawing.Color.Yellow;
            this.btn_yellow_color.Location = new System.Drawing.Point(311, 353);
            this.btn_yellow_color.Name = "btn_yellow_color";
            this.btn_yellow_color.Size = new System.Drawing.Size(37, 23);
            this.btn_yellow_color.TabIndex = 19;
            this.btn_yellow_color.UseVisualStyleBackColor = false;
            this.btn_yellow_color.Click += new System.EventHandler(this.Btn_yellow_color_Click);
            // 
            // btn_red_color
            // 
            this.btn_red_color.BackColor = System.Drawing.Color.Red;
            this.btn_red_color.Location = new System.Drawing.Point(311, 382);
            this.btn_red_color.Name = "btn_red_color";
            this.btn_red_color.Size = new System.Drawing.Size(37, 23);
            this.btn_red_color.TabIndex = 20;
            this.btn_red_color.UseVisualStyleBackColor = false;
            this.btn_red_color.Click += new System.EventHandler(this.Btn_red_color_Click);
            // 
            // btn_cyan_color
            // 
            this.btn_cyan_color.BackColor = System.Drawing.Color.Cyan;
            this.btn_cyan_color.Location = new System.Drawing.Point(311, 411);
            this.btn_cyan_color.Name = "btn_cyan_color";
            this.btn_cyan_color.Size = new System.Drawing.Size(37, 23);
            this.btn_cyan_color.TabIndex = 21;
            this.btn_cyan_color.UseVisualStyleBackColor = false;
            this.btn_cyan_color.Click += new System.EventHandler(this.Btn_cyan_color_Click);
            // 
            // btn_black_color
            // 
            this.btn_black_color.BackColor = System.Drawing.SystemColors.Desktop;
            this.btn_black_color.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btn_black_color.Location = new System.Drawing.Point(311, 266);
            this.btn_black_color.Name = "btn_black_color";
            this.btn_black_color.Size = new System.Drawing.Size(37, 23);
            this.btn_black_color.TabIndex = 22;
            this.btn_black_color.UseVisualStyleBackColor = false;
            this.btn_black_color.Click += new System.EventHandler(this.Btn_black_color_Click);
            // 
            // btn_darkviolet_color
            // 
            this.btn_darkviolet_color.BackColor = System.Drawing.Color.DarkViolet;
            this.btn_darkviolet_color.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btn_darkviolet_color.Location = new System.Drawing.Point(269, 266);
            this.btn_darkviolet_color.Name = "btn_darkviolet_color";
            this.btn_darkviolet_color.Size = new System.Drawing.Size(37, 23);
            this.btn_darkviolet_color.TabIndex = 28;
            this.btn_darkviolet_color.UseVisualStyleBackColor = false;
            this.btn_darkviolet_color.Click += new System.EventHandler(this.Btn_darkviolet_color_Click);
            // 
            // btn_gold_color
            // 
            this.btn_gold_color.BackColor = System.Drawing.Color.Gold;
            this.btn_gold_color.Location = new System.Drawing.Point(269, 411);
            this.btn_gold_color.Name = "btn_gold_color";
            this.btn_gold_color.Size = new System.Drawing.Size(37, 23);
            this.btn_gold_color.TabIndex = 27;
            this.btn_gold_color.UseVisualStyleBackColor = false;
            this.btn_gold_color.Click += new System.EventHandler(this.Btn_gold_color_Click);
            // 
            // btn_crimson_color
            // 
            this.btn_crimson_color.BackColor = System.Drawing.Color.Crimson;
            this.btn_crimson_color.Location = new System.Drawing.Point(269, 382);
            this.btn_crimson_color.Name = "btn_crimson_color";
            this.btn_crimson_color.Size = new System.Drawing.Size(37, 23);
            this.btn_crimson_color.TabIndex = 26;
            this.btn_crimson_color.UseVisualStyleBackColor = false;
            this.btn_crimson_color.Click += new System.EventHandler(this.Btn_crimson_color_Click);
            // 
            // btn_deeppink_color
            // 
            this.btn_deeppink_color.BackColor = System.Drawing.Color.DeepPink;
            this.btn_deeppink_color.Location = new System.Drawing.Point(269, 353);
            this.btn_deeppink_color.Name = "btn_deeppink_color";
            this.btn_deeppink_color.Size = new System.Drawing.Size(37, 23);
            this.btn_deeppink_color.TabIndex = 25;
            this.btn_deeppink_color.UseVisualStyleBackColor = false;
            this.btn_deeppink_color.Click += new System.EventHandler(this.Btn_deeppink_color_Click);
            // 
            // btn_fuchsia_color
            // 
            this.btn_fuchsia_color.BackColor = System.Drawing.Color.Fuchsia;
            this.btn_fuchsia_color.Location = new System.Drawing.Point(269, 324);
            this.btn_fuchsia_color.Name = "btn_fuchsia_color";
            this.btn_fuchsia_color.Size = new System.Drawing.Size(36, 23);
            this.btn_fuchsia_color.TabIndex = 24;
            this.btn_fuchsia_color.UseVisualStyleBackColor = false;
            this.btn_fuchsia_color.Click += new System.EventHandler(this.Btn_fuchsia_color_Click);
            // 
            // btn_springgreen_color
            // 
            this.btn_springgreen_color.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_springgreen_color.Location = new System.Drawing.Point(269, 295);
            this.btn_springgreen_color.Name = "btn_springgreen_color";
            this.btn_springgreen_color.Size = new System.Drawing.Size(36, 23);
            this.btn_springgreen_color.TabIndex = 23;
            this.btn_springgreen_color.UseVisualStyleBackColor = false;
            this.btn_springgreen_color.Click += new System.EventHandler(this.Btn_springgreen_color_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Fuchsia;
            this.button2.Location = new System.Drawing.Point(193, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 81);
            this.button2.TabIndex = 29;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.Location = new System.Drawing.Point(193, 353);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 81);
            this.button3.TabIndex = 30;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // respawn_timer
            // 
            this.respawn_timer.Interval = 500;
            this.respawn_timer.Tick += new System.EventHandler(this.Respawn_timer_Tick);
            // 
            // lbl_time_to_respawn
            // 
            this.lbl_time_to_respawn.AutoSize = true;
            this.lbl_time_to_respawn.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lbl_time_to_respawn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time_to_respawn.Location = new System.Drawing.Point(370, 42);
            this.lbl_time_to_respawn.Name = "lbl_time_to_respawn";
            this.lbl_time_to_respawn.Size = new System.Drawing.Size(29, 31);
            this.lbl_time_to_respawn.TabIndex = 32;
            this.lbl_time_to_respawn.Text = "3";
            this.lbl_time_to_respawn.Visible = false;
            // 
            // btn_make_big_camera
            // 
            this.btn_make_big_camera.Location = new System.Drawing.Point(269, 111);
            this.btn_make_big_camera.Name = "btn_make_big_camera";
            this.btn_make_big_camera.Size = new System.Drawing.Size(75, 64);
            this.btn_make_big_camera.TabIndex = 33;
            this.btn_make_big_camera.UseVisualStyleBackColor = true;
            this.btn_make_big_camera.Click += new System.EventHandler(this.Btn_make_big_camera_Click);
            // 
            // btn_make_little_camera
            // 
            this.btn_make_little_camera.Location = new System.Drawing.Point(269, 181);
            this.btn_make_little_camera.Name = "btn_make_little_camera";
            this.btn_make_little_camera.Size = new System.Drawing.Size(75, 64);
            this.btn_make_little_camera.TabIndex = 34;
            this.btn_make_little_camera.UseVisualStyleBackColor = true;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 697);
            this.Controls.Add(this.btn_make_little_camera);
            this.Controls.Add(this.btn_make_big_camera);
            this.Controls.Add(this.lbl_time_to_respawn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_darkviolet_color);
            this.Controls.Add(this.btn_gold_color);
            this.Controls.Add(this.btn_crimson_color);
            this.Controls.Add(this.btn_deeppink_color);
            this.Controls.Add(this.btn_fuchsia_color);
            this.Controls.Add(this.btn_springgreen_color);
            this.Controls.Add(this.btn_black_color);
            this.Controls.Add(this.btn_cyan_color);
            this.Controls.Add(this.btn_red_color);
            this.Controls.Add(this.btn_yellow_color);
            this.Controls.Add(this.btn_deepsky_color);
            this.Controls.Add(this.btn_brown_color);
            this.Controls.Add(this.lbl_lifes);
            this.Controls.Add(this.lbl_label_lifes);
            this.Controls.Add(this.lbl_label_points);
            this.Controls.Add(this.lbl_points);
            this.Controls.Add(this.pb_pause_game);
            this.Controls.Add(this.tb_speed);
            this.Controls.Add(this.gb_game_play);
            this.Controls.Add(this.lbl_level_number);
            this.Controls.Add(this.level_progress_bar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_Direction);
            this.Controls.Add(this.pb_field);
            this.Name = "Game";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pb_field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Direction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cols)).EndInit();
            this.gb_game_play.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tb_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pause_game)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_field;
        private System.Windows.Forms.NumericUpDown nud_rows;
        private System.Windows.Forms.PictureBox pb_Direction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ProgressBar level_progress_bar;
        private System.Windows.Forms.Label lbl_level_number;
        private System.Windows.Forms.NumericUpDown nud_cols;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gb_game_play;
        private System.Windows.Forms.TrackBar tb_speed;
        private System.Windows.Forms.PictureBox pb_pause_game;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.Label lbl_points;
        private System.Windows.Forms.Label lbl_label_points;
        private System.Windows.Forms.Label lbl_label_lifes;
        private System.Windows.Forms.Label lbl_lifes;
        private System.Windows.Forms.Button btn_brown_color;
        private System.Windows.Forms.Button btn_deepsky_color;
        private System.Windows.Forms.Button btn_yellow_color;
        private System.Windows.Forms.Button btn_red_color;
        private System.Windows.Forms.Button btn_cyan_color;
        private System.Windows.Forms.Button btn_black_color;
        private System.Windows.Forms.Button btn_darkviolet_color;
        private System.Windows.Forms.Button btn_gold_color;
        private System.Windows.Forms.Button btn_crimson_color;
        private System.Windows.Forms.Button btn_deeppink_color;
        private System.Windows.Forms.Button btn_fuchsia_color;
        private System.Windows.Forms.Button btn_springgreen_color;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer respawn_timer;
        private System.Windows.Forms.Label lbl_time_to_respawn;
        private System.Windows.Forms.Button btn_make_big_camera;
        private System.Windows.Forms.Button btn_make_little_camera;
    }
}

