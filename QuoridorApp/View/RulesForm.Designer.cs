using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static QuoridorApp.Constants;

namespace QuoridorApp.View;

partial class RulesForm
{
    private Label rulesLabel;
    private Label rules;
    private PictureBox homeIcon;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }
    private void AddHomeIcon()
    {
        homeIcon = new PictureBox();
        homeIcon.Location = new Point(773, 0);
        homeIcon.Name = "HomeAnimation";
        homeIcon.Size = new Size(50, 50);
        homeIcon.BackColor = System.Drawing.Color.Transparent;
        homeIcon.Image = ((Image)(Properties.Resources.homeIcon));
        homeIcon.SizeMode = PictureBoxSizeMode.StretchImage;
        ToolTip toolTip = new ToolTip();
        toolTip.SetToolTip(homeIcon, "Go back to the main menu");
        homeIcon.MouseClick += new MouseEventHandler(HomeIcon_Click);
        Controls.Add(homeIcon);
    }
    private void AddRules()
    {
        rulesLabel = new Label();
        rulesLabel.Location = new System.Drawing.Point(290, 0);
        rulesLabel.Name = "rulesLabel";
        rulesLabel.Text = "Rules";
        rulesLabel.BackColor = System.Drawing.Color.Transparent;
        rulesLabel.Font = new System.Drawing.Font(rulesLabel.Font.FontFamily, 35, System.Drawing.FontStyle.Bold);
        rulesLabel.Size = new System.Drawing.Size(250, 100);
        rulesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        Controls.Add(rulesLabel);
        
        // add the rules
        rules = new Label();
        rules.Location = new System.Drawing.Point(0, 100);
        rules.Name = "rules";
        rules.Text = QuoridorRules;
        rules.BackColor = System.Drawing.Color.Transparent;
        rules.Font = new System.Drawing.Font(rulesLabel.Font.FontFamily, 10, System.Drawing.FontStyle.Bold);
        rules.Size = new System.Drawing.Size(823, 549);
        rules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        Controls.Add(rules);
    }
    private void InitFrom()
    {
        this.SuspendLayout();
        //
        // RulesForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(823, 649);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.scrollBackground));
        this.Name = "RulesForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Quoridor";
        this.ResumeLayout(false);
    }
    #region Windows Form Designer generated code
    #endregion
}