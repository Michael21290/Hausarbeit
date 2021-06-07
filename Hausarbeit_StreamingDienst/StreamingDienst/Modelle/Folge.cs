using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingDienst.Modelle
{
    public class Folge
    {
        public int ID { get; set; }

        public string FolgenTitel { get; set; }

        public string FolgenLaenge { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Leihpreis { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Kaufpreis { get; set; }
        public virtual Serie FSerienID { get; set; }
        public byte[] VideoData { get; set; }
    }
}
