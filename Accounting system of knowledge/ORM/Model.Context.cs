﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Accountimg_system_of_knowledgeEntities : DbContext
    {
        public Accountimg_system_of_knowledgeEntities()
            : base("name=Accountimg_system_of_knowledgeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Login_Mail> Login_Mail { get; set; }
        public virtual DbSet<Programmer> Programmer { get; set; }
        public virtual DbSet<Programmer_Sphere> Programmer_Sphere { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sphere> Sphere { get; set; }
    }
}