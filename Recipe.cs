namespace DALnew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recipe")]
    public partial class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Product { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Measure { get; set; }

        public int Dish { get; set; }

        public virtual Dish Dish1 { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
