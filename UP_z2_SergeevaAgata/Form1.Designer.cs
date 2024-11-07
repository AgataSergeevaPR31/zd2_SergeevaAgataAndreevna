namespace UP_z2_SergeevaAgata
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuContact = new MenuStrip();
            контактыToolStripMenuItem = new ToolStripMenuItem();
            поискПоИмениToolStripMenuItem = new ToolStripMenuItem();
            добавитьКонтактToolStripMenuItem = new ToolStripMenuItem();
            редактироватьToolStripMenuItem = new ToolStripMenuItem();
            Contacts = new ListBox();
            deleteMenu = new ContextMenuStrip(components);
            deleteContact = new ToolStripMenuItem();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            pnlSearch = new Panel();
            lblAdd = new Label();
            txtName = new TextBox();
            txtNumber = new TextBox();
            lblName = new Label();
            lblNumber = new Label();
            btnAdd = new Button();
            pnlAdd = new Panel();
            pnlEdit = new Panel();
            btnEdit = new Button();
            txtNumber2 = new TextBox();
            txtName2 = new TextBox();
            lblNumber2 = new Label();
            lblName2 = new Label();
            lblEdit = new Label();
            menuContact.SuspendLayout();
            deleteMenu.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlAdd.SuspendLayout();
            pnlEdit.SuspendLayout();
            SuspendLayout();
            // 
            // menuContact
            // 
            menuContact.BackColor = Color.FromArgb(192, 255, 255);
            menuContact.ImageScalingSize = new Size(20, 20);
            menuContact.Items.AddRange(new ToolStripItem[] { контактыToolStripMenuItem, поискПоИмениToolStripMenuItem, добавитьКонтактToolStripMenuItem, редактироватьToolStripMenuItem });
            menuContact.Location = new Point(0, 0);
            menuContact.Name = "menuContact";
            menuContact.Size = new Size(660, 28);
            menuContact.TabIndex = 0;
            menuContact.Text = "menuStrip1";
            // 
            // контактыToolStripMenuItem
            // 
            контактыToolStripMenuItem.Name = "контактыToolStripMenuItem";
            контактыToolStripMenuItem.Size = new Size(88, 24);
            контактыToolStripMenuItem.Text = "Контакты";
            контактыToolStripMenuItem.Click += контактыToolStripMenuItem_Click;
            // 
            // поискПоИмениToolStripMenuItem
            // 
            поискПоИмениToolStripMenuItem.Name = "поискПоИмениToolStripMenuItem";
            поискПоИмениToolStripMenuItem.Size = new Size(146, 24);
            поискПоИмениToolStripMenuItem.Text = "Добавить контакт";
            поискПоИмениToolStripMenuItem.Click += поискПоИмениToolStripMenuItem_Click;
            // 
            // добавитьКонтактToolStripMenuItem
            // 
            добавитьКонтактToolStripMenuItem.Name = "добавитьКонтактToolStripMenuItem";
            добавитьКонтактToolStripMenuItem.Size = new Size(125, 24);
            добавитьКонтактToolStripMenuItem.Text = "Редактировать";
            добавитьКонтактToolStripMenuItem.Click += добавитьКонтактToolStripMenuItem_Click;
            // 
            // редактироватьToolStripMenuItem
            // 
            редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            редактироватьToolStripMenuItem.Size = new Size(67, 24);
            редактироватьToolStripMenuItem.Text = "Выход";
            редактироватьToolStripMenuItem.Click += редактироватьToolStripMenuItem_Click;
            // 
            // Contacts
            // 
            Contacts.ContextMenuStrip = deleteMenu;
            Contacts.FormattingEnabled = true;
            Contacts.Location = new Point(12, 43);
            Contacts.Name = "Contacts";
            Contacts.Size = new Size(304, 384);
            Contacts.TabIndex = 1;
            Contacts.SelectedIndexChanged += Contacts_SelectedIndexChanged;
            // 
            // deleteMenu
            // 
            deleteMenu.ImageScalingSize = new Size(20, 20);
            deleteMenu.Items.AddRange(new ToolStripItem[] { deleteContact });
            deleteMenu.Name = "deleteMenu";
            deleteMenu.Size = new Size(191, 28);
            // 
            // deleteContact
            // 
            deleteContact.Name = "deleteContact";
            deleteContact.Size = new Size(190, 24);
            deleteContact.Text = "Удалить контакт";
            deleteContact.Click += deleteContact_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(63, 10);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(55, 20);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Поиск:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 48);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(172, 27);
            txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(43, 93);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Искать";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(349, 79);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(183, 129);
            pnlSearch.TabIndex = 5;
            // 
            // lblAdd
            // 
            lblAdd.AutoSize = true;
            lblAdd.Location = new Point(103, 18);
            lblAdd.Name = "lblAdd";
            lblAdd.Size = new Size(162, 20);
            lblAdd.TabIndex = 6;
            lblAdd.Text = "Добавление контакта:";
            // 
            // txtName
            // 
            txtName.Location = new Point(157, 57);
            txtName.Name = "txtName";
            txtName.Size = new Size(152, 27);
            txtName.TabIndex = 7;
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(103, 95);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(206, 27);
            txtNumber.TabIndex = 8;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(34, 57);
            lblName.Name = "lblName";
            lblName.Size = new Size(106, 20);
            lblName.TabIndex = 9;
            lblName.Text = "Имя контакта:";
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(34, 95);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(60, 20);
            lblNumber.TabIndex = 10;
            lblNumber.Text = "Номер:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(132, 128);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // pnlAdd
            // 
            pnlAdd.Controls.Add(btnAdd);
            pnlAdd.Controls.Add(lblNumber);
            pnlAdd.Controls.Add(lblName);
            pnlAdd.Controls.Add(txtNumber);
            pnlAdd.Controls.Add(txtName);
            pnlAdd.Controls.Add(lblAdd);
            pnlAdd.Location = new Point(76, 43);
            pnlAdd.Name = "pnlAdd";
            pnlAdd.Size = new Size(360, 180);
            pnlAdd.TabIndex = 12;
            pnlAdd.Visible = false;
            // 
            // pnlEdit
            // 
            pnlEdit.Controls.Add(btnEdit);
            pnlEdit.Controls.Add(txtNumber2);
            pnlEdit.Controls.Add(txtName2);
            pnlEdit.Controls.Add(lblNumber2);
            pnlEdit.Controls.Add(lblName2);
            pnlEdit.Controls.Add(lblEdit);
            pnlEdit.Location = new Point(322, 46);
            pnlEdit.Name = "pnlEdit";
            pnlEdit.Size = new Size(316, 195);
            pnlEdit.TabIndex = 19;
            pnlEdit.Visible = false;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(104, 145);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(128, 29);
            btnEdit.TabIndex = 18;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtNumber2
            // 
            txtNumber2.Location = new Point(104, 101);
            txtNumber2.Name = "txtNumber2";
            txtNumber2.Size = new Size(180, 27);
            txtNumber2.TabIndex = 17;
            // 
            // txtName2
            // 
            txtName2.Location = new Point(137, 65);
            txtName2.Name = "txtName2";
            txtName2.Size = new Size(147, 27);
            txtName2.TabIndex = 16;
            // 
            // lblNumber2
            // 
            lblNumber2.AutoSize = true;
            lblNumber2.Location = new Point(25, 104);
            lblNumber2.Name = "lblNumber2";
            lblNumber2.Size = new Size(60, 20);
            lblNumber2.TabIndex = 15;
            lblNumber2.Text = "Номер:";
            // 
            // lblName2
            // 
            lblName2.AutoSize = true;
            lblName2.Location = new Point(25, 65);
            lblName2.Name = "lblName2";
            lblName2.Size = new Size(106, 20);
            lblName2.TabIndex = 14;
            lblName2.Text = "Имя контакта:";
            // 
            // lblEdit
            // 
            lblEdit.AutoSize = true;
            lblEdit.Location = new Point(71, 28);
            lblEdit.Name = "lblEdit";
            lblEdit.Size = new Size(173, 20);
            lblEdit.TabIndex = 13;
            lblEdit.Text = "Редактирование файла:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 441);
            Controls.Add(pnlEdit);
            Controls.Add(pnlAdd);
            Controls.Add(pnlSearch);
            Controls.Add(Contacts);
            Controls.Add(menuContact);
            MainMenuStrip = menuContact;
            Name = "Form1";
            Text = "Form1";
            menuContact.ResumeLayout(false);
            menuContact.PerformLayout();
            deleteMenu.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlAdd.ResumeLayout(false);
            pnlAdd.PerformLayout();
            pnlEdit.ResumeLayout(false);
            pnlEdit.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuContact;
        private ToolStripMenuItem контактыToolStripMenuItem;
        private ToolStripMenuItem поискПоИмениToolStripMenuItem;
        private ToolStripMenuItem добавитьКонтактToolStripMenuItem;
        private ToolStripMenuItem редактироватьToolStripMenuItem;
        private ListBox Contacts;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel pnlSearch;
        private ContextMenuStrip deleteMenu;
        private ToolStripMenuItem deleteContact;
        private Label lblAdd;
        private TextBox txtName;
        private TextBox txtNumber;
        private Label lblName;
        private Label lblNumber;
        private Button btnAdd;
        private Panel pnlAdd;
        private Label lblEdit;
        private Label lblName2;
        private Label lblNumber2;
        private TextBox txtName2;
        private TextBox txtNumber2;
        private Button btnEdit;
        private Panel pnlEdit;
    }
}
