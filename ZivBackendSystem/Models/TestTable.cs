//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZivBackendSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestTable
    {
        public int Id { get; set; }
        public Nullable<int> TestID { get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public Nullable<int> TestStatus { get; set; }
        public string TestTimeStampStart { get; set; }
        public string TestTimeStampEnd { get; set; }
    }
}