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
    
    public partial class Menu_Genre
    {
        public Menu_Genre()
        {
            this.WorksPropGenre = new HashSet<WorksPropGenre>();
        }
    
        public int GenreNo { get; set; }
        public string GenreName { get; set; }
    
        public virtual ICollection<WorksPropGenre> WorksPropGenre { get; set; }
    }
}
