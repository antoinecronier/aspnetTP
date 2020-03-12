using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoading
{
    public class Context : DbContext
    {
        public Context()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Personne> Personnes { get; set; }

    }
}
