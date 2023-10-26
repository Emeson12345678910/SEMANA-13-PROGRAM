using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_semana_13;

using Microsoft.EntityFrameworkCore;
public class Context : DbContext
{
    public DbSet<Student> ALUMNOS { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-NFDMETJ\\SQLEXPRESS01;Database=Actividad; Trusted_Connection = SSPI; MultipleActiveResultSets = true;");
    }
}
