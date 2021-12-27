namespace DALnew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReceiptLine")]
    public partial class ReceiptLine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Dish { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public int Receipt { get; set; }

        public virtual Dish Dish1 { get; set; }

        public virtual Receipt Receipt1 { get; set; }
    }
}
