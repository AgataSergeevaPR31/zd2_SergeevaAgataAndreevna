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
            //при загрузке формы сразу загружаем все контакты
            LoadContacts("contacts.csv");
        }

        private void LoadContacts(string fileName)
        {
            //вызываем метод из статического класса
            PhoneBookLoader.Load(phoneBook, fileName);
            //вызываем местный метод для отображения контактов
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
            //создаем символьным массив на основе введённого номера
            char[] stroka = number.ToCharArray();
            //объединяем предположительно числа, чтобы было проще проверять
            string n1 = stroka[1].ToString() + stroka[2].ToString() + stroka[3].ToString() + stroka[5].ToString() + stroka[6].ToString() + stroka[7].ToString();
            string n2 = stroka[9].ToString() + stroka[10].ToString() + stroka[12].ToString() + stroka[13].ToString();

            //проверка на то, что номер введёнт взаданном формате
            if (stroka[0] == '(' && stroka[4] == ')'
                && stroka[8] == '-' && stroka[11] == '-'
                && int.TryParse(n1, out int num1)
                && int.TryParse(n2, out int num2)) return true;
            else return false;
        }
        static bool OnlyLetter(string text)
        {
            //Выражение для проверки, что строка состоит только из букв и пробелов
            return Regex.IsMatch(text, @"^[a-zA-Zа-яА-ЯёЁ\s]+$");
        }


        private void deleteContact_Click(object sender, EventArgs e)
        {
            if (Contacts.SelectedItem != null)
            {
                // Получаем имя контакта из выделенного элемента
                var deleteContact = Contacts.SelectedItem.ToString();
                var name = deleteContact.Split(':')[0].Trim(); //берём имя

                //удаляем контакт
                phoneBook.RemoveContact(name);
                //сохраняем изменения в файл
                PhoneBookLoader.Save(phoneBook, "contacts.csv");
                //обновляем listBox
                ShowContacts();
            }
            else MessageBox.Show("Пожалуйста, выберите контакт для удаления.");
        }

        //событие закрытия формы
        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //событие поиска
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == null)
            {
                var contact = phoneBook.ContactSearch(txtSearch.Text);
                if (contact != null)
                {
                    MessageBox.Show($"Найден контакт: {contact.name} - {contact.phone}");

                    int index = Contacts.FindString(contact.name); //поиск индекса
                    if (index != -1) // Если индекс найден
                    {
                        Contacts.SelectedIndex = index; //выделение строки
                        Contacts.TopIndex = index; //прокрутка listBox до выделенного
                    }
                }
                else MessageBox.Show("Контакт не найден.");
            }
            else MessageBox.Show("Введите имя для поиска!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //проверка на пустоту
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtNumber.Text))
            {
                //провенрка на то, что количество символов равняется 2-м и более
                if (txtName.Text.Length > 1)
                {
                    //проверка на то, что введены только буквы и пробелы
                    if (OnlyLetter(txtName.Text))
                    {
                        //проверка на то, что длин номера равна маске
                        if (txtNumber.Text.Length == 14)
                        {
                            //проверка на то, что номер введён по маске
                            if (CorrectNumber(txtNumber.Text))
                            {
                                var phone = phoneBook.ContactSearchNumber(txtNumber.Text);
                                //проверка на тоо, что номера нет в телефонной книге
                                if (phone != null)
                                {
                                    MessageBox.Show("Контакт с таким номером уже есть!");
                                }
                                else 
                                {
                                    //создаем объект класса и вызываем метод для добавления контакта
                                    var contact = new Contact { name = txtName.Text, phone = txtNumber.Text };
                                    phoneBook.AddContact(contact);
                                    //сохраняем изменения
                                    PhoneBookLoader.Save(phoneBook, "contacts.csv");
                                    //обновляем listBox
                                    ShowContacts();
                                    //очищаем
                                    txtName.Clear();
                                    txtNumber.Clear();
                                }
                            }
                            else MessageBox.Show("Номер должен быть введён в формате (999)999-99-88");
                        }
                        else MessageBox.Show("Номер должен быть введён в формате (999)999-99-99");
                    }
                    else MessageBox.Show("Имя пользователя должно содержать только буквы и пробелы");
                }
                else MessageBox.Show("Имя контакта должно содержать не менее 2-х символов");
            }
            else MessageBox.Show("Пожалуйста, заполните все данные о контакте");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //проверка на то, чо выбран контакт для изменения
            if (Contacts.SelectedItem != null)
            {
                //берем значение из listox и делим его на отдельные переменные
                string redact = Contacts.SelectedItem.ToString();
                string[] parts = redact.Split(':');
                //запоминаем имя контакта для того, чтобы потом понимать какой именно контакт мы меняем
                string name = parts[0];
                //проверка на пустоту
                if (!string.IsNullOrEmpty(txtName2.Text) && !string.IsNullOrEmpty(txtNumber2.Text))
                {
                    //проверка на длину
                    if (txtName2.Text.Length > 1)
                    {
                        //проверка на то, что только буквы и пробелы
                        if (OnlyLetter(txtName2.Text))
                        {
                            //проверка на то, что длин номера равна маске
                            if (txtNumber2.Text.Length == 14)
                            {
                                //проверка на то, что номер введён по маске
                                if (CorrectNumber(txtNumber2.Text))
                                {
                                    var phone = phoneBook.ContactSearchNumber(txtNumber2.Text);
                                    //проверка на тоо, что номера нет в телефонной книге
                                    if (phone != null)
                                    {
                                        MessageBox.Show("Контакт с таким номером уже есть!");
                                    }
                                    else
                                    {
                                        //вызываем метод редактирования
                                        phoneBook.EditContact(name, txtName2.Text, txtNumber2.Text);
                                        //сохраняем изменения
                                        PhoneBookLoader.Save(phoneBook, "contacts.csv");
                                        //обновляем listBox
                                        ShowContacts();
                                        //очищаем
                                        txtName2.Clear();
                                        txtNumber2.Clear();
                                    } 
                                }
                                else MessageBox.Show("Номер должен быть введён в формате (999)999-99-88");
                            }
                            else MessageBox.Show("Номер должен быть введён в формате (999)999-99-99");
                        }
                        else MessageBox.Show("Имя пользователя должно содержать только буквы и пробелы");
                    }
                    else MessageBox.Show("Имя контакта должно содержать не менее 2-х символов");
                }
                else MessageBox.Show("Пожалуйста, заполните все данные о контакте");
            }
            else MessageBox.Show("Пожалуйста, выберите контакт для редактирования.");
        }

        private void поискПоИмениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;

            Contacts.Visible = false;
            pnlSearch.Visible = false;
            pnlEdit.Visible = false;
        }

        private void добавитьКонтактToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlEdit.Visible = true;
            Contacts.Visible = true;

            pnlAdd.Visible = false;
            pnlSearch.Visible = false;
        }

        private void контактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contacts.Visible = true;
            pnlSearch.Visible = true;

            pnlAdd.Visible = false;
            pnlEdit.Visible = false;
        }

        private void Contacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //проверяем, что выделен контакт для редактирования
            if (Contacts.SelectedItem != null)
            {
                //берем значение из listox и делим его на отдельные переменные
                string redact = Contacts.SelectedItem.ToString();
                string[] parts = redact.Split(':');
                string name = parts[0];
                string newName = parts[0];
                //удаляем пробелы (на всякий случай)
                string number = parts[1].Replace(" ", "").Trim(); ;

                //ставим значения из listbox в editText, чтобы было проще что-то менять (ну и подсказка)
                txtName2.Text = parts[0];
                txtNumber2.Text = parts[1].Replace(" ", "").Trim();
            }
            else MessageBox.Show("Пожалуйста, выберите контакт для редактирования.");
        }
    }
}
