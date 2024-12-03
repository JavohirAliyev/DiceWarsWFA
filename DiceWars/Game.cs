using DiceWars.DAL;
using DiceWars.DAL.Entities;
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
    public partial class Game : Form
    {
        public Clash Clash {  get; set; }
        public Player Clayer { get; set; }
        public FormMode Mode { get; set; }


        
        public Game()
        {
            InitializeComponent();
        }

        private void GetUserInputt()
        {
            //getting the player IDs from comboboxes and setting the Date to "now"
            Clash.Player1 = (Player)cbxPlayer1.SelectedItem;
            Clash.Player2 = (Player)cbxPlayer2.SelectedItem;
            Clash.Date = DateTime.Now;
        }
        

        private void Game_Load(object sender, EventArgs e)
        {
            //Getting only players with activated PVP. No players are shown with FALSE set as their "isPvPEnabled"

            cbxPlayer1.DataSource = new PlayerManager().GetAll().Where(c => c.IsPvPEnabled == true).ToList();
            cbxPlayer2.DataSource = new PlayerManager().GetAll().Where(c => c.IsPvPEnabled == true).ToList();
        }
        private void btnRoll_Click(object sender, EventArgs e)
        {
            //Checking if two different users are selected
            if (cbxPlayer1.SelectedIndex != cbxPlayer2.SelectedIndex)
            {
                //generating random numbers
            Clash = new Clash();
            Random random = new Random();
            label3.Text = random.Next(1, 7).ToString();
            label4.Text = random.Next(1, 7).ToString();
            label5.Text = random.Next(1, 7).ToString();
            label6.Text = random.Next(1, 7).ToString();
            label7.Text = random.Next(1, 7).ToString();
            label8.Text = random.Next(1, 7).ToString();
            label9.Text = random.Next(1, 7).ToString();
            label10.Text = random.Next(1, 7).ToString();
            label11.Text = random.Next(1, 7).ToString();
            label12.Text = random.Next(1, 7).ToString();

                //showing the random numbers on 5 Labels
                var num1 = Convert.ToInt16(label3.Text);
                var num2 = Convert.ToInt16(label4.Text);
                var num3 = Convert.ToInt16(label5.Text);
                var num4 = Convert.ToInt16(label6.Text);
                var num5 = Convert.ToInt16(label7.Text);
                var num6 = Convert.ToInt16(label8.Text);
                var num7 = Convert.ToInt16(label9.Text);
                var num8 = Convert.ToInt16(label10.Text);
                var num9 = Convert.ToInt16(label11.Text);
                var num10 = Convert.ToInt16(label12.Text);

                var editPlayer = new PlayerManager();
                //calculating the results and announcing the winner
                if ((num1 + num2 + num3 + num4 + num5) > (num6 + num7 + num8 + num9 + num10))
                {
                    
                    label13.Text = "Player 1 wins!";
                    Clash.Outcome = 1;

                } else if ((num1 + num2 + num3 + num4 + num5) < (num6 + num7 + num8 + num9 + num10))
                {
                    label13.Text = "Player 2 wins!";
                    Clash.Outcome = 2;
                } else
                {
                    label13.Text = "Tie!";
                    Clash.Outcome = 0;
                }


                //saving the changes into the database
                GetUserInputt();
                var manager = new ClashManager();
                manager.Create(Clash);
                GameForms.GetForm<GamesHistory>().LoadData();

            }
            else
            {
                MessageBox.Show("Please, choose two different players");
            }

        }
    }
}
