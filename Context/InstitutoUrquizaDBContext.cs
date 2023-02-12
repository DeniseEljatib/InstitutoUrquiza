using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstitutoUrquiza.Models;

namespace InstitutoUrquiza.Context
{
    public class InstitutoUrquizaDBContext : DbContext    {


        public InstitutoUrquizaDBContext(DbContextOptions<InstitutoUrquizaDBContext> options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        
        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<Clase> Clases { get; set; }

        



    }
}

