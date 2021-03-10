using EvaluacionTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EvaluacionTecnica.DBContext
{
    public class MyDBcontext: DbContext
    {
        public MyDBcontext() : base("name=DBCore")
        {

        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

    }
}