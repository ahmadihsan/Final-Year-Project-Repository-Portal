//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FYPDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UploadedMileStoneDoc
    {
        public long UMSDId { get; set; }
        public Nullable<long> InCustody { get; set; }
        public System.DateTime CustodianDate { get; set; }
        public Nullable<System.DateTime> StatusDate { get; set; }
        public Nullable<long> UMSId { get; set; }
        public Nullable<bool> ToAdmin { get; set; }
        public Nullable<bool> FromPC { get; set; }
        public Nullable<bool> FromStudent { get; set; }
        public Nullable<bool> ReadStatus { get; set; }
        public Nullable<long> ForwardedTo { get; set; }
        public string StatusComment { get; set; }
        public Nullable<bool> EvalStatus { get; set; }
        public Nullable<bool> CustodyHistory { get; set; }
    
        public virtual UploadedMileStone UploadedMileStone { get; set; }
        public virtual UploadedMileStone UploadedMileStone1 { get; set; }
        public virtual User User { get; set; }
    }
}
