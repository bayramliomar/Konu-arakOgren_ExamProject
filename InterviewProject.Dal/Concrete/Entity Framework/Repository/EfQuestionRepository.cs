using InterviewProject.Dal.Abstract;
using InterviewProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Dal.Concrete.Entity_Framework.Repository
{
    public class EfQuestionRepository:EfGenericRepository<Question>, IQuestionRepository
    {
        public EfQuestionRepository():base()
        {

        }

        public List<Question> GetExam(long id)
        {
            return _dbContext.Questions.Where(x=>x.ExamId==id).Include(s => s.Exam).Include(s => s.Article).ToList();
        }
    }
}
