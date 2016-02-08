namespace WebApplication21.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BOOKS
    {
        [Key]
        public int BOOKID { get; set; }

        [Required]
        [StringLength(30)]
        public string BOOKNAME { get; set; }

        [Required]
        [StringLength(30)]
        public string AUTHOR { get; set; }

        public int ISBN { get; set; }
    }
}
