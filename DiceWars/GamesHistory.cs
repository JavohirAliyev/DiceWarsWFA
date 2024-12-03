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
    public partial class GamesHistory : Form
    {
        public GamesHistory()
        {
            InitializeComponent();
        }

        private void GamesHistory_Load(object sender, EventArgs e)
        {
            //making the form child to the parent form
            MdiParent = GameForms.GetForm<ParentForm>();
            LoadData();
        }

        public void LoadData()
        {
            //linking the table to the data grid view
            dataGridView1.DataSource = new ClashManager().GetAll();
        }
    }
}
