using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_z2_SergeevaAgata
{
    internal class PhoneBook
    {
        private List<Contact> contacts = new List<Contact>();

        //вывод всех контактов
        public List<Contact> Contacts()
        {
            return contacts;
        }

        // Добавление контакта
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        //удаление контакта
        public void RemoveContact(string name)
        {
            var delete = contacts.FirstOrDefault(c => c.name == name); //LINQ возвращает первый элемент, ктоторый соответсвует заданному или нул
            if (delete != null)
            {
                contacts.Remove(delete);
            }
        }

        //поиск контакта по имени
        public Contact ContactSearch(string name)
        {
            return contacts.FirstOrDefault(c => c.name == name); //LINQ возвращает первый элемент, ктоторый соответсвует заданному или нул
        }

        public Contact ContactSearchNumber(string number)
        {
            return contacts.FirstOrDefault(c => c.phone == number); //LINQ возвращает первый элемент, ктоторый соответсвует заданному или нул
        }

        public void EditContact(string name, string newName, string newPhone)
        {
            var contact = ContactSearch(name); //метод для поиска редактируемого контакта
            if (contact != null)
            {
                contact.name = newName; 
                contact.phone = newPhone;
            }
        }
    }
}
