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
    public class ExamManager : GenericManager<Exam>, IExamService
    {
        IExamRepository _examRepository;
        public ExamManager(IExamRepository examRepository) : base(examRepository)
        {
            this._examRepository = examRepository;
        }
    }
}
