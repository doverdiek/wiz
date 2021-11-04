using AbstractModels;
using System.Collections.Generic;

namespace DataModels
{
    public class CategoryProperty : DataClass
    {

        public string Name { get; set; }
        public List<string> Values { get; set; }
    }
}