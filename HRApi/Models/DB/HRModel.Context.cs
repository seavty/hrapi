﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRApi.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HR_DHLEntities : DbContext
    {
        public HR_DHLEntities()
            : base("name=HR_DHLEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<tblEmployee> tblEmployees { get; set; }
        public virtual DbSet<tblLeave> tblLeaves { get; set; }
        public virtual DbSet<tblPayroll> tblPayrolls { get; set; }
        public virtual DbSet<tblPayrollBenefit> tblPayrollBenefits { get; set; }
    }
}
