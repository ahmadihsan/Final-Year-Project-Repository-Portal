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
    
    public partial class ProjectDirectory
    {
        public long PDId { get; set; }
        public Nullable<long> ProjectId { get; set; }
        public string UploadedFile { get; set; }
        public string Description { get; set; }
        public Nullable<long> psId { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual ProjectSession ProjectSession { get; set; }
    }
}
