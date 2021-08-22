using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET.Model {
    [Table("books")]
    public class Books {
        [Column("id")]
        public long Id { get; set; }

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
