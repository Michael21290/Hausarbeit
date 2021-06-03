using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingDienst.Modelle
{
    public class UserFilm
    {
        public int ID { get; set; }
        public virtual User FUserID { get; set; }
        public virtual Film UFilmID { get; set; }
        public virtual Serie USerienID { get; set; }
        public DateTime LeihDatum { get; set; }
    }
}
