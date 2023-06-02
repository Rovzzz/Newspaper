using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Classes
{
    internal class DataBase
    {
        public static NewspaperNewEntities Base = new NewspaperNewEntities();

        public static List<Users> results = new List<Users>();

        public static Users users;
    }
}
