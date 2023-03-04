using System.Windows.Forms;
using QuoridorApp.Controller;

namespace QuoridorApp.View;

public partial class HomeForm : Form
{
    private readonly GameForm _gameForm;
    public HomeForm()
    {
        _gameForm = new GameForm();
        GameFormController.GetInstance().InitializeGameFormController(_gameForm);
        AddQuoridorLabel();
        AddStartGameButton();
        AddRulesIcon();
        InitializeComponent();
    }

    private void StartGameButton_Click(object sender, MouseEventArgs e)
    {
        this.Hide();
        _gameForm.ShowDialog();
        this.Close();
    }

    private void rulesIcon_Click(object sender, MouseEventArgs e)
    {
        this.Hide();
        RulesForm rulesForm = new RulesForm();
        rulesForm.ShowDialog();
        this.Close();
    }
}