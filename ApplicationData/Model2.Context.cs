﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace library.ApplicationData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class booksEntities1 : DbContext
    {
        public booksEntities1()
            : base("name=booksEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<authors> authors { get; set; }
        public DbSet<binding> binding { get; set; }
        public DbSet<books> books { get; set; }
        public DbSet<favourites> favourites { get; set; }
        public DbSet<genres> genres { get; set; }
        public DbSet<journal> journal { get; set; }
        public DbSet<publishing> publishing { get; set; }
        public DbSet<role> role { get; set; }
        public DbSet<t_of_literature> t_of_literature { get; set; }
        public DbSet<user> user { get; set; }
    }
}
