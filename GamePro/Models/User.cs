//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamePro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Ring = new HashSet<Ring>();
        }
    
        public int ID { get; set; }
        public string nickname { get; set; }
        public string game_name { get; set; }
        public string region_name { get; set; }
        public string area_wx { get; set; }
        public string level { get; set; }
        public string phone { get; set; }
        public string code { get; set; }
        public string password { get; set; }
        public string InvitationCode { get; set; }
        public Nullable<int> NumberOfDiamonds { get; set; }
        public string OpenID { get; set; }
        public string Beizhu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ring> Ring { get; set; }
    }
}
