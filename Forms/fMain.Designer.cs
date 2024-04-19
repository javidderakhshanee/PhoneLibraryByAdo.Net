namespace PhoneLibrary.Forms;

partial class fMain
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        menuStrip1 = new MenuStrip();
        menuToolStripMenuItem = new ToolStripMenuItem();
        newContactToolStripMenuItem = new ToolStripMenuItem();
        contactsToolStripMenuItem = new ToolStripMenuItem();
        exitToolStripMenuItem = new ToolStripMenuItem();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(800, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // menuToolStripMenuItem
        // 
        menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newContactToolStripMenuItem, contactsToolStripMenuItem, exitToolStripMenuItem });
        menuToolStripMenuItem.Name = "menuToolStripMenuItem";
        menuToolStripMenuItem.Size = new Size(50, 20);
        menuToolStripMenuItem.Text = "Menu";
        // 
        // newContactToolStripMenuItem
        // 
        newContactToolStripMenuItem.Name = "newContactToolStripMenuItem";
        newContactToolStripMenuItem.Size = new Size(180, 22);
        newContactToolStripMenuItem.Text = "New Contact";
        newContactToolStripMenuItem.Click += newContactToolStripMenuItem_Click;
        // 
        // contactsToolStripMenuItem
        // 
        contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
        contactsToolStripMenuItem.Size = new Size(180, 22);
        contactsToolStripMenuItem.Text = "Contacts";
        contactsToolStripMenuItem.Click += contactsToolStripMenuItem_Click;
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(180, 22);
        exitToolStripMenuItem.Text = "Exit";
        exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        // 
        // fMain
        // 
        AutoScaleDimensions = new SizeF(7F, 14F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 420);
        Controls.Add(menuStrip1);
        Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
        MainMenuStrip = menuStrip1;
        Name = "fMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Phone Library";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem menuToolStripMenuItem;
    private ToolStripMenuItem newContactToolStripMenuItem;
    private ToolStripMenuItem contactsToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
}