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
   public class ArticleManager : GenericManager<Article>, IArticleService
    {
        IArticleRepository _articleRepository;
        public ArticleManager(IArticleRepository articleRepository) : base(articleRepository)
        {
            this._articleRepository = articleRepository;
        }
    }
}
