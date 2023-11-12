using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Snake
{

    public partial class Game : Form
    {
        
        bool shift_pressed;
        double time_of_oportunity;
        int oportunities;
        Direction Turning_direction;
        GameMode game_mode;
        int total_eggs;
        int partial_eggs;
        int temp_variable_timer2;
        int Level;
        int Points;
        List<Color> Colors;
        List<Snake> Snakess;
        World<Objec, CircularCoordinates> Objects;
        int rows, cols;
        int snake_reserve;
        bool game_over;
        bool started;
        int headColor;
        public Game(int r, int c):this(new int[r, c], 3, GameMode.Default) { }
        private Direction HeadDirection { get { return Snakess[Snakess.Count - 1].GetDirection; } }
        public Game() : this(new int[20, 20], 3, GameMode.Default) { }        
        public Game(int[,] Objects, int total_eggs, GameMode mode)
        {
            game_mode = mode;
            oportunities = 0;
            time_of_oportunity = 3;
            this.total_eggs = total_eggs;
            temp_variable_timer2 = 0;
            Level = 0;
            Points = 0;
            rows = Objects.GetLength(0);
            cols = Objects.GetLength(1);
            Colors = new List<Color>();
            int camera_length = Math.Min(Objects.GetLength(0), Objects.GetLength(1));
            this.Objects = new World<Objec, CircularCoordinates>(FieldParser(Objects), camera_length, camera_length);
            Snakess = new List<Snake>();
            Colors.Add(Color.Green);
            Snakess.Add(new Snake(VoidCoordinates(this.Objects.Matrix), 0));
            snake_reserve = 1;
            InitializeComponent();
        }
        public int HeadColor
        {
            get { return headColor; }
            private set { headColor = value > 0 ? value % Colors.Count : (value + Colors.Count) % Colors.Count; }
        }

        public void CleanWorld(Objec[,] Objects)
        {
            for (int e = 0; e < Objects.GetLength(0); e++)
            {
                for (int d = 0; d < Objects.GetLength(1); d++)
                {
                    Objects[e, d] = new VoidCell();
                }
            }
        }
        public void CleanWorld() => CleanWorld(Objects.Matrix);

        public bool Game_Over { get { return game_over; } }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Pb_field_Paint(object sender, PaintEventArgs e)
        {
            if (!started) return;
            if (game_over) return;
            lbl_points.Text = "" + Points;
            lbl_lifes.Text = "" + oportunities;
            Snake head = Snakess[Snakess.Count - 1];
            Graphics gr = e.Graphics;
            FontFamily ff = FontFamily.GetFamilies(gr)[0];
            double r = (double)(pb_field.Height - 1) / Objects.CameraX;
            double c = (double)(pb_field.Width - 1) / Objects.CameraY;
            Objec[,] Matrix = Objects.CameraMatrix(Snakess[Snakess.Count - 1].XY);
            CircularCoordinates left_up_corner = (CircularCoordinates)head.XY.CoordinateAt(-(Matrix.GetLength(0) / 2), -(Matrix.GetLength(1) / 2));
            for (int w = 0; w < Matrix.GetLength(0); w++)
            {
                for (int q = 0; q < Matrix.GetLength(1); q++)
                {
                    CircularCoordinates real_coordinate = (CircularCoordinates)Objects.TranslateCoordinate(head.XY, w, q);
                    if (Matrix[w, q] is Egg)
                    {
                        if (head.XY.X == real_coordinate.X && head.XY.Y == real_coordinate.Y)
                        {
                            partial_eggs--;
                            level_progress_bar.Increment(level_progress_bar.Step);
                            snake_reserve += Matrix[w, q].Value;
                            Objects[real_coordinate.X, real_coordinate.Y] = new VoidCell();
                            if (partial_eggs == 0)
                            {
                                AssignEggs();
                                if (Level % 4 == 0)
                                {
                                    if(game_mode == GameMode.Default) AssingObstacles();
                                    oportunities++;
                                }
                                if(Level % 10 == 0)
                                {
                                    time_of_oportunity = 10;
                                    respawn_timer.Start();
                                }
                                PlayGame();
                            }
                            else Points += NextEgg(w, q) * 100;
                        }
                        else
                        {
                            gr.DrawImage(Image.FromFile("Egg.png"), (float)(w * r), (float)(q * c), (float)r, (float)c);
                            gr.DrawString("" + Matrix[w, q].Value, new Font(ff, (float)((3 *Math.Min(r, c)) / 4)), new SolidBrush(Color.Black), new RectangleF((float)(w * r), (float)(q * c), (float)r, (float)c), StringFormat.GenericDefault);
                        }
                    }
                    if (Matrix[w, q] is Obstacle)
                    {
                        if(head.XY.X == real_coordinate.X && head.XY.Y == real_coordinate.Y && !respawn_timer.Enabled)
                        {
                            if (oportunities == 0)
                            {
                                game_over = true;
                                Reset();
                                return;
                            }
                            respawn_timer.Start();
                            oportunities--;
                        }                        
                        gr.FillRectangle(new SolidBrush(Color.Gray), (float)(w * r), (float)(q * c), (float)r, (float)c);
                    }
                    /* 
                     Snake Verification
                    */
                    for (int i = Snakess.Count - 1; i >= 0; i--)
                    {
                        Snake a = Snakess[i];
                        if ((CircularCoordinates)left_up_corner.CoordinateAt(w, q) != a.XY) continue;
                        if (a.XY == head.XY && head != a && !respawn_timer.Enabled)
                        {
                            if (oportunities == 0)
                            {
                                game_over = true;
                                Reset();
                                return;
                            }
                            respawn_timer.Start();
                            oportunities--;
                        }
                        Brush snakebruch = new SolidBrush(Colors[a.color_pos >= Colors.Count ? 0 : a.color_pos]);
                        gr.FillRectangle(snakebruch, (float)(w * r), (float)(q * c), (float)r, (float)c);
                    }
                    /*
                    End Snake Verification
                    */
                }
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
            Level++;
            partial_eggs = total_eggs;
            level_progress_bar.Step = (100 / total_eggs);
            if(tb_speed.Minimum != tb_speed.Maximum)
            {
                if (tb_speed.Value <= tb_speed.Minimum && tb_speed.Value < tb_speed.Maximum) tb_speed.Value++;
                tb_speed.Minimum++;
            }
            level_progress_bar.Value = 0;
            for (int q = 0; q < total_eggs; q++)
            {
                Random a = new Random();
                CircularCoordinates C = new CircularCoordinates(a.Next(0, rows), a.Next(0, cols), Direction.DOWN, rows, cols);
                if (Objects[C.X, C.Y].Value != 0 || Snakess.Any(r => r.XY == C)) { q--; continue; }
                Objects[C.X, C.Y] = new Egg(q + 1);
            }
        }
        private int NextEgg(int egg_x, int egg_y)
        {
            /* neww  */
            int[,] TemporalField = new int[Objects.X, Objects.Y];
            Queue<Tuple<CircularCoordinates, int>> cola = new Queue<Tuple<CircularCoordinates, int>>();
            cola.Enqueue(new Tuple<CircularCoordinates, int>(new CircularCoordinates(egg_x, egg_y, Direction.DOWN, Objects.X, Objects.Y), 1));
            List<CircularCoordinates> same_distances_eggs = new List<CircularCoordinates>();
            int temporal_distance_eggs = 0;
            bool has_been_eggs_founded = false;
            while (cola.Count != 0)
            {
                Tuple<CircularCoordinates, int> current = cola.Dequeue();
                if (has_been_eggs_founded && current.Item2 >= temporal_distance_eggs) continue;
                for (int r = 0; r < 4; r++)
                {
                    CircularCoordinates direction_Coordinates = current.Item1.CoordinatesAt((Direction)r, 1);
                    int current_value = Objects[direction_Coordinates.X, direction_Coordinates.Y].Value;
                    if (current_value < 0 || TemporalField[direction_Coordinates.X, direction_Coordinates.Y] > 0) continue;
                    if (current_value > 0)
                    {
                        same_distances_eggs.Add(direction_Coordinates);
                        has_been_eggs_founded = true;
                        temporal_distance_eggs = current.Item2;
                        TemporalField[direction_Coordinates.X, direction_Coordinates.Y] = current.Item2 + 1;
                        continue;
                    }
                    TemporalField[direction_Coordinates.X, direction_Coordinates.Y] = current.Item2 + 1;
                    if (!has_been_eggs_founded)
                    {
                        cola.Enqueue(new Tuple<CircularCoordinates, int>(direction_Coordinates, current.Item2 + 1));
                        TemporalField[direction_Coordinates.X, direction_Coordinates.Y] = current.Item2 + 1;
                    }
                }
            }
            int a = 0;
            for (int i = 0; i < same_distances_eggs.Count; i++)
            {
                int temp_value = Objects[same_distances_eggs[i].X, same_distances_eggs[i].Y].Value;
                if (a < temp_value) a = temp_value;
            }

            return a;
            /* neww  */

        }


        public void Reset()
        {
            Points = 0;
            Snakess.Clear();
            Level = 1;
            tb_speed.Minimum = 2;
            tb_speed.Value = tb_speed.Minimum;
            lbl_level_number.Text = "Level # " + Level;
            try
            {
                Snakess.Add(new Snake(VoidCoordinates(Objects.Matrix), ++HeadColor));
                snake_reserve = 1;
                game_over = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Imposible posicionar nuevamente la serpiente");
            }

        }
        private void AssingObstacles()
        {
            int a = 0;
            for (int e = 0; e < Objects.X; e++)
            {
                for (int q = 0; q < Objects.Y; q++)
                {
                    if (Objects[e, q].Value > 0) a++;
                }
            }
            if (a < total_eggs)
            {
                MessageBox.Show("Los huevos no se pueden reubicar en el terreno");
                game_over = true;
                return;
            }
            Random r = new Random();
            for (int z = 3; z > 0; z--)
            {
                int x = r.Next(0, Objects.X);
                int y = r.Next(0, Objects.Y);
                if (Objects[x, y].Value == 0 && !(Snakess.Any(o => o.XY.X == x && o.XY.Y == y))) Objects[x, y] = new Obstacle();
                else z++;
            }
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
                return;
            }
            Snakess[Snakess.Count - 1].ChangeDirection(Turning_direction);
            Turning_direction = HeadDirection;
            Move_on();
            pb_field.Refresh();
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
        public void PlayGame()
        {
            game_over = false;
            if(!started)
            {
                started = true;
                lbl_points.Visible = true;
                lbl_lifes.Visible = true;
            }
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
                case Keys.ShiftKey:
                    shift_pressed = !shift_pressed;
                    break;
                case Keys.Up:
                    if(shift_pressed)
                    {
                        if (tb_speed.Value < tb_speed.Maximum) tb_speed.Value++;
                        break;
                    }
                    Turning_direction = Direction.UP;
                    break;
                case Keys.Left:
                    Turning_direction = Direction.LEFT;
                    break;
                case Keys.Down:
                    if (shift_pressed)
                    {
                        if (tb_speed.Value > tb_speed.Minimum) tb_speed.Value--;
                        break;
                    }
                    Turning_direction = Direction.DOWN;
                    break;
                case Keys.Right:
                    Turning_direction = Direction.RIGHT;
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
            pb_Direction.Image = Image.FromFile("Direction." + Turning_direction + ".png");
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ActiveControl = null;
        }
        
        public void Button1_Click(object sender, EventArgs e)
        {
            switch (game_mode)
            {
                case GameMode.Default:
                    rows = (int)nud_rows.Value;
                    cols = (int)nud_cols.Value;
                    int camera_range = Math.Min(rows, cols);
                    Objects = new World<Objec, CircularCoordinates>(FieldParser(new int[rows, cols]), camera_range, camera_range);
                    AssingObstacles();
                    break;
            }
            Snakess.Clear();
            Snakess.Add(new Snake(VoidCoordinates(this.Objects.Matrix), 0));
            AssignEggs();
            PlayGame();
        }
        private static List<CircularCoordinates> FreeCoordinates(int[,] ObstaclesAndEggs)
        {
            List<CircularCoordinates> free_coordinates = new List<CircularCoordinates>();
            for (int q = 0; q < ObstaclesAndEggs.GetLength(0); q++)
                for (int w = 0; w < ObstaclesAndEggs.GetLength(1); w++)
                    if (ObstaclesAndEggs[q, w] >= 0) free_coordinates.Add(new CircularCoordinates(q, w, Direction.DOWN, ObstaclesAndEggs.GetLength(0), ObstaclesAndEggs.GetLength(1)));
            return free_coordinates;
        }
        private static CircularCoordinates VoidCoordinates(Objec[,] ObstaclesAndEggs)
        {
            for (int r = 0; r < ObstaclesAndEggs.GetLength(0); r++)
            {
                for (int d = 0; d < ObstaclesAndEggs.GetLength(1); d++)
                {
                    if (!(ObstaclesAndEggs[r, d] is Obstacle)) return new CircularCoordinates(r, d, Direction.DOWN, ObstaclesAndEggs.GetLength(0), ObstaclesAndEggs.GetLength(1));
                }
            }
            return new CircularCoordinates(-1, -1, Direction.DOWN, -1, -1);
        }
        public static bool IsValidField(int[,] ObstaclesAndEggs)
        {
            try
            {
                Objec[,] Temporal_Field = new Objec[ObstaclesAndEggs.GetLength(0), ObstaclesAndEggs.GetLength(1)];
                Array.Copy(FieldParser(ObstaclesAndEggs), Temporal_Field, Temporal_Field.Length);
                Queue<CircularCoordinates> TemporalCoordinates = new Queue<CircularCoordinates>();
                CircularCoordinates void_coordinates = VoidCoordinates(Temporal_Field);
                Temporal_Field[void_coordinates.X, void_coordinates.Y] = new Obstacle();
                TemporalCoordinates.Enqueue(void_coordinates);
                while (TemporalCoordinates.Count != 0)
                {
                    CircularCoordinates current = TemporalCoordinates.Dequeue();
                    for (int q = 0; q < 4; q++)
                    {
                        CircularCoordinates direction_coordinates = current.CoordinatesAt((Direction)q, 1);
                        if (Temporal_Field[direction_coordinates.X, direction_coordinates.Y].Value >= 0)
                        {
                            TemporalCoordinates.Enqueue(direction_coordinates);
                            Temporal_Field[direction_coordinates.X, direction_coordinates.Y] = new Obstacle();
                        }
                    }
                }
                try { CircularCoordinates void_coordinate = VoidCoordinates(Temporal_Field); }
                catch { return true; }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        public static Objec[,] FieldParser(int[,] int_world)
        {
            Objec[,] New_Field = new Objec[int_world.GetLength(0), int_world.GetLength(1)];
            for (int e = 0; e < New_Field.GetLength(0); e++)
                for (int r = 0; r < New_Field.GetLength(1); r++)
                {
                    New_Field[e, r] = int_world[e, r] < 0 ? new Obstacle() :
                        int_world[e, r] == 0 ? new VoidCell() :
                        new Objec(int_world[e, r]);
                }
            return New_Field;
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
            Timer.Interval = 1000 / (sender as TrackBar).Value - 1;
        }

        private void Btn_black_color_Click(object sender, EventArgs e) => Colors.Add(Color.Black);
        private void Btn_brown_color_Click(object sender, EventArgs e) => Colors.Add(Color.Brown);
        private void Btn_deepsky_color_Click(object sender, EventArgs e) => Colors.Add(Color.DeepSkyBlue);
        private void Btn_yellow_color_Click(object sender, EventArgs e) => Colors.Add(Color.Yellow);
        private void Btn_red_color_Click(object sender, EventArgs e) => Colors.Add(Color.Red);
        private void Btn_cyan_color_Click(object sender, EventArgs e) => Colors.Add(Color.Cyan);
        private void Btn_darkviolet_color_Click(object sender, EventArgs e) => Colors.Add(Color.DarkViolet);
        private void Btn_springgreen_color_Click(object sender, EventArgs e) => Colors.Add(Color.SpringGreen);
        private void Btn_fuchsia_color_Click(object sender, EventArgs e) => Colors.Add(Color.Fuchsia);
        private void Btn_deeppink_color_Click(object sender, EventArgs e) => Colors.Add(Color.DeepPink);
        private void Btn_crimson_color_Click(object sender, EventArgs e) => Colors.Add(Color.Crimson);
        private void Btn_gold_color_Click(object sender, EventArgs e) => Colors.Add(Color.Gold);

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Colors.Count > 0) Colors.Clear();
            Colors.AddRange(new Color[] { Color.Pink, Color.HotPink, Color.DeepPink, Color.Fuchsia, Color.Magenta });
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Colors.Count > 0) Colors.Clear();
            Colors.AddRange(new Color[] { Color.Lime, Color.LimeGreen, Color.ForestGreen, Color.MediumSpringGreen, Color.LightGreen });
        }

        private void Respawn_timer_Tick(object sender, EventArgs e)
        {
            if (time_of_oportunity == 0)
            {
                respawn_timer.Stop();
                time_of_oportunity = 3;
                lbl_time_to_respawn.Visible = false;
                lbl_time_to_respawn.Text = "" + 3;
                return;
            }
            lbl_time_to_respawn.Visible = true;
            time_of_oportunity -= 0.5;
            lbl_time_to_respawn.Text = "" + time_of_oportunity;
        }

        private void Btn_make_big_camera_Click(object sender, EventArgs e)
        {
        }

        private void Move_on()
        {
            if (snake_reserve == 0)
                Snakess.RemoveAt(0);
            else
            {
                snake_reserve--;
            }
            Snakess.Add(new Snake(Snakess[Snakess.Count - 1].XY.CoordinatesAt(1), HeadColor++));
        }
    }
}
