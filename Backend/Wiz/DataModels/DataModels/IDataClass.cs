using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractModels
{
    public interface IDataClass
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
    }
}
