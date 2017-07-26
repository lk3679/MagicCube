//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EG_MagicCubeEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Works
    {
        public Works()
        {
            this.PackageItems = new HashSet<PackageItems>();
            this.WorksAuthors = new HashSet<WorksAuthors>();
            this.WorksFiles = new HashSet<WorksFiles>();
            this.WorksPropGenre = new HashSet<WorksPropGenre>();
            this.WorksPropOwner = new HashSet<WorksPropOwner>();
            this.WorksPropStyle = new HashSet<WorksPropStyle>();
            this.WorksPropWareType = new HashSet<WorksPropWareType>();
            this.WorksModules = new HashSet<WorksModules>();
        }
    
        public System.Guid WorksNo { get; set; }
        public string MaterialsID { get; set; }
        public int AuthorsNo { get; set; }
        public string WorksName { get; set; }
        public short YearStart { get; set; }
        public short YearEnd { get; set; }
        public string Remarks { get; set; }
        public int Cost { get; set; }
        public int Price { get; set; }
        public System.DateTime PricingDate { get; set; }
        public double GrossMargin { get; set; }
        public double Marketability { get; set; }
        public double Packageability { get; set; }
        public double Valuability { get; set; }
        public double Artisticability { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    
        public virtual ICollection<PackageItems> PackageItems { get; set; }
        public virtual ICollection<WorksAuthors> WorksAuthors { get; set; }
        public virtual ICollection<WorksFiles> WorksFiles { get; set; }
        public virtual ICollection<WorksPropGenre> WorksPropGenre { get; set; }
        public virtual ICollection<WorksPropOwner> WorksPropOwner { get; set; }
        public virtual ICollection<WorksPropStyle> WorksPropStyle { get; set; }
        public virtual ICollection<WorksPropWareType> WorksPropWareType { get; set; }
        public virtual ICollection<WorksModules> WorksModules { get; set; }
    }
}
