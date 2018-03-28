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

        [Required]
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }
        [Required]
        public string OptionA { get; set; }
        [Required]
        public string OptionB { get; set; }

        [Required]
        public string OptionC { get; set; }

        [Required]
        public string OptionD { get; set; }
        [Required]
        public string Answer { get; set; }

        public bool Approve { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual User User { get; set; }  
        public virtual Category Category { get; set; }
    }
}