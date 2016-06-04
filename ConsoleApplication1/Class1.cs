using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ConsoleApplication1
{
    /// <summary>
    /// Класс для возврата нового и старого значения
    /// Содержит события для обработчика событий
    /// </summary>
    public class ChangeNameAgeEventArg : EventArgs
    {
        public string OldName { get; set; }
        public string NewName { get; set; }

        public int OldAge { get; set; }
        public int NewAge { get; set; }

        public ChangeNameAgeEventArg(string oldName, string newName)
        {
            OldName = oldName;
            NewName = newName;
        }

        public ChangeNameAgeEventArg(int oldAge, int newAge)
        {
            OldAge = oldAge;
            NewAge = newAge;
        }
    }

    /// <summary>
    /// непосредственно сам класс который добавляет
    /// изменяет или удаляет человеков
    /// </summary>
    class User
    {

        public string name;
        public int age;

        //Обработчики событий
        public event EventHandler<ChangeNameAgeEventArg> OnChangeName;
        public event EventHandler<ChangeNameAgeEventArg> OnChangeAge;

        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name {
            get { return name; }

            set {
                if (OnChangeName != null)
                {
                    OnChangeName(this, new ChangeNameAgeEventArg(Name, value));
                    name = value;
                }
                
            }
        }

        /// <summary>
        /// В свойство Age добавляем проверку на максимальный возраст
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 150)
                {
                    throw new Exception(string.Format("Возраст не корректен", value));
                }
                else if (OnChangeAge != null)
                {
                    OnChangeAge(this, new ChangeNameAgeEventArg(Age, value));
                    this.age = value;
                }
            }
        }
    }
}