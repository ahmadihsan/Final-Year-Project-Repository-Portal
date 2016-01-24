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
    
    public partial class MileStoneEvaluation
    {
        public long MSEId { get; set; }
        public long ProjectId { get; set; }
        public long StudentId { get; set; }
        public string CommentByPC { get; set; }
        public Nullable<long> CommentedBy { get; set; }
        public string CommentByHead { get; set; }
        public string CommentedByPCHead { get; set; }
        public Nullable<System.DateTime> ComentedDate { get; set; }
        public long PMSId { get; set; }
        public string CommentByPcAboutProject { get; set; }
        public bool IsVisibletToStudent { get; set; }
        public Nullable<long> PSId { get; set; }
        public string CommentByExternal { get; set; }
        public string CommentBySupervisor { get; set; }
        public Nullable<bool> EvaluationStatus { get; set; }
        public Nullable<double> ObtainMarks { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual ProjectMileStone ProjectMileStone { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}