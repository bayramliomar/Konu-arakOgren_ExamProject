using InterviewProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Interfaces
{
    public interface IQuestionService : IGenericService<Question>
    {
        List<Question> GetExam(long id);
    }
}
