using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadachi
{
    internal class Program
    {
        //static int DFS(int count) 
        //{ я не успел :( }
        public struct Student
        {
            public string secondName;
            public DateTime dateOfBirth;
            public string name;
            public string examName;
            public byte examResult;
            public void Output()
            {
                Console.WriteLine($"{secondName} {name}, Дата рождения: {dateOfBirth.ToShortDateString()}, Экзамен: {examName}, Кол-во баллов: {examResult}");
            }
        }
        
        static void Main(string[] args)
        {
            //1 Задание
            List<string> images = new List<string>(64);

            //Не понял как работать с картинками

            //2 Задание
            Console.WriteLine("2 Задание");
            Student student1 = new Student { secondName = "Иванов", dateOfBirth = new DateTime(2002, 5, 10), name = "Иван", examName = "Математика", examResult = 85 };
            Student student2 = new Student { secondName = "Петров", dateOfBirth = new DateTime(2003, 4, 15), name = "Петр", examName = "Физика", examResult = 90 };
            Student student3 = new Student { secondName = "Сидорова", dateOfBirth = new DateTime(2001, 3, 20), name = "Анна", examName = "Химия", examResult = 78 };
            Student student4 = new Student { secondName = "Кузнецов", dateOfBirth = new DateTime(2004, 6, 25), name = "Алексей", examName = "Биология", examResult = 88 };
            Student student5 = new Student { secondName = "Смирнова", dateOfBirth = new DateTime(2002, 8, 30), name = "Мария", examName = "История", examResult = 92 };
            Student student6 = new Student { secondName = "Попов", dateOfBirth = new DateTime(2005, 12, 5), name = "Дмитрий", examName = "География", examResult = 79 };
            Student student7 = new Student { secondName = "Лебедева", dateOfBirth = new DateTime(2001, 1, 25), name = "Елена", examName = "Литература", examResult = 95 };
            Student student8 = new Student { secondName = "Федоров", dateOfBirth = new DateTime(2003, 2, 14), name = "Сергей", examName = "Алгебра", examResult = 84 };
            Student student9 = new Student { secondName = "Михайлова", dateOfBirth = new DateTime(2004, 7, 19), name = "Татьяна", examName = "Философия", examResult = 91 };
            Student student10 = new Student { secondName = "Николаев", dateOfBirth = new DateTime(2002, 11, 8), name = "Максим", examName = "Музыка", examResult = 87 };
            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                {0, student1},
                {1, student2},
                {2, student3},
                {3, student4},
                {4, student5},
                {5, student6},
                {6, student7},
                {7, student8},
                {8, student9},
                {9, student10}
            };

            Console.WriteLine("Имеется следующий список студентов, а также информация о них:");
            for (int i = 0;i < students.Count;i++)
            {
                students[i].Output();
            }
            bool flag = true;
            Console.WriteLine();
            Console.WriteLine("Вы можете выполнять некоторые действия с данным списком:");
            Console.WriteLine("Введите 'Новый студент', чтобы добавить в этот список нового студента, а также информацию о нём");
            Console.WriteLine("Введите 'Удалить', чтобы удалить студента, для этого потребуется ввести его фамилию и имя");
            Console.WriteLine("Введите 'Сортировать' чтобы отсортировать студентов по их баллам");
            Console.WriteLine("Введите 'Вывод на экран', чтобы закончить работу со списком студенов");
            Console.WriteLine("Введите 'Выход', чтобы закончить работу со списком студенов");
            Console.WriteLine();
            while (flag) 
            {
                string action = Console.ReadLine();
                switch (action)
                {
                    case "Новый студент":
                        
                        Student newStudent = new Student();
                        
                        Console.Write("Введите имя:");
                        newStudent.name = Console.ReadLine();
                        
                        Console.Write("Введите фамилию:");
                        newStudent.secondName = Console.ReadLine();
                        
                        Console.Write("Введите год рождения:");
                        int.TryParse(Console.ReadLine(), out var year);
                        Console.Write("Введите номер месяца рождения:");
                        int.TryParse(Console.ReadLine(), out var month);
                        Console.Write("Введите день рождения:");
                        int.TryParse(Console.ReadLine(), out var day);
                        newStudent.dateOfBirth = new DateTime(year, month, day);

                        Console.Write("Введите предмет, по которому данный студент сдавал экзамен:");
                        newStudent.examName = Console.ReadLine();

                        Console.Write("Введите количество баллов за данный экзамен:");
                        byte.TryParse(Console.ReadLine(), out var points);
                        newStudent.examResult = points;

                        students.Add(students.Count, newStudent);
                        Console.WriteLine("Студент добавлен");
                        break;

                    case "Удалить":
            
                        Console.Write("Введите имя студента:");
                        string deleteName = Console.ReadLine();
                        
                        Console.Write("Введите фамилию студента:");
                        string deleteSecondName = Console.ReadLine();
                        
                        bool tempFlag = true;
                        for (int i = 0; i < students.Count;i++)
                        {
                            
                            if (deleteName == students[i].name && deleteSecondName == students[i].secondName)
                            {
                                students.Remove(i);
                                Console.WriteLine($"Студент {deleteName} {deleteSecondName} удалён из списка");
                                tempFlag = false;
                                break;
                            }
                        }
                        if (tempFlag)
                        {
                            Console.WriteLine("Студента с таким именем и фамилией не существует в данном списке");
                        }

                        Dictionary<int, Student> tempStudents = new Dictionary<int, Student>();
                        int t = 0;
                        foreach (Student i in students.Values)
                        {
                            tempStudents.Add(t, i);
                            t++;
                        }
                        students = tempStudents;
                        break;

                    case ("Сортировать"):
                        var sortedStudents = students.Values.OrderBy(student => student.examResult).ToList();
                        for (int i = 0; i < students.Count; i++)
                        {
                            students[i] = sortedStudents[i];
                        }
                        Console.WriteLine("Список отсортирован по количеству баллов у студента");
                        break;

                    case ("Вывод на экран"):
                        for (int i = 0; i < students.Count; i++)
                        {
                            students[i].Output();
                        }
                        break;

                    case ("Выход"):
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Команда не распознана");
                        break;
                }
            }


            //4 Задание
            Console.WriteLine("Я не успел :(");

            var graph = new Dictionary<int, List<int>>
        {
            { 1, new List<int> { 2, 3 } },
            { 2, new List<int> { 1, 4, 5 } },
            { 3, new List<int> { 1, 6 } },
            { 4, new List<int> { 2 } },
            { 5, new List<int> { 2, 6 } },
            { 6, new List<int> { 3, 5 } }
        };

        }
    }
}
