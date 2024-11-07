using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_z2_SergeevaAgata
{
    static class PhoneBookLoader
    {
        public static void Load(PhoneBook phoneBook, string fileName)
        {
            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 2)
                    {
                        var contact = new Contact { name = parts[0], phone = parts[1] };
                        phoneBook.AddContact(contact);
                    }
                }
            }
        }
        public static void Save(PhoneBook phoneBook, string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                foreach (var contact in phoneBook.Contacts())
                {
                    writer.WriteLine($"{contact.name};{contact.phone}");
                }
            }
        }
    }
}
