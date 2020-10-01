namespace İnternetProgramlamaFilmProjesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("member")]
    public partial class member
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string ad { get; set; }

        [Required]
        [StringLength(50)]
        public string soyad { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string kullanici { get; set; }

        [Required]
        [StringLength(50)]
        public string parola { get; set; }
    }
}
