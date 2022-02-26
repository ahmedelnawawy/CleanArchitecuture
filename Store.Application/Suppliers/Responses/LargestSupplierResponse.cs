using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Suppliers.Responses
{
    public class LargestSupplierResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
