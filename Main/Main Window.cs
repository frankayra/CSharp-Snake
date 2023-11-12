using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake;
using Editor_de_Niveles;

namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_game_editor_Click(object sender, EventArgs e)
        {
            Editor editor = new Editor();
            editor.ShowDialog();
        }

        private void Btn_default_game_Click(object sender, EventArgs e)
        {
            Game game = new Game(19, 19);
            game.ShowDialog();
        }
    }
}
