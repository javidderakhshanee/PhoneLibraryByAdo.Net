namespace PhoneLibrary.Forms;

partial class fNewPhoneContact
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
        label1 = new Label();
        btnSave = new Button();
        txtName = new TextBox();
        label2 = new Label();
        txtMobile1 = new TextBox();
        label3 = new Label();
        txtMobile2 = new TextBox();
        label4 = new Label();
        label5 = new Label();
        txtPhone1 = new TextBox();
        txtPhone2 = new TextBox();
        groupBox1 = new GroupBox();
        dgvOtherPhones = new DataGridView();
        btnClose = new Button();
        ColRemove = new DataGridViewImageColumn();
        ColTitle = new DataGridViewTextBoxColumn();
        ColPhone = new DataGridViewTextBoxColumn();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOtherPhones).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(26, 23);
        label1.Name = "label1";
        label1.Size = new Size(38, 14);
        label1.TabIndex = 0;
        label1.Text = "Name";
        // 
        // btnSave
        // 
        btnSave.Location = new Point(267, 20);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(75, 40);
        btnSave.TabIndex = 6;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // txtName
        // 
        txtName.Location = new Point(70, 20);
        txtName.MaxLength = 50;
        txtName.Name = "txtName";
        txtName.PlaceholderText = "Please enter name";
        txtName.Size = new Size(171, 22);
        txtName.TabIndex = 0;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(26, 61);
        label2.Name = "label2";
        label2.Size = new Size(41, 14);
        label2.TabIndex = 0;
        label2.Text = "Mobile";
        // 
        // txtMobile1
        // 
        txtMobile1.Location = new Point(70, 58);
        txtMobile1.MaxLength = 11;
        txtMobile1.Name = "txtMobile1";
        txtMobile1.PlaceholderText = "Please enter mobile";
        txtMobile1.Size = new Size(171, 22);
        txtMobile1.TabIndex = 1;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(26, 98);
        label3.Name = "label3";
        label3.Size = new Size(41, 14);
        label3.TabIndex = 0;
        label3.Text = "Mobile";
        // 
        // txtMobile2
        // 
        txtMobile2.Location = new Point(70, 95);
        txtMobile2.MaxLength = 11;
        txtMobile2.Name = "txtMobile2";
        txtMobile2.PlaceholderText = "Please enter mobile";
        txtMobile2.Size = new Size(171, 22);
        txtMobile2.TabIndex = 2;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(26, 141);
        label4.Name = "label4";
        label4.Size = new Size(42, 14);
        label4.TabIndex = 0;
        label4.Text = "Phone";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(26, 178);
        label5.Name = "label5";
        label5.Size = new Size(42, 14);
        label5.TabIndex = 0;
        label5.Text = "Phone";
        // 
        // txtPhone1
        // 
        txtPhone1.Location = new Point(70, 138);
        txtPhone1.MaxLength = 11;
        txtPhone1.Name = "txtPhone1";
        txtPhone1.PlaceholderText = "Please enter phone";
        txtPhone1.Size = new Size(171, 22);
        txtPhone1.TabIndex = 3;
        // 
        // txtPhone2
        // 
        txtPhone2.Location = new Point(70, 175);
        txtPhone2.MaxLength = 11;
        txtPhone2.Name = "txtPhone2";
        txtPhone2.PlaceholderText = "Please enter phone";
        txtPhone2.Size = new Size(171, 22);
        txtPhone2.TabIndex = 4;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(dgvOtherPhones);
        groupBox1.Location = new Point(12, 228);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(362, 252);
        groupBox1.TabIndex = 5;
        groupBox1.TabStop = false;
        groupBox1.Text = "Other Departments";
        // 
        // dgvOtherPhones
        // 
        dgvOtherPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOtherPhones.Columns.AddRange(new DataGridViewColumn[] { ColRemove, ColTitle, ColPhone });
        dgvOtherPhones.EditMode = DataGridViewEditMode.EditOnEnter;
        dgvOtherPhones.Location = new Point(15, 21);
        dgvOtherPhones.Name = "dgvOtherPhones";
        dgvOtherPhones.RowHeadersVisible = false;
        dgvOtherPhones.RowTemplate.Height = 25;
        dgvOtherPhones.Size = new Size(341, 217);
        dgvOtherPhones.TabIndex = 0;
        dgvOtherPhones.CellClick += dgvOtherPhones_CellClick;
        // 
        // btnClose
        // 
        btnClose.Location = new Point(267, 66);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(75, 40);
        btnClose.TabIndex = 7;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        // 
        // ColRemove
        // 
        ColRemove.HeaderText = "Del";
        ColRemove.Image = Properties.Resources.remove16;
        ColRemove.Name = "ColRemove";
        // 
        // ColTitle
        // 
        ColTitle.HeaderText = "Title";
        ColTitle.Name = "ColTitle";
        ColTitle.Resizable = DataGridViewTriState.True;
        ColTitle.SortMode = DataGridViewColumnSortMode.NotSortable;
        // 
        // ColPhone
        // 
        ColPhone.HeaderText = "Phone";
        ColPhone.Name = "ColPhone";
        // 
        // fNewPhoneContact
        // 
        AutoScaleDimensions = new SizeF(7F, 14F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(393, 496);
        Controls.Add(groupBox1);
        Controls.Add(txtPhone2);
        Controls.Add(txtPhone1);
        Controls.Add(txtMobile2);
        Controls.Add(label5);
        Controls.Add(txtMobile1);
        Controls.Add(label3);
        Controls.Add(label4);
        Controls.Add(txtName);
        Controls.Add(label2);
        Controls.Add(btnClose);
        Controls.Add(btnSave);
        Controls.Add(label1);
        Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
        MaximizeBox = false;
        MaximumSize = new Size(409, 535);
        MinimizeBox = false;
        MinimumSize = new Size(409, 535);
        Name = "fNewPhoneContact";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "New Phone Contact";
        Shown += fNewPhoneContact_Shown;
        groupBox1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOtherPhones).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Button btnSave;
    private TextBox txtName;
    private Label label2;
    private TextBox txtMobile1;
    private Label label3;
    private TextBox txtMobile2;
    private Label label4;
    private Label label5;
    private TextBox txtPhone1;
    private TextBox txtPhone2;
    private GroupBox groupBox1;
    private DataGridView dgvOtherPhones;
    private Button btnClose;
    private DataGridViewImageColumn ColRemove;
    private DataGridViewTextBoxColumn ColTitle;
    private DataGridViewTextBoxColumn ColPhone;
}