using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaApp.Models
{
    public class AgendaDb : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public AgendaDb(DbContextOptions<AgendaDb> options): base(options)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
