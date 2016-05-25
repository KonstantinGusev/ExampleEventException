using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ConsoleApplication35
{
    class Program
    { 
        static void Main(string[] args)
        {
            Person p = new Person();
            p.ParseName();
            Console.WriteLine(p);
        }

        
    }
}
