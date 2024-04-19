namespace PhoneLibrary.Forms;

public partial class fContacts : Form
{
    public fContacts()
    {
        InitializeComponent();
    }

    private void LoadData(string filter = "")
    {
        var query = @"SELECT DISTINCT Name,Mobile1,Mobile2,Phone1,Phone2,DateCreated,Id FROM tContacts 
LEFT JOIN tContactSubContacts tSub ON tSub.ParentContactId=tContacts.Id";
        if (!string.IsNullOrWhiteSpace(filter))
            query = string.Format(@"{1} WHERE 
Name LIKE N'%{0}%' OR 
Mobile1 LIKE N'%{0}%' OR 
Mobile2 LIKE N'%{0}%' OR 
Phone1 LIKE N'%{0}%' OR 
Phone2 LIKE N'%{0}%' OR 
tSub.Title LIKE N'%{0}%' OR 
tSub.Phone LIKE N'%{0}%'", filter, query);

        var dtList = DatabaseHelper.Instance.RunQueryWithDatatableResult(query);
        if (dtList == null)
            return;

        dgvContacts.DataSource = dtList;

        dgvContacts.Columns["Name"].HeaderText = "Name";
        dgvContacts.Columns["Mobile1"].HeaderText = "Mobile1";
        dgvContacts.Columns["Mobile2"].HeaderText = "Mobile2";
        dgvContacts.Columns["Phone1"].HeaderText = "Phone1";
        dgvContacts.Columns["Phone2"].HeaderText = "Phone2";
        dgvContacts.Columns["DateCreated"].HeaderText = "DateCreated";
        dgvContacts.Columns["Id"].Visible = false;
    }
    private void txtFilter_TextChanged(object sender, EventArgs e)
    {
        LoadData(txtFilter.Text);
    }

    private void fContacts_Shown(object sender, EventArgs e)
    {
        LoadData();
    }

    private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1)
            return;

        if (e.ColumnIndex != ColDelete.Index && e.ColumnIndex != ColEdit.Index)
            return;

        long.TryParse(dgvContacts.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out var contactId);

        if (e.ColumnIndex == ColDelete.Index)
        {
            Remove(contactId);
            return;
        }

        if (e.ColumnIndex == ColEdit.Index)
        {
            Edit(contactId);
            return;
        }
    }

    private void Remove(long contactId)
    {
        if (MessageBox.Show("Do you sure delete contact?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            return;

        try
        {
            DatabaseHelper.Instance.RunCommand($"DELETE FROM tContacts WHERE Id={contactId};DELETE FROM tContactSubContacts WHERE ParentContactId={contactId};");
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Edit(long contactId)
    {
        var f = new fNewPhoneContact();
        f.ContactId = contactId;
        f.ShowDialog();

        LoadData();
    }

    private void btnNewContact_Click(object sender, EventArgs e)
    {
        var f = new fNewPhoneContact();
        f.ShowDialog();
        LoadData();
    }
}
