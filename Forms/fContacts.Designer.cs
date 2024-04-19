namespace PhoneLibrary.Forms
{
    partial class fContacts
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
            txtFilter = new TextBox();
            dgvContacts = new DataGridView();
            ColDelete = new DataGridViewImageColumn();
            ColEdit = new DataGridViewImageColumn();
            btnNewContact = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "Filter";
            // 
            // txtFilter
            // 
            txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFilter.Location = new Point(45, 22);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(775, 23);
            txtFilter.TabIndex = 1;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // dgvContacts
            // 
            dgvContacts.AllowUserToAddRows = false;
            dgvContacts.AllowUserToDeleteRows = false;
            dgvContacts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvContacts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvContacts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContacts.Columns.AddRange(new DataGridViewColumn[] { ColDelete, ColEdit });
            dgvContacts.Location = new Point(6, 51);
            dgvContacts.Name = "dgvContacts";
            dgvContacts.ReadOnly = true;
            dgvContacts.RowHeadersVisible = false;
            dgvContacts.RowTemplate.Height = 25;
            dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContacts.Size = new Size(934, 522);
            dgvContacts.TabIndex = 2;
            dgvContacts.CellClick += dgvContacts_CellClick;
            // 
            // ColDelete
            // 
            ColDelete.HeaderText = "Delete";
            ColDelete.Image = Properties.Resources.remove16;
            ColDelete.Name = "ColDelete";
            ColDelete.ReadOnly = true;
            ColDelete.Width = 46;
            // 
            // ColEdit
            // 
            ColEdit.HeaderText = "Edit";
            ColEdit.Image = Properties.Resources.edit24;
            ColEdit.Name = "ColEdit";
            ColEdit.ReadOnly = true;
            ColEdit.Width = 33;
            // 
            // btnNewContact
            // 
            btnNewContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewContact.Location = new Point(826, 22);
            btnNewContact.Name = "btnNewContact";
            btnNewContact.Size = new Size(114, 23);
            btnNewContact.TabIndex = 7;
            btnNewContact.Text = "New Contact";
            btnNewContact.UseVisualStyleBackColor = true;
            btnNewContact.Click += btnNewContact_Click;
            // 
            // fContacts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 585);
            Controls.Add(btnNewContact);
            Controls.Add(dgvContacts);
            Controls.Add(txtFilter);
            Controls.Add(label1);
            Name = "fContacts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contacts";
            Shown += fContacts_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFilter;
        private DataGridView dgvContacts;
        private DataGridViewImageColumn ColDelete;
        private DataGridViewImageColumn ColEdit;
        private Button btnNewContact;
    }
}