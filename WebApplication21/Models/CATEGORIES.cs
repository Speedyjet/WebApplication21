namespace WebApplication21.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATEGORIES
    {
        [Key]
        public int CATEGORYID { get; set; }

        [StringLength(30)]
        public string CATEGORYNAME { get; set; }
    }
}
