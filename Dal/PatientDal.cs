﻿using Microsoft.EntityFrameworkCore;
using MVCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCore.Dal
{
    public class PatientDal : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-KC478R8;Initial Catalog=PatientDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientModel>().ToTable("tblPatient");  //Mapping
            modelBuilder.Entity<PatientModel>().HasKey(p => p.PatientName);  //Primary key
            modelBuilder.Entity<Problem>().ToTable("tblProblem");
            modelBuilder.Entity<Problem>().HasKey(p => p.id);
            modelBuilder.Entity<PatientModel>()
                .HasMany(c => c.Problems)
                .WithOne(e => e.Patient);
        }
        
        public DbSet<PatientModel> PatientModels { get; set; }
    }
}
