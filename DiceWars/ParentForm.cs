using DiceWars.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceWars
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
         
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exiting the application
            Application.Exit();
        }

        private void allClahesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showing the Game History form when the button is clicked
            GameForms.GetForm<GamesHistory>().Show();
        }

        private void allPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showing the All Players form when the button is clicked
            GameForms.GetForm<AllPlayers>().Show();
        }

        private void newPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showing the Edit Player form when the button is clicked
            new EditingPlayers().CreateNewPlayer();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showing the Game  form when the button is clicked
            GameForms.GetForm<Game>().Show();
        }
    }
}
