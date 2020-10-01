namespace İnternetProgramlamaFilmProjesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class film
    {
        public int id { get; set; }

        public int fragman_width { get; set; }

        public int fragman_height { get; set; }

        [Required]
        [StringLength(50)]
        public string fragman_iframe { get; set; }

        public int fragman_frameborder { get; set; }

        public int film_width { get; set; }

        public int film_height { get; set; }

        [Required]
        [StringLength(50)]
        public string film_iframe { get; set; }

        public int film_frameborder { get; set; }

        [Required]
        [StringLength(1000)]
        public string acilklama { get; set; }

        [Required]
        [StringLength(250)]
        public string resim { get; set; }

        [StringLength(250)]
        public string film_adi { get; set; }
    }
}
