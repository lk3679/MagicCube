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
    
    public partial class WorksModules
    {
        public int WorksModulesNo { get; set; }
        public System.Guid WorksNo { get; set; }
        public int Material { get; set; }
        public string Measure { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Deep { get; set; }
        public string TimeLength { get; set; }
        public int Amount { get; set; }
        public int CountNoun { get; set; }
    
        public virtual Menu_CountNoun Menu_CountNoun { get; set; }
        public virtual Menu_Material Menu_Material { get; set; }
        public virtual Works Works { get; set; }
    }
}
