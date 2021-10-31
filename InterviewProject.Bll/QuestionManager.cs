using InterviewProject.Dal.Abstract;
using InterviewProject.Entities.Entities;
using InterviewProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Bll
{
    public class QuestionManager : GenericManager<Question>, IQuestionService
    {
        IQuestionRepository _questionRepository;
        public QuestionManager(IQuestionRepository questionRepository) : base(questionRepository)
        {
            this._questionRepository = questionRepository;
        }

        public List<Question> GetExam(long id)
        {
           return _questionRepository.GetExam(id);
        }
    }
}
