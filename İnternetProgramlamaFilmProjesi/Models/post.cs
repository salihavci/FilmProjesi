namespace İnternetProgramlamaFilmProjesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("post")]
    public partial class post
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string kullanici { get; set; }

        public DateTime tarih { get; set; }

        [Required]
        [StringLength(150)]
        public string yorum { get; set; }

        public int onay { get; set; }
    }
}
