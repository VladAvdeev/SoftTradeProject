﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradePlusAdmin.Source.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SoftTradePlusEntities : DbContext
    {
        public SoftTradePlusEntities()
            : base("name=SoftTradePlusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientStatu> ClientStatus { get; set; }
        public virtual DbSet<ClientType> ClientTypes { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Product_Type> Product_Type { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Purchased_Box> Purchased_Box { get; set; }
    }
}