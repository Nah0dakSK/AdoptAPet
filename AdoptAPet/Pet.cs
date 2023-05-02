using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptAPet
{
    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }

        public Pet(string name, string type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }

        public override string ToString()
        {
            return $" {Name} (druh: {Type}, vek: {Age} rokov)";
        }
    }
}
