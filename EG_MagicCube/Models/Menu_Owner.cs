//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EG_MagicCube.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menu_Owner
    {
        public Menu_Owner()
        {
            this.Works_Prop_Owner = new HashSet<Works_Prop_Owner>();
        }
    
        public int Owner_No { get; set; }
        public string Owner_Name { get; set; }
    
        public virtual ICollection<Works_Prop_Owner> Works_Prop_Owner { get; set; }
    }
}
