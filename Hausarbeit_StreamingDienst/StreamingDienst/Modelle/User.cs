using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingDienst.Modelle
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public string Bank { get; set; }

        [DataType(DataType.Date)]
        public DateTime Geburtsdatum { get; set; }
        public string Benutzername { get; set; }
        public bool Gesperrt { get; set; }
        public bool Admin { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Guthaben { get; set; }

    }
}
