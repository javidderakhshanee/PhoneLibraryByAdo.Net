namespace PhoneLibrary.Forms;

public partial class fMain : Form
{
    public fMain()
    {
        InitializeComponent();
    }

    private void newContactToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var f = new fNewPhoneContact();
        f.ShowDialog();
    }

    private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var f = new fContacts();
        f.ShowDialog();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.ExitThread();
    }
}
