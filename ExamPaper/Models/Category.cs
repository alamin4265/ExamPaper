using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamPaper.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }

        public virtual ICollection<EnglishQuestionBank> EnglishQuestionBanks { get; set; }
        public virtual ICollection<BanglaQuestionBank> BanglaQuestionBanks { get; set; }

    }
}