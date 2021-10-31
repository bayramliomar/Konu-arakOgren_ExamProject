using InterviewProject.Bll;
using InterviewProject.Dal.Concrete.Entity_Framework.Repository;
using InterviewProject.Entities.Entities;
using InterviewProject.Interfaces;
using InterviewProject.MVCWebUI.Identity;
using InterviewProject.MVCWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InterviewProject.MVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _article = new ArticleManager(new EfArticleRepository());
        private readonly IQuestionService _question = new QuestionManager(new EfQuestionRepository());
        private readonly IExamService _exam = new ExamManager(new EfExamRepository());
        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)//, IArticleService article)
        {
            _logger = logger;
            _userManager = userManager;
            //_article = article;
        }

        public IActionResult Index()
        {
            List<ArticleViewModel> list = new List<ArticleViewModel>();
            ArticleViewModel model = new ArticleViewModel();
            var result = WiredHtmlContent.GetHtmlContent();
            foreach (var item in result)
            {
                model.Title = item.Title;
                model.Content = item.Content;
                list.Add(model);
                model = new ArticleViewModel();
            }
            var allArticle = _article.GetAll();
            if (allArticle.Count <= 0)
            {
                foreach (var item in list)
                {
                    Article article = new Article
                    {
                        Content = item.Content,
                        Title = item.Title,
                        CreateDate = DateTime.Now.ToString()
                    };
                    _article.Add(article);
                }
            }
            else
            {
                foreach (var item in list)
                {
                    var isExist = allArticle.Where(x => x.Title == item.Title && x.Content == item.Content).ToList();
                    if (isExist.Count <= 0)
                    {
                        Article article = new Article
                        {
                            Content = item.Content,
                            Title = item.Title
                        };
                        _article.Add(article);
                    }
                }

            }

            return View(list);
        }

        [Authorize]
        public IActionResult CreateExam()
        {
            var list = _article.GetAll().OrderByDescending(x => x.CreateDate).Take(5).Select(x => new ArticleViewModel() { ID = x.Id, Content = x.Content, Title = x.Title }).ToList();
            ExamViewModel model = new ExamViewModel();
            model.Articles = list;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateExam(ExamViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = _userManager.GetUserId(HttpContext.User);
                    string title = _article.Get(model.ArticleTitle).Title;
                    Exam exam = new Exam()
                    {
                        CreateDate = DateTime.Now.ToString(),
                        Name= title,
                        UserId= id
                    };
                    var newExam=_exam.Add(exam);
                    Question question1 = new Question()
                    {
                        Title = model.Question1,
                        Avariant = model.AVRT1,
                        Bvariant = model.BVRT1,
                        Cvariant = model.CVRT1,
                        Dvariant = model.DVRT1,
                        CorrectAnswer = model.CA1,
                        CreateDate = DateTime.Now.ToString(),
                        ArticleId = model.ArticleTitle,
                        ExamId=newExam.Result.Id

                    };
                    Question question2 = new Question()
                    {
                        Title = model.Question2,
                        Avariant = model.AVRT2,
                        Bvariant = model.BVRT2,
                        Cvariant = model.CVRT2,
                        Dvariant = model.DVRT2,
                        CorrectAnswer = model.CA2,
                        CreateDate = DateTime.Now.ToString(),
                        ArticleId = model.ArticleTitle,
                        ExamId = newExam.Result.Id
                    };
                    Question question3 = new Question()
                    {
                        Title = model.Question3,
                        Avariant = model.AVRT3,
                        Bvariant = model.BVRT3,
                        Cvariant = model.CVRT3,
                        Dvariant = model.DVRT3,
                        CorrectAnswer = model.CA3,
                        CreateDate = DateTime.Now.ToString(),
                        ArticleId = model.ArticleTitle,
                        ExamId = newExam.Result.Id
                    };
                    Question question4 = new Question()
                    {
                        Title = model.Question4,
                        Avariant = model.AVRT4,
                        Bvariant = model.BVRT4,
                        Cvariant = model.CVRT4,
                        Dvariant = model.DVRT4,
                        CorrectAnswer = model.CA4,
                        CreateDate = DateTime.Now.ToString(),
                        ArticleId = model.ArticleTitle,
                        ExamId = newExam.Result.Id
                    };
                    var result1=_question.Add(question1);
                    var result2=_question.Add(question2);
                    var result3=_question.Add(question3);
                    var result4=_question.Add(question4);
                    return RedirectToAction("ExamList","Home");
                }
                else
                {
                    model.Articles = _article.GetAll().OrderByDescending(x => x.CreateDate).Take(5).Select(x => new ArticleViewModel() { ID = x.Id, Content = x.Content, Title = x.Title }).ToList();
                    return View(model);
                }
                
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [Authorize]
        public JsonResult FillContent(long id)
        {
            var result = _article.GetAll(x => x.Id == id).FirstOrDefault().Content;
            if (string.IsNullOrEmpty(result))
            {
                result = "";
            }
            return Json(result);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult ExamList()
        {
            var id= _userManager.GetUserId(HttpContext.User);
            var model = _exam.GetAll(x=>x.UserId== id);
            return View(model);
        }

        [Authorize]
        public IActionResult TakeTheExam(long id)
        {
            var questions = _question.GetExam(id);
            return View(questions);
        }

        [Authorize]
        [HttpPost]
        public JsonResult FinishTheExam(long id,List<string> selectedVariant)
        {
            List<string> answer = new List<string>();
            var questions = _question.GetExam(id);
            for (int i = 0; i < 4; i++)
            {
                if (questions[i].CorrectAnswer == selectedVariant[i].ToLower().Substring(0,1))
                {
                    answer.Add("true");
                }
                else
                {
                    answer.Add("false");
                }
            }
            return Json(answer);
        }
        
        [Authorize]
        public IActionResult DeleteExam(long id)
        {
            var list = _question.GetAll(x => x.ExamId == id);
            foreach (var item in list)
            {
                var result = _question.Remove(item.Id);
            }
            var model = _exam.Remove(id);
            return RedirectToAction("ExamList", "Home");
        }
    }
}
