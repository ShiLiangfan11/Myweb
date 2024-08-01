namespace Myweb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RateAll")]
    public partial class RateAll
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int AScore { get; set; }

        public int BScore { get; set; }

        public int CScore { get; set; }

        public string Comment { get; set; }
    }
}
