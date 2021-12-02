using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OsiHoustonInterview.Server.Models;
using OsiHoustonInterview.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsiHoustonInterview.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Random rand = new Random();

            for (int i = 1; i <= 1000; i++)
            {
                string word = "";
                for (int j = 1; j <= 10; j++)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);
                    word += letters[letter_num];
                }

                modelBuilder.Entity<Category>().HasData(
                    new Category
                    {
                        CategoryId = i,
                        Name = word
                    });
            }


            base.OnModelCreating(modelBuilder);
        }
    }
}
