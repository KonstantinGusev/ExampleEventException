using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ConsoleApplication35
{

    public class User
    {
        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }
    }

    public class Person

    {

        public void ParseName()
        {
            while (true)
            {
                Console.WriteLine("Введите имя и возраст через enter");
                try
                {
                    ObservableCollection<User> users = new ObservableCollection<User>

                {
                    new User() { Name = Console.ReadLine(), Age = int.Parse(Console.ReadLine()) },
                    new User() { Name = Console.ReadLine(), Age = int.Parse(Console.ReadLine()) },
                    new User() { Name = Console.ReadLine(), Age = int.Parse(Console.ReadLine()) },
                    new User() { Name = Console.ReadLine(), Age = int.Parse(Console.ReadLine()) }
                    };

                    IReadOnlyList<User> users2 = users;

                    foreach (User theNameAge in users)
                    {
                        if (theNameAge.Age < 150)
                        {
                            Console.WriteLine(theNameAge.Name + "  " + theNameAge.Age );
                        }
                        else
                        {
                            Console.WriteLine("Ошибка ввода возраста");
                            Environment.Exit(1);
                        }
                    }


                    users.CollectionChanged += Users_CollectionChanged;


                    Console.WriteLine(@"Доступные действия
1) Добавление
2) Удаление
3) Изменение
4) Выход
");
                    try
                    {
                        int b = int.Parse(Console.ReadLine());


                        switch (b)

                        {
                            case 1:
                                Console.WriteLine("Введите имя и возраст нового участника");
                                
                                string z = Console.ReadLine();

                                int l = int.Parse(Console.ReadLine());

                                    if (l > 150)
                                    {
                                        Console.WriteLine("Столько не живут");
                                        Environment.Exit(0);
                                    }

                                foreach (User theNameAge in users2)
                                {
                                    Console.WriteLine("Старый список " + theNameAge.Name + "  " + theNameAge.Age + "\n");
                                }

                                users.Add(new User { Name = z, Age = l });

                                foreach (User theNameAge in users)
                                {
                                    Console.WriteLine("Новый список " + theNameAge.Name + "  " + theNameAge.Age + "\n");
                                }

                                break;

                            case 2:
                                Console.WriteLine("Введите индекс удаляемого обьекта");
                                int g = int.Parse(Console.ReadLine());

                                if (g > 3)
                                {
                                    Console.WriteLine("Выход за пределы массива");
                                    Environment.Exit(2);
                                }

                                foreach (User theNameAge in users2)
                                {
                                    Console.WriteLine("Старый список " + theNameAge.Name + "  " + theNameAge.Age);
                                }

                                users.RemoveAt(g);

                                foreach (User theNameAge in users)
                                {
                                    Console.WriteLine("Новый список " + theNameAge.Name + "  " + theNameAge.Age);
                                }
                                break;

                            case 3:
                                Console.WriteLine("Введите индекс изменяемого обьекта");

                                int a = int.Parse(Console.ReadLine());

                                if (a > 3)
                                {
                                    Console.WriteLine("Выход за пределы массива");
                                    Environment.Exit(2);
                                }

                                Console.WriteLine("Введите новое имя и новый возраст");

                                string t = Console.ReadLine();
                                int y = int.Parse(Console.ReadLine());

                                if (y > 150)
                                {
                                    Console.WriteLine("Ошибка ввода возраста");
                                    Environment.Exit(1);
                                }

                                foreach (User theNameAge in users2)
                                {
                                    Console.WriteLine("Старый список " + theNameAge.Name + "  " + theNameAge.Age + "\n");
                                }

                                users[a] = new User { Name = t, Age = y };

                                foreach (User theNameAge in users)
                                {
                                    Console.WriteLine("Новый список " + theNameAge.Name + "  " + theNameAge.Age + "\n");
                                }
                                break;

                            case 4:
                                Environment.Exit(5);
                                break;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("НЕВЕРНЫЙ ВВОД ТИПОВ ЗНАЧЕНИЙ ПРИЛОЖЕНИЕ ВЗРЫВАЕТСЯ", e.Message);
                    }

                }
                catch
                {
                    Console.WriteLine("Неверный ввод типов");
                }
            }
        }

        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление

                    User newUser = e.NewItems[0] as User;
                    Console.WriteLine("Добавлен новый объект: {0}\n", newUser.Name);
                    break;

                case NotifyCollectionChangedAction.Remove: // если удаление

                    User oldUser = e.OldItems[0] as User;
                    Console.WriteLine("Удален объект: {0}\n", oldUser.Name);
                    break;

                case NotifyCollectionChangedAction.Replace: // если замена

                    User replacedUser = e.OldItems[0] as User;
                    User replacingUser = e.NewItems[0] as User;
                    Console.WriteLine("Объект {0} заменен объектом {1}\n",
                                        replacedUser.Name, replacingUser.Name);

                    break;
            }
        }
  
    }
}
