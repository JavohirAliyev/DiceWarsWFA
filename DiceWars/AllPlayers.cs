using DiceWars.DAL;
using DiceWars.DAL.Entities;

namespace DiceWars;

public partial class AllPlayers : Form
{
    public AllPlayers()
    {
        InitializeComponent();
    }

    private void AllPlayers_Load(object sender, EventArgs e)
    {
        //loading parent form
        MdiParent = GameForms.GetForm<ParentForm>();
        LoadData();
    }

    public void LoadData()
    {
        //Linking the table to data grid view control
        dgv.DataSource = new PlayerManager().GetAll();

    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    private void btnSort_Click(object sender, EventArgs e)
    {
        //creating a condition where it checks if a user has selected an attribute to sort by
        if (cbxSort.SelectedIndex < 0)
            MessageBox.Show("Select an attribute to sort by");
        else
        {
            //generating conditions according to which the table is going to be sorted and filtered
            ByAttribute selectedAttribute = ByAttribute.Name;
            if (cbxSort.SelectedIndex == 0)
                selectedAttribute = ByAttribute.Name;
            else if (cbxSort.SelectedIndex == 1)
                selectedAttribute = ByAttribute.Champions;
            else if (cbxSort.SelectedIndex == 2)
                selectedAttribute = ByAttribute.Losers;

            dgv.DataSource = new PlayerManager().Sort(selectedAttribute);
        }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        //cheking if there is a search term
        if (string.IsNullOrWhiteSpace(tbxSearch.Text))
            MessageBox.Show("Provide the search term");
        else
        {
            //searchin if a substring (the searchterm) exists in the records
            dgv.DataSource = new PlayerManager().Search(ByAttribute.Name, tbxSearch.Text);
        }

    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        new EditingPlayers().CreateNewPlayer();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        //checking if a user has selected a player to edit
        if (dgv.SelectedRows.Count == 0)
            MessageBox.Show("Please select a player");
        else
        {
            //calling the function from PlayerManager to edit the selected player
            var c = (Player)dgv.SelectedRows[0].DataBoundItem;
            new EditingPlayers().UpdatePlayer(c);
        }

    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        //checking if a user has selected a player to edit
        if (dgv.SelectedRows.Count == 0)
            MessageBox.Show("Please select a player");
        else
        {
            //deleting the selected player
            var c = (Player)dgv.SelectedRows[0].DataBoundItem;
            new PlayerManager().Delete(c.Id);
            LoadData();

        }
    }
}
