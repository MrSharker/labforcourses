using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Notebook
    {
        static void Main(string[] args)
        {
            bool exit = false;
            List<Note> notes = new List<Note>();
            while (exit == false)
            {
                try
                {
                    Console.WriteLine("\tТелефонная книжка\n1.Просмотр контакотов\n2.Создать новый контакт" +
                        "\n3.Выход");
                    int action = int.Parse(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            Console.WriteLine("\tКонтакты");
                            if (notes.Count == 0) { Console.WriteLine("У вас нет контактов :("); }
                            else
                            {
                                int id = 0;
                                foreach (Note n in notes)
                                {
                                    id += 1;
                                    Console.WriteLine($"{id}.{n.sername} {n.name} - {n.phone}");
                                }
                                Console.WriteLine("\tВозможные действия:\n1.Посмотреть полную информацию о контакте" +
                                    "\n2.Изменить информацию о контакте\n3.Удалить контакт");
                                int k = int.Parse(Console.ReadLine());
                                switch (k)
                                {
                                    case 1:
                                        Console.Write("Введите порядковый номер контакта: ");
                                        int a = int.Parse(Console.ReadLine());
                                        notes[a - 1].ReadNote();
                                        break;
                                    case 2:
                                        Console.Write("Введите порядковый номер контакта: ");
                                        a = int.Parse(Console.ReadLine());
                                        notes[a - 1].ReadNote();
                                        notes[a - 1].EditNote();
                                        break;
                                    case 3:
                                        Console.Write("Введите порядковый номер контакта: ");
                                        a = int.Parse(Console.ReadLine());
                                        notes.RemoveAt(a - 1);
                                        break;
                                }
                            }
                            break;
                        case 2:
                            notes.Add(new Note());
                            notes.Last().CreateNewNote();
                            notes.Sort();
                            break;
                        case 3:
                            exit = true;
                            break;

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Введенно некоректное значение");
                }
                

            }
        }
    }
}
