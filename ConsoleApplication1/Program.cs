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

            User user = new User("Костя", 280);
            user.OnChangeName += OldNewName;
            user.OnChangeAge += OldNewAge;
            user.Name = "Ёжик";
            user.Age = 40;
            

        }

        public static void OldNewName(object s, ChangeNameAgeEventArg e)
        {
            Console.WriteLine("Старое значение = {0}, новое значение = {1}", e.OldName, e.NewName);
        }

        public static void OldNewAge(object s, ChangeNameAgeEventArg e)
        {
            Console.WriteLine("Старое значение = {0}, новое значение = {1}", e.OldAge, e.NewAge);
        }
    }
}