using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.Modelle;

namespace StreamingDienst.Data
{
    public class StreamingDienstContext : DbContext
    {
        public StreamingDienstContext (DbContextOptions<StreamingDienstContext> options)
            : base(options)
        {
        }

        public DbSet<StreamingDienst.Modelle.User> User { get; set; }

        public DbSet<StreamingDienst.Modelle.Film> Film { get; set; }

        public DbSet<StreamingDienst.Modelle.Serie> Serie { get; set; }

        public DbSet<StreamingDienst.Modelle.Folge> Folge { get; set; }

        public DbSet<StreamingDienst.Modelle.Genre> Genre { get; set; }

        public DbSet<StreamingDienst.Modelle.UserFilm> UserFilm { get; set; }
    }
}
