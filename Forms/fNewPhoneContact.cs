using System.Data;

namespace PhoneLibrary.Forms;

public partial class fNewPhoneContact : Form
{
    public long ContactId { get; set; }

    public fNewPhoneContact()
    {
        InitializeComponent();
    }
    private void Edit(long contactId)
    {
        var dtContactInfo = DatabaseHelper.Instance.RunQueryWithDataSetResult($"SELECT Name,Mobile1,Mobile2,Phone1,Phone2 FROM tContacts WHERE Id={ContactId};SELECT Title,Phone FROM tContactSubContacts WHERE ParentContactId={contactId};");
        if (dtContactInfo == null)
            return;

        MapContactInfo(dtContactInfo.Tables[0]!);
        MapSubcontactsInfo(dtContactInfo.Tables[1]!);
    }

    private void MapSubcontactsInfo(DataTable dataTable)
    {
        foreach (DataRow dr in dataTable.Rows)
            dgvOtherPhones.Rows.Add(new object[] { null, dr["Title"], dr["Phone"] });
    }

    private void MapContactInfo(DataTable dataTable)
    {
        var row = dataTable.Rows[0];
        txtName.Text = row["Name"].ToString();
        txtMobile1.Text = row["Mobile1"].ToString();
        txtMobile2.Text = row["Mobile2"].ToString();
        txtPhone1.Text = row["Phone1"].ToString();
        txtPhone2.Text = row["Phone2"].ToString();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Validation();

            Save();

            ResetContentOfFormControls();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private void ResetContentOfFormControls()
    {
        ContactId = 0;
        txtName.Clear();
        txtMobile1.Clear();
        txtMobile2.Clear();
        txtPhone1.Clear();
        txtPhone2.Clear();
        dgvOtherPhones.Rows.Clear();

        txtName.Focus();
    }

    private void Save()
    {
        if (MessageBox.Show("Do you want to save data?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        var commandList = new List<string>();

        if (ContactId == 0)
            commandList.Add($"INSERT INTO tContacts(Name,Mobile1,Mobile2,Phone1,Phone2,DateCreated) VALUES(N'{txtName.Text.Trim()}',N'{txtMobile1.Text.Trim()}',N'{txtMobile2.Text.Trim()}',N'{txtPhone1.Text.Trim()}',N'{txtPhone2.Text.Trim()}','{DateTime.Now.ToShortDateString()}');");
        else
        {
            commandList.Add($"UPDATE tContacts SET Name=N'{txtName.Text.Trim()}', Mobile1=N'{txtMobile1.Text.Trim()}', Mobile2=N'{txtMobile2.Text.Trim()}', Phone1=N'{txtPhone1.Text.Trim()}', Phone2=N'{txtPhone2.Text.Trim()}' WHERE Id={ContactId};");
            commandList.Add($"DELETE FROM tContactSubContacts WHERE ParentContactId={ContactId};");
        }

        foreach (DataGridViewRow dr in dgvOtherPhones.Rows)
            if (!dr.IsNewRow)
                commandList.Add($"INSERT INTO tContactSubContacts(Title,Phone,ParentContactId) VALUES(N'{dr.Cells[nameof(ColTitle)].Value}',N'{dr.Cells[nameof(ColPhone)].Value}',{(ContactId > 0 ? $"{ContactId}" : "@@IDENTITY")});");

        DatabaseHelper.Instance.RunTransaction(commandList);

        MessageBox.Show("Save data successed!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void Validation()
    {
        if (txtName.Text.Trim().Length == 0)
            throw new Exception("Please enter name");

        if (txtMobile1.Text.Trim().Length == 0 &&
            txtMobile2.Text.Trim().Length == 0 &&
            txtPhone1.Text.Trim().Length == 0 &&
            txtPhone2.Text.Trim().Length == 0 &&
            dgvOtherPhones.Rows.GetRowCount(DataGridViewElementStates.Visible) == 0
            )
            throw new Exception("Please enter mobiles or phones or other departments!");
    }

    private void fNewPhoneContact_Shown(object sender, EventArgs e)
    {
        if (ContactId > 0)
            Edit(ContactId);
    }

    private void dgvOtherPhones_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1)
            return;

        if (e.ColumnIndex != ColRemove.Index)
            return;

        dgvOtherPhones.Rows.RemoveAt(e.RowIndex);
    }
}
