using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamPaper.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; } 
        public string Password { get; set; }

        public string Education { get; set; }
        public string Institute { get; set; }
        public string Occupation { get; set; }
        public string CellNo { get; set; }

        public string Contributor { get; set; }
        public string PaymentTypeId { get; set; }
        public string PaymentNo { get; set; }
        public string NidOrPassport { get; set; }
        public string Address { get; set; }

        public string Varified { get; set; }

        public virtual ICollection<EnglishQuestionBank> EnglishQuestionBanks { get; set; }
        public virtual ICollection<BanglaQuestionBank> BanglaQuestionBanks { get; set; }
    }
}