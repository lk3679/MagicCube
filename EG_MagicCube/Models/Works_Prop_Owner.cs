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
    
    public partial class Works_Prop_Owner
    {
        public int Works_Prop_Owner_No { get; set; }
        public System.Guid Works_No { get; set; }
        public int Owner_No { get; set; }
    
        public virtual Menu_Owner Menu_Owner { get; set; }
        public virtual Works_List Works_List { get; set; }
    }
}
