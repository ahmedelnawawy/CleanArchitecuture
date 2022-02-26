using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int ReorderLevel { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }


        public int QuantityPerUnitId { get; set; }
        public QuantityPerUnit QuantityPerUnit { get; set; }
        //
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
