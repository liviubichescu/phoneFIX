﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneFix.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class phonefixDBEntities : DbContext
    {
        public phonefixDBEntities()
            : base("name=phonefixDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Permision> Permisions { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<RepairSheet> RepairSheets { get; set; }
        public virtual DbSet<Roll> Rolls { get; set; }
        public virtual DbSet<ServiceSheet> ServiceSheets { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Workmanship> Workmanships { get; set; }
    }
}
