using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_homework1
{
    internal class Brands
    {
        private static int _id;

        public Brands()
        {
            _id++;
            Id = _id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return "\nId :"+Id + " - " + " Name: "+Name + " - " + " Date: "+Date +"\n";
        }
    }
}
