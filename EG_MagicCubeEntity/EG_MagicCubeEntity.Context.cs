﻿//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EG_MagicCubeEntity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EG_MagicCubeEntities : DbContext
    {
        public EG_MagicCubeEntities()
            : base("name=EG_MagicCubeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Authors> Authors { get; set; }
        public DbSet<AuthorsPropArea> AuthorsPropArea { get; set; }
        public DbSet<AuthorsPropTag> AuthorsPropTag { get; set; }
        public DbSet<Menu_AuthorsArea> Menu_AuthorsArea { get; set; }
        public DbSet<Menu_AuthorsTag> Menu_AuthorsTag { get; set; }
        public DbSet<Menu_CountNoun> Menu_CountNoun { get; set; }
        public DbSet<Menu_Genre> Menu_Genre { get; set; }
        public DbSet<Menu_Material> Menu_Material { get; set; }
        public DbSet<Menu_Owner> Menu_Owner { get; set; }
        public DbSet<Menu_Style> Menu_Style { get; set; }
        public DbSet<Menu_WareType> Menu_WareType { get; set; }
        public DbSet<PackageItems> PackageItems { get; set; }
        public DbSet<Packages> Packages { get; set; }
        public DbSet<UserAccountRoles> UserAccountRoles { get; set; }
        public DbSet<UserAccounts> UserAccounts { get; set; }
        public DbSet<Works> Works { get; set; }
        public DbSet<WorksAuthors> WorksAuthors { get; set; }
        public DbSet<WorksFiles> WorksFiles { get; set; }
        public DbSet<WorksPropGenre> WorksPropGenre { get; set; }
        public DbSet<WorksPropOwner> WorksPropOwner { get; set; }
        public DbSet<WorksPropStyle> WorksPropStyle { get; set; }
        public DbSet<WorksPropWareType> WorksPropWareType { get; set; }
        public DbSet<SystemConfigure> SystemConfigure { get; set; }
        public DbSet<WorksModules> WorksModules { get; set; }
    }
}
