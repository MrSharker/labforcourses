using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Note
    {
        public string sername;
        public string name;
        public string middlname;
        public long phone;
        public string country;
        public DateTime dayofbirth;
        public string organisation;
        public string position;
        public string dopNote;
        public void CreateNewNote()
        {
            try
            {

           
            Console.Write("Введите фамилию(обязательно): ");
            sername = Console.ReadLine();
            Console.Write("Введите имя(обязательно): ");
            name = Console.ReadLine();
            Console.Write("Введите отчество(не обязательно): ");
            middlname = Console.ReadLine();
            Console.Write("Введите телефон(обязательно): ");
            phone = Int64.Parse(Console.ReadLine());
            Console.Write("Введите страну(обязательно): ");
            country = Console.ReadLine();
            Console.Write("Введите дату рождения(не обязательно): ");
            dayofbirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите орагнизацию(не обязательно): ");
            organisation = Console.ReadLine();
            Console.Write("Введите должность(не обязательно): ");
            position = Console.ReadLine();
            Console.Write("Введите прочие заметки(не обязательно): ");
            dopNote = Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Введенно некоректное значение");
            }
        }
        public void EditNote()
        {
            try
            {
            Console.WriteLine("\tЧто вы хотите изменить?:\n1.Фамилия" +
                "\n2.Имя\n3.Отчество\n4.Номер телефона\n5.Страна" +
                "\n6.Дата рождения\n7.Организация\n8.Должность\n9.Прочие заметки");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Введите новую фамилию: ");
                    sername = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Введите новое имя: ");
                    name = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Введите новое отчество: ");
                    middlname = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Введите новый телефон: ");
                    phone = Int64.Parse(Console.ReadLine());
                    break;
                case 5:
                    Console.Write("Введите новую страну: ");
                    country = Console.ReadLine();
                    break;
                case 6:
                    Console.Write("Введите новую дату рождения: ");
                    dayofbirth = DateTime.Parse(Console.ReadLine());
                    break;
                case 7:
                    Console.Write("Введите новую организацию: ");
                    organisation = Console.ReadLine();
                    break;
                case 8:
                    Console.Write("Введите новую должность: ");
                    position = Console.ReadLine();
                    break;
                case 9:
                    Console.Write("Введите новую заметку: ");
                    dopNote = Console.ReadLine();
                    break;
            }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Введенно некоректное значение");
            }
        }
        public void ReadNote()
        {
            Console.WriteLine($"Фамилия - {sername}\nИмя - {name}");
            if (middlname.Length > 0)
            {
                Console.WriteLine($"Отчество - {middlname}");
            }
            Console.WriteLine($"Номер телефона - {phone}");
            if (dayofbirth != null)
            {
                Console.WriteLine($"Дата рождения - {dayofbirth.ToShortDateString()}");
            }
            if (organisation.Length > 0)
            {
                Console.WriteLine($"Организация - {organisation}");
            }
            if (position.Length > 0)
            {
                Console.WriteLine($"Должность - {position}");
            }
            if (dopNote.Length > 0)
            {
                Console.WriteLine($"Заметки - {dopNote}");
            }
        }
    }
}
