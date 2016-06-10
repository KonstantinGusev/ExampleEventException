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
    public class ChangedNameAgeEventArg : EventArgs
    {
        public ChangedNameAgeEventArg(string name = "", int age = 0)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }


    
         class ChangingNameAgeArgs : EventArgs
        {

            public ChangingNameAgeArgs(string oldName, string newName = "")
            {
                this.OldName = oldName;
                this.NewName = newName;
            }

            public ChangingNameAgeArgs(int oldAge, int newAge)
            {
                this.OldAge = oldAge;
                this.newAge = newAge;
            }

            
            public int newAge { get; private set; }

            public int OldAge { get; private set; }

            public string NewName { get; private set; }

            public string OldName { get; private set; }
        }
    

    /// <summary>
    /// непосредственно сам класс который добавляет
    /// изменяет или удаляет человеков
    /// </summary>
    class User
    {

        public string name;
        public int age;

        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        //Обработчики событий
        public event EventHandler<ChangingNameAgeArgs> OnChanging; 
        public event EventHandler<ChangedNameAgeEventArg> OnChanged;

        

        public string Name
        {
            get { return name; }

            set
            {
                if (this.OnChanging != null)
                {
                    OnChanging(this, new ChangingNameAgeArgs(Name, value));
                }
                this.name = value;

                if (OnChanged != null)
                {
                    this.OnChanged(this, new ChangedNameAgeEventArg(Name, Age));
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
                if (value >= 150)
                {
                    throw new Exception(string.Format("Возраст не корректен", value));
                }
                if (OnChanging != null)
                {
                    OnChanging(this, new ChangingNameAgeArgs(this.Age,value));

                }
                this.age = value;
                if (this.OnChanged!=null)
                {
                    this.OnChanged(this, new ChangedNameAgeEventArg(Name, Age));
                }
            }
        }
    }
}