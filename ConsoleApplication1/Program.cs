using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            User user = new User("Костя", 80);

            user.OnChanging += User_OnChanging; ;
            user.OnChanged += User_OnChanged;

            user.Name = "Ёжик";
            user.Age = 40;
            

        }

        private static void User_OnChanged(object sender, ChangedNameAgeEventArg e)
        {
            Console.WriteLine("Имя = {0}, Возраст = {1}", e.Name, e.Age);
        }

        private static void User_OnChanging(object sender, ChangingNameAgeArgs e)
        {
            if (e.newAge != 0)
            {
                Console.WriteLine("Старый возраст = {0},новый возраст = {1}",e.OldAge,e.newAge);
            }
            if(e.NewName!=null)
            {
                Console.WriteLine("Старое имя = {0},новое имя = {1}",e.OldName, e.NewName);
            }
        }

    }
}