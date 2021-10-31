using InterviewProject.Dal.Abstract;
using InterviewProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Dal.Concrete.Entity_Framework.Repository
{
   public class EfArticleRepository : EfGenericRepository<Article>, IArticleRepository
    {
        public EfArticleRepository() : base()
        {

        }
    }
}
