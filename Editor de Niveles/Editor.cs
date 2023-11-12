using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Snake;


namespace Editor_de_Niveles
{
    public partial class Editor : Form
    {
        int[,] Field;
        bool started;
        public Editor()
        {
            Field = new int[4, 4];
            started = false;
            InitializeComponent();
        }
        private void AddColsAndRows(int rows, int cols)
        {
            int[,] Temporal_Field = new int[Field.GetLength(0) + rows, Field.GetLength(1) + cols];
            for (int q = 0; q < Temporal_Field.GetLength(0); q++)
            {
                for (int w = 0; w < Temporal_Field.GetLength(1); w++)
                {
                    Temporal_Field[q, w] = (q >= Field.GetLength(0) || w >= Field.GetLength(1)) ? 0 : Field[q, w];
                }
            }
            Field = Temporal_Field;
        }
        private void RemoveColsAndRows(int rows, int cols)
        {
            int[,] Temporal_Field =  Field.GetLength(0) > rows && Field.GetLength(1) > cols ? new int[Field.GetLength(0) - rows, Field.GetLength(1) - cols] : Field;
            for (int t = 0; t < Temporal_Field.GetLength(0); t++)
            {
                for (int y = 0; y < Temporal_Field.GetLength(1); y++)
                {
                    Temporal_Field[t, y] = Field[t, y];
                }
            }
            Field = Temporal_Field;
        }
        private void Pb_current_level_Paint(object sender, PaintEventArgs e)
        {
            if (!started) return;
            Graphics gr = e.Graphics;
            double r = (double)(pb_current_level.Width - 1) / Field.GetLength(0);
            double c = (double)(pb_current_level.Height - 1) / Field.GetLength(1);
            SolidBrush solidBrush = new SolidBrush(Color.Gray);
            for (int s = 0; s < Field.GetLength(0); s++)
            {
                for (int f = 0; f < Field.GetLength(1); f++)
                {
                    if (Field[s, f] < 0)
                        gr.FillRectangle(solidBrush, (float)(s * r), (float)(f * c), (float)r, (float)c);
                }
            }
            for (int q = 0; q <= Field.GetLength(0); q++)
            {
                gr.DrawLine(new Pen(Color.Black, 1), (float)(q * r), 0, (float)(q * r), pb_current_level.Width);
            }
            for (int p = 0; p <= Field.GetLength(1); p++)
            {
                gr.DrawLine(new Pen(Color.Black, 1), 0, (float)(p * c), pb_current_level.Height, (float)(p * c));
            }
        }

        private void Btn_load_txt_Click(object sender, EventArgs e)
        {
            ////Text files (*.txt)|*.txt |All files (*.*)|*.*por si acaso
            //if (ofd_select_level.ShowDialog() == DialogResult.OK)
            //    ReadTXT(ofd_select_level.FileName);
            //started = true;
            DialogResult d = ofd_select_level.ShowDialog();
            if(d == DialogResult.OK)
            {
                SerializableClass G = LoadPlay(ofd_select_level.FileName);
                Field = G.Field;
                nud_eggs_number.Value = G.Eggs_number;
                lbl_haga_click.Visible = true;
                started = true;
                pb_current_level.Refresh();
            }
        }
        private void Btn_save_level_Click(object sender, EventArgs e)
        {
            SavePlay("Snake Field " + new Random().Next(10000));
        }

        private void SavePlay(string nombre)
        {
            //string path = "C:\\Plotter\\" + nombre + ".MAT";
            //if (!File.Exists("C:\\Plotter"))
            //    Directory.CreateDirectory("C:\\Plotter");
            string path = "C:\\Snake Fields\\" + nombre + ".MAT";
            if (!File.Exists("C:\\Snake Fields"))
                Directory.CreateDirectory("C:\\Snake Fields");
            if (File.Exists(path))
                return;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, new SerializableClass(Field, (int)nud_eggs_number.Value));
            stream.Close();
        }

        public SerializableClass LoadPlay(string name)
        {
            //string path = "C:\\Plotter\\" + nombre;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read);
            var obj = (SerializableClass)formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }

        private void ReadTXT(string file_directory)
        {
            StreamReader reader = new StreamReader(file_directory);
            string line = reader.ReadLine();
            try
            {
                string[] dimensions = new string[] { "", "" };
                for (int r = 0, arrow = 0; r < line.Length; r++)
                {
                    if (char.IsDigit(line[r])) dimensions[arrow] += line[r];
                    else if(line[r] == ',')arrow++;
                }
                nud_rows.Value = int.Parse(dimensions[0]);
                nud_cols.Value = int.Parse(dimensions[1]);
                int[,] temp_field = new int[(int)nud_rows.Value, (int)nud_cols.Value];
                for (int e = 0; e < nud_rows.Value; e++)
                {
                    line = reader.ReadLine();
                    for (int w = 0; w < line.Length; w++)
                    {
                        if (line[w] == ' ') w++;
                        temp_field[e, w] = line[w] < 0 ? -1 : line[w] ;
                    }
                }
                Field = temp_field;
            }
            catch (Exception) { throw new InvalidDataException("Error en el Formato del archivo .txt"); }
        }

        private void Nud_rows_ValueChanged(object sender, EventArgs e)
        {
            if (nud_rows.Value - Field.GetLength(0) >= 0) AddColsAndRows((int)nud_rows.Value - Field.GetLength(0), 0);
            else RemoveColsAndRows(Field.GetLength(0) - (int)nud_rows.Value, 0);
            pb_current_level.Refresh();
        }

        private void Nud_cols_ValueChanged(object sender, EventArgs e)
        {
            if (nud_cols.Value - Field.GetLength(1) >= 0) AddColsAndRows(0, (int)nud_cols.Value - Field.GetLength(1));
            else RemoveColsAndRows(0, Field.GetLength(1) - (int)nud_cols.Value);
            pb_current_level.Refresh();
        }

        private void Pb_current_level_MouseClick(object sender, MouseEventArgs e)
        {
            double cell_width = (double)pb_current_level.Width / Field.GetLength(0);
            double cell_height = (double)pb_current_level.Height / Field.GetLength(1);
            int x = (int)(e.X  / cell_width);
            int y = (int)(e.Y  / cell_height) ;
            Field[x, y] = -1;
            pb_current_level.Refresh();
        }

        private void Btn_paint_field_Click(object sender, EventArgs e)
        {
            started = true;
            pb_current_level.Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!Game.IsValidField(Field))
            {
                MessageBox.Show("No es un Terreno Valido el introducido por usted");
                return;
            }
            Game Snake = new Game(Field, (int)nud_eggs_number.Value, GameMode.Edited);
            Snake.Button1_Click(new object(), new EventArgs());
            Snake.ShowDialog();
            Close();
        }

        private void Nud_eggs_number_ValueChanged(object sender, EventArgs e)
        {
            lbl_snake_weight_lvl10.Text = (10 * nud_eggs_number.Value * (nud_eggs_number.Value - 1)).ToString();
        }
    }
}
