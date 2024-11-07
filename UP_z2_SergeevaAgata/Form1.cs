using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UP_z2_SergeevaAgata
{
    public partial class Form1 : Form
    {
        private PhoneBook phoneBook = new PhoneBook();
        public Form1()
        {
            InitializeComponent();
            //��� �������� ����� ����� ��������� ��� ��������
            LoadContacts("contacts.csv");
        }

        private void LoadContacts(string fileName)
        {
            //�������� ����� �� ������������ ������
            PhoneBookLoader.Load(phoneBook, fileName);
            //�������� ������� ����� ��� ����������� ���������
            ShowContacts();
        }

        private void ShowContacts()
        {
            Contacts.Items.Clear();
            foreach (var contact in phoneBook.Contacts())
            {
                Contacts.Items.Add($"{contact.name}: {contact.phone}");
            }
        }

        private bool CorrectNumber(string number)
        {
            //������� ���������� ������ �� ������ ��������� ������
            char[] stroka = number.ToCharArray();
            //���������� ���������������� �����, ����� ���� ����� ���������
            string n1 = stroka[1].ToString() + stroka[2].ToString() + stroka[3].ToString() + stroka[5].ToString() + stroka[6].ToString() + stroka[7].ToString();
            string n2 = stroka[9].ToString() + stroka[10].ToString() + stroka[12].ToString() + stroka[13].ToString();

            //�������� �� ��, ��� ����� ������ ��������� �������
            if (stroka[0] == '(' && stroka[4] == ')'
                && stroka[8] == '-' && stroka[11] == '-'
                && int.TryParse(n1, out int num1)
                && int.TryParse(n2, out int num2)) return true;
            else return false;
        }
        static bool OnlyLetter(string text)
        {
            //��������� ��� ��������, ��� ������ ������� ������ �� ���� � ��������
            return Regex.IsMatch(text, @"^[a-zA-Z�-��-߸�\s]+$");
        }


        private void deleteContact_Click(object sender, EventArgs e)
        {
            if (Contacts.SelectedItem != null)
            {
                // �������� ��� �������� �� ����������� ��������
                var deleteContact = Contacts.SelectedItem.ToString();
                var name = deleteContact.Split(':')[0].Trim(); //���� ���

                //������� �������
                phoneBook.RemoveContact(name);
                //��������� ��������� � ����
                PhoneBookLoader.Save(phoneBook, "contacts.csv");
                //��������� listBox
                ShowContacts();
            }
            else MessageBox.Show("����������, �������� ������� ��� ��������.");
        }

        //������� �������� �����
        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //������� ������
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == null)
            {
                var contact = phoneBook.ContactSearch(txtSearch.Text);
                if (contact != null)
                {
                    MessageBox.Show($"������ �������: {contact.name} - {contact.phone}");

                    int index = Contacts.FindString(contact.name); //����� �������
                    if (index != -1) // ���� ������ ������
                    {
                        Contacts.SelectedIndex = index; //��������� ������
                        Contacts.TopIndex = index; //��������� listBox �� �����������
                    }
                }
                else MessageBox.Show("������� �� ������.");
            }
            else MessageBox.Show("������� ��� ��� ������!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //�������� �� �������
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtNumber.Text))
            {
                //��������� �� ��, ��� ���������� �������� ��������� 2-� � �����
                if (txtName.Text.Length > 1)
                {
                    //�������� �� ��, ��� ������� ������ ����� � �������
                    if (OnlyLetter(txtName.Text))
                    {
                        //�������� �� ��, ��� ���� ������ ����� �����
                        if (txtNumber.Text.Length == 14)
                        {
                            //�������� �� ��, ��� ����� ����� �� �����
                            if (CorrectNumber(txtNumber.Text))
                            {
                                var phone = phoneBook.ContactSearchNumber(txtNumber.Text);
                                //�������� �� ���, ��� ������ ��� � ���������� �����
                                if (phone != null)
                                {
                                    MessageBox.Show("������� � ����� ������� ��� ����!");
                                }
                                else 
                                {
                                    //������� ������ ������ � �������� ����� ��� ���������� ��������
                                    var contact = new Contact { name = txtName.Text, phone = txtNumber.Text };
                                    phoneBook.AddContact(contact);
                                    //��������� ���������
                                    PhoneBookLoader.Save(phoneBook, "contacts.csv");
                                    //��������� listBox
                                    ShowContacts();
                                    //�������
                                    txtName.Clear();
                                    txtNumber.Clear();
                                }
                            }
                            else MessageBox.Show("����� ������ ���� ����� � ������� (999)999-99-88");
                        }
                        else MessageBox.Show("����� ������ ���� ����� � ������� (999)999-99-99");
                    }
                    else MessageBox.Show("��� ������������ ������ ��������� ������ ����� � �������");
                }
                else MessageBox.Show("��� �������� ������ ��������� �� ����� 2-� ��������");
            }
            else MessageBox.Show("����������, ��������� ��� ������ � ��������");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //�������� �� ��, �� ������ ������� ��� ���������
            if (Contacts.SelectedItem != null)
            {
                //����� �������� �� listox � ����� ��� �� ��������� ����������
                string redact = Contacts.SelectedItem.ToString();
                string[] parts = redact.Split(':');
                //���������� ��� �������� ��� ����, ����� ����� �������� ����� ������ ������� �� ������
                string name = parts[0];
                //�������� �� �������
                if (!string.IsNullOrEmpty(txtName2.Text) && !string.IsNullOrEmpty(txtNumber2.Text))
                {
                    //�������� �� �����
                    if (txtName2.Text.Length > 1)
                    {
                        //�������� �� ��, ��� ������ ����� � �������
                        if (OnlyLetter(txtName2.Text))
                        {
                            //�������� �� ��, ��� ���� ������ ����� �����
                            if (txtNumber2.Text.Length == 14)
                            {
                                //�������� �� ��, ��� ����� ����� �� �����
                                if (CorrectNumber(txtNumber2.Text))
                                {
                                    var phone = phoneBook.ContactSearchNumber(txtNumber2.Text);
                                    //�������� �� ���, ��� ������ ��� � ���������� �����
                                    if (phone != null)
                                    {
                                        MessageBox.Show("������� � ����� ������� ��� ����!");
                                    }
                                    else
                                    {
                                        //�������� ����� ��������������
                                        phoneBook.EditContact(name, txtName2.Text, txtNumber2.Text);
                                        //��������� ���������
                                        PhoneBookLoader.Save(phoneBook, "contacts.csv");
                                        //��������� listBox
                                        ShowContacts();
                                        //�������
                                        txtName2.Clear();
                                        txtNumber2.Clear();
                                    } 
                                }
                                else MessageBox.Show("����� ������ ���� ����� � ������� (999)999-99-88");
                            }
                            else MessageBox.Show("����� ������ ���� ����� � ������� (999)999-99-99");
                        }
                        else MessageBox.Show("��� ������������ ������ ��������� ������ ����� � �������");
                    }
                    else MessageBox.Show("��� �������� ������ ��������� �� ����� 2-� ��������");
                }
                else MessageBox.Show("����������, ��������� ��� ������ � ��������");
            }
            else MessageBox.Show("����������, �������� ������� ��� ��������������.");
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;

            Contacts.Visible = false;
            pnlSearch.Visible = false;
            pnlEdit.Visible = false;
        }

        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlEdit.Visible = true;
            Contacts.Visible = true;

            pnlAdd.Visible = false;
            pnlSearch.Visible = false;
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contacts.Visible = true;
            pnlSearch.Visible = true;

            pnlAdd.Visible = false;
            pnlEdit.Visible = false;
        }

        private void Contacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //���������, ��� ������� ������� ��� ��������������
            if (Contacts.SelectedItem != null)
            {
                //����� �������� �� listox � ����� ��� �� ��������� ����������
                string redact = Contacts.SelectedItem.ToString();
                string[] parts = redact.Split(':');
                string name = parts[0];
                string newName = parts[0];
                //������� ������� (�� ������ ������)
                string number = parts[1].Replace(" ", "").Trim(); ;

                //������ �������� �� listbox � editText, ����� ���� ����� ���-�� ������ (�� � ���������)
                txtName2.Text = parts[0];
                txtNumber2.Text = parts[1].Replace(" ", "").Trim();
            }
            else MessageBox.Show("����������, �������� ������� ��� ��������������.");
        }
    }
}
