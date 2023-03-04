using System.Windows.Forms;

namespace QuoridorApp.View;

public partial class RulesForm : Form
{
    public RulesForm()
    {
        AddRules();
        AddHomeIcon();
        InitializeComponent();
    }

    private void HomeIcon_Click(object sender, MouseEventArgs e)
    {
        this.Hide();
        HomeForm homeForm = new HomeForm();
        homeForm.ShowDialog();
        this.Close();
    }
}