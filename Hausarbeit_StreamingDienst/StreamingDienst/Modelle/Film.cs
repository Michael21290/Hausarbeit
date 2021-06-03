using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingDienst.Modelle
{
    public class Film
    {
        public int ID { get; set; }
        public string FilmTitel { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FilmLaenge { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Leihpreis { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Kaufpreis { get; set; }

        public Genre FGenreID { get; set; }

        public byte[] VideoData { get; set; }
        
    }
}
