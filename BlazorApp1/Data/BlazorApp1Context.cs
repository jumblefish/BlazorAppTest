using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Models;
//scaffolding tool automatically created this code, registered it with DI container
//creates dbset<Movie> property for the entity set
//entity set typically corresponds to a database table
//An entity corresponds to a row in the table
namespace BlazorApp1.Data
{
    public class BlazorApp1Context : DbContext
    {
        public BlazorApp1Context (DbContextOptions<BlazorApp1Context> options)
            : base(options)
        {
        }

        public DbSet<BlazorApp1.Models.Movie> Movie { get; set; } = default!;
    }
}
