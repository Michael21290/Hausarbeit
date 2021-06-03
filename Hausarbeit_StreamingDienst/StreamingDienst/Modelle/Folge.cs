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

        [Required(ErrorMessage = "Bitte geben Sie einen Titel an.")]
        public string FolgenTitel { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie die Folgenlänge an.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FolgenLaenge { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie die Leihgebüren an.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Leihpreis { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie den Kaufpreis an.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Kaufpreis { get; set; }
        public virtual Serie FSerienID { get; set; }
        public byte[] VideoData { get; set; }
    }
}
