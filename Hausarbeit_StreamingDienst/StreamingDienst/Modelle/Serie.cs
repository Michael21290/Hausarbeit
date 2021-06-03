using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingDienst.Modelle
{
    public class Serie
    {
        public int ID { get; set; }
        public string SerienTitel { get; set; }
        public int AnzahlFolgen { get; set; }
        public Genre SGenreID { get; set; }
    }
}
