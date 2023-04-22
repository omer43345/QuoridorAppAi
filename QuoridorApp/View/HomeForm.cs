using System.Windows.Forms;
using QuoridorApp.Controller;

namespace QuoridorApp.View;

// class that represents the home form that the user sees when he opens the program
public partial class HomeForm : Form
{
    private readonly GameForm _gameForm;
    
    // initialize the form by adding the components, creating a new game form and initializing the game form controller
    public HomeForm()
    {
        _gameForm = new GameForm();
        GameFormController.GetInstance().InitializeGameFormController(_gameForm);
        AddQuoridorLabel();
        AddStartGameButton();
        AddRulesIcon();
        InitForm();
    }

    // called when the user clicks on the start game button, it hides the home form and shows the game form
    private void StartGameButton_Click(object sender, MouseEventArgs e)
    {
        this.Hide();
        _gameForm.ShowDialog();
        this.Close();
    }

    // called when the user clicks on the rules icon, it hides the home form and shows the rules form
    private void rulesIcon_Click(object sender, MouseEventArgs e)
    {
        this.Hide();
        RulesForm rulesForm = new RulesForm();
        rulesForm.ShowDialog();
        this.Close();
    }
}