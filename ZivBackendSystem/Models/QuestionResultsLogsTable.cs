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
    
    public partial class QuestionResultsLogsTable
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmailAddress { get; set; }
        public string TimeStamp { get; set; }
        public Nullable<int> QuestionID { get; set; }
        public string QuestionUserAnswer { get; set; }
        public string QuestionAnswerPassOrFail { get; set; }
        public Nullable<int> QuestionAnswerScore { get; set; }
        public Nullable<int> TestNumber { get; set; }
    }
}
