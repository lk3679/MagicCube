//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Menu_AuthorsTag
    {
        public Menu_AuthorsTag()
        {
            this.AuthorsPropTag = new HashSet<AuthorsPropTag>();
        }
    
        public int AuthorsTagNo { get; set; }
        public string AuthorsTagName { get; set; }
        public string IsDel { get; set; }
    
        public virtual ICollection<AuthorsPropTag> AuthorsPropTag { get; set; }
    }
}
