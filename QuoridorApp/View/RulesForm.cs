using System.Windows.Forms;

namespace QuoridorApp.View;

// class that represents the rules form that the user sees when he clicks on the rules icon in the home form, it contains the rules of the game
public partial class RulesForm : Form
{
    public RulesForm()
    {
        AddRules();
        AddHomeIcon();
        InitFrom();
    }

    // called when the user clicks on the home icon, it hides the rules form and shows the home form
    private void HomeIcon_Click(object sender, MouseEventArgs e)
    {
        this.Hide();
        HomeForm homeForm = new HomeForm();
        homeForm.ShowDialog();
        this.Close();
    }
}