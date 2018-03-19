using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamPaper.Models
{
    public class _ExamPaper : DbContext
    {
        public _ExamPaper():base("DefaultConnection")
        {
            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<EnglishQuestionBank> QuestionBank { get; set; }
        

    }
}