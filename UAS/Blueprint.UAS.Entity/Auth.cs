//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blueprint.UAS.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auth
    {
        public Auth()
        {
            this.Seq = 0;
            this.Rule = new HashSet<Rule>();
        }
    
        public string Code { get; set; }
        public string Description { get; set; }
        public int Seq { get; set; }
    
        public virtual ICollection<Rule> Rule { get; set; }
    }
}
