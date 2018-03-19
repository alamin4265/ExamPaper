using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamPaper.Models
{
    [Table("EnglishQuestionBank")]
    public class EnglishQuestionBank
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string Verified { get; set; }
        public int Answer { get; set; }
        public string Approve { get; set; }
        public int UserId { get; set; }
        public int CategoyId { get; set; }

        public virtual User User { get; set; }  
        public virtual Category Category { get; set; }
    }
}