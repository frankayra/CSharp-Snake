using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        int total_eggs;
        int temp_variable_timer2;
        int Level;
        int Points;
        List<Color> Colors;
        List<Snake> Snakess;
        int[,] Objects;
        int rows, cols;
        int snake_reserve;
        bool game_over;
        bool started;
        int headColor;
        public Form1(int c, int r, int Snake_x, int Snake_y)
        {
            temp_variable_timer2 = 0;
            Level = 0;
            Points = 0;
            rows = r;
            cols = c;
            Colors =        new List<Color>();
            Snakess =       new List<Snake>();
            Objects = new int[rows, cols];
            snake_reserve = 2;
            Colors.Add(Color.Blue);
            Colors.Add(Color.Blue);
            Colors.Add(Color.Blue);
            Colors.Add(Color.Cyan);
            Colors.Add(Color.Cyan);
            Colors.Add(Color.Cyan);
            Colors.Add(Color.Red);
            Colors.Add(Color.Red);
            Colors.Add(Color.Red);
            Colors.Add(Color.Green);
            Colors.Add(Color.Green);
            Colors.Add(Color.Green);
            Colors.Add(Color.Yellow);
            Colors.Add(Color.Yellow);
            Colors.Add(Color.Yellow);
            InitializeComponent();
        }
        private Direction HeadDirection { get { return Snakess[Snakess.Count - 1].GetDirection; } }
        public Form1() : this(19, 19, 4, 4) { }
        public int HeadColor
        {
            get { return headColor; }
            private set { headColor = value % Colors.Count; }
        }
        public bool Game_Over { get { return game_over; } }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Pb_field_Paint(object sender, PaintEventArgs e)
        {
            if (!started) return;
            Snake head = Snakess[Snakess.Count - 1];
            Graphics gr = e.Graphics;
            double r = (double)(pb_field.Height - 1) / rows;
            double c = (double)(pb_field.Width - 1) / cols;
            for (int w = 0; w < Objects.GetLength(0); w++)
            {
                for (int q = 0; q < Objects.GetLength(1); q++)
                {
                    if (Objects[w, q] > 0)
                    {
                        if (head.XY.X == w && head.XY.Y == q)
                        {
                            total_eggs--;
                            level_progress_bar.Increment(level_progress_bar.Step);
                            //level_progress_bar.Value += (100 / (Level ^ 2 + 3));
                            if (total_eggs == 0) { AssignEggs(); PlayGame(); }
                            snake_reserve += Objects[w, q];
                            Points += NextEgg(w, q);
                            Objects[w, q] = 0;
                        }
                        else gr.DrawImage(Image.FromFile("Egg.png"), (float)(w * r), (float)(q * c), (float)r, (float)c);
                    }
                    if (Objects[w, q] < 0)
                    {
                        if(head.XY.X == w && head.XY.Y == q)
                        {
                            game_over = true;
                            return;
                        }                        
                        gr.FillRectangle(new SolidBrush(Color.Gray), (float)(w * r), (float)(q * c), (float)r, (float)c);
                    }
                }
            }
            for (int i = Snakess.Count - 1; i >= 0; i--)
            {
                Snake a = Snakess[i];
                if (a.XY == head.XY && head != a)
                {
                    game_over = true;
                    return;
                }
                Brush snakebruch = new SolidBrush(Colors[a.color_pos]);
                gr.FillRectangle(snakebruch, (float)(a.XY.X * r), (float)(a.XY.Y * c), (float)r, (float)c);
            }
            //for (int k = 0; k <= rows; k++)
            //{
            //    for (int h = 0; h <= cols; h++)
            //    {
            //        gr.DrawLine(Pens.Black, 0, (float)(h * c), pb_field.Height, (float)(h * c));
            //        gr.DrawLine(Pens.Black, (float)(k * r), 0, (float)(k * r), pb_field.Width);
            //    }
            //}
        }
        private void AssignEggs()
        {
            total_eggs = (++Level) + 3;
            level_progress_bar.Step = (100 / (Level  + 3));
            tb_speed.Minimum++;
            level_progress_bar.Value = 0;
            for (int q = 0; q < total_eggs; q++)
            {
                Random a = new Random();
                Coordinates C = new Coordinates(a.Next(0, rows), a.Next(0, cols), Direction.DOWN, rows, cols);
                if (Objects[C.X, C.Y] != 0 || Snakess.Any(r => r.XY == C)) { q--; continue; }
                Objects[C.X, C.Y] = q + 1;
            }
        }
        private int NextEgg(int egg_x, int egg_y)
        {
            int max_x = Objects.GetLength(0);
            int max_y = Objects.GetLength(1);
            int[,] Temporal_field = new int[max_x, max_y];
            Temporal_field[egg_x, egg_y] = 1;
            bool has_been_adds = false;
            List<Coordinates> temp_coordinates = new List<Coordinates>();
            temp_coordinates.Add(new Coordinates(egg_x, egg_y, Direction.DOWN, max_x, max_y));
            do
            {
                has_been_adds = false;
                for (int w = 0; w < temp_coordinates.Count; w++)
                {
                    for (int t = 0; t < 4; t++)
                    {
                        Coordinates direction_coordinates = temp_coordinates[w].CoordinatesAt((Direction)t, 1);
                        int objects_cell = Objects[direction_coordinates.X, direction_coordinates.Y];
                        if (objects_cell > 0) return w + 1;                                                                                                          // ver si hay que devolver el huevo con menor valor o algo asi.
                        if (Temporal_field[direction_coordinates.X, direction_coordinates.Y] > 0 
                            ||  objects_cell < 0) continue;
                        Temporal_field[direction_coordinates.X, direction_coordinates.Y] = w + 1;
                        temp_coordinates.Add(new Coordinates(direction_coordinates.X, direction_coordinates.Y, Direction.DOWN, max_x, max_y));
                        has_been_adds = true;
                    }
                    temp_coordinates.RemoveAt(w);
                }
            } while (has_been_adds);
            return 0;
        }


        private void Pb_Direction_Paint(object sender, PaintEventArgs e)
        {
            if (!started) return;
            Graphics gr = e.Graphics;
            Brush br = new SolidBrush(Color.Green);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (game_over)
            {
                Timer.Stop();
            }
            Move_on();
            pb_field.Refresh();
            pb_Direction.Refresh();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }
        private void PauseGame()
        {
            Timer.Stop();
            gb_game_play.Visible = true;
            pb_pause_game.Visible = false;
            lbl_level_number.Visible = false;
        }
        private void PlayGame()
        {
            game_over = false;
            started = true;
            Timer.Start();
            Timer2.Start();
            gb_game_play.Visible = false;
            pb_pause_game.Visible = true;
            lbl_level_number.Text = "Pulsa Espacio para pausar";
            lbl_level_number.Visible = true;

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    Snakess[Snakess.Count - 1].ChangeDirection(Direction.UP);
                    break;
                case Keys.Left:
                    Snakess[Snakess.Count - 1].ChangeDirection(Direction.LEFT);
                    break;
                case Keys.Down:
                    Snakess[Snakess.Count - 1].ChangeDirection(Direction.DOWN);
                    break;
                case Keys.Right:
                    Snakess[Snakess.Count - 1].ChangeDirection(Direction.RIGHT);
                    break;
                case Keys.Space:
                    if (Timer.Enabled == false)
                    {
                        PlayGame();
                        break;
                    }
                    PauseGame();
                    break;
            }
            pb_Direction.Image = Image.FromFile("Direction." + HeadDirection + ".png");
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ActiveControl = null;
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            rows = (int)nud_rows.Value;
            cols = (int)nud_cols.Value;
            Objects = new int[rows, cols];
            List<Coordinates> C = FreeCoordinates(Objects);
            Snakess.Add(new Snake(C[C.Count - 1], 0));
            AssignEggs();
            PlayGame();
        }
        private static List<Coordinates> FreeCoordinates(int[,] ObstaclesAndEggs)
        {
            List<Coordinates> free_coordinates = new List<Coordinates>();
            for (int q = 0; q < ObstaclesAndEggs.GetLength(0); q++)
                for (int w = 0; w < ObstaclesAndEggs.GetLength(1); w++)
                    if (ObstaclesAndEggs[q, w] >= 0) free_coordinates.Add(new Coordinates(q, w, Direction.DOWN, ObstaclesAndEggs.GetLength(0), ObstaclesAndEggs.GetLength(1)));
            return free_coordinates;
        }
        public static bool IsValidField(int[,] ObstaclesAndEggs)
        {
            List<Coordinates> free_coordinates = FreeCoordinates(ObstaclesAndEggs);
            if (free_coordinates.Count == 0) return false;
            int[,] Temporal_Field = new int[ObstaclesAndEggs.GetLength(0), ObstaclesAndEggs.GetLength(1)];
            Array.Copy(ObstaclesAndEggs, Temporal_Field, ObstaclesAndEggs.Length);
            List<Coordinates> Currents_Coordinates = new List<Coordinates>();
            while(Currents_Coordinates.Count > 0)
            {
                Coordinates Current = free_coordinates[0];
                for (int d = 0; d < 4; d++)
                {
                    Coordinates Current_Direction_Coordinates = Current.CoordinatesAt((Direction)d, 1);
                    if (Temporal_Field[Current_Direction_Coordinates.X, Current_Direction_Coordinates.Y] >= 0)
                    {
                        Temporal_Field[Current_Direction_Coordinates.X, Current_Direction_Coordinates.Y] = -1;
                        Currents_Coordinates.Add(Current_Direction_Coordinates);
                    }
                }
                Currents_Coordinates.RemoveAt(0);
            }
            return FreeCoordinates(Temporal_Field).Count == 0;
        }
        
        public bool ValidCoordinate(int x, int y, int maxx, int maxy) => x > 0 && x<maxx && y> 0 && y<maxy;

        private void Pb_pause_game_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Brush br = new SolidBrush(Color.Black);
            gr.FillRectangle(br, (float)(pb_pause_game.Width) / 5, (float)pb_pause_game.Height / 5, (float)pb_pause_game.Width / 6, (4 * (float)pb_pause_game.Height) / 6);
            gr.FillRectangle(br, (float)(2 * pb_pause_game.Width) / 5, (float)pb_pause_game.Height / 5, (float)pb_pause_game.Width / 6, (4 * (float)pb_pause_game.Height) / 6);
        }

        private void Pb_pause_game_Click(object sender, EventArgs e)
        {
            PauseGame();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if(temp_variable_timer2 == 5)
            {
                lbl_level_number.Text = "Nivel # " + Level;
                Timer2.Stop();
                temp_variable_timer2 = 0;
            }
            temp_variable_timer2++;
        }

        private void Tb_speed_ValueChanged(object sender, EventArgs e)
        {
            Timer.Interval = 100 / (sender as TrackBar).Value - 1;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Move_on()
        {
            if (snake_reserve == 0)
                Snakess.RemoveAt(0);
            else snake_reserve--;

            Snakess.Add(new Snake(Snakess[Snakess.Count - 1].XY.CoordinatesAt(1), HeadColor++));
        }
    }
}
