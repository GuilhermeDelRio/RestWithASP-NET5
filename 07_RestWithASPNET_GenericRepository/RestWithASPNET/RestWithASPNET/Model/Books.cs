using System;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithASPNET.Model.Base;

namespace RestWithASPNET.Model {
    [Table("books")]
    public class Books : BaseEntity{

        [Column("title")]
        public string Title { get; set; }

        [Column("author")]
        public string Author { get; set; }

        [Column("price")]
        public decimal Prime { get; set; }

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }        
    }
}
