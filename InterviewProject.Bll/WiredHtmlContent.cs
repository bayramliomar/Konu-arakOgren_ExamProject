using HtmlAgilityPack;
using InterviewProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Bll
{
    public static class WiredHtmlContent
    {
        public static List<Article> GetHtmlContent()
        {
            using (WebClient web = new WebClient())
            {
                List<Article> list = new List<Article>();
                Article article = new Article();
                string url = "https://www.wired.com/";
                string htmlContent = web.DownloadString(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlContent);
                for (int i = 1; i < 6; i++)
                {
                    var anchorElement = doc.DocumentNode.SelectNodes("//*[@id='main-content']/div[1]/div[1]/section/div[3]/div/div/div/div/div[" + i +"]/div[2]/a");
                    var href = anchorElement.Select(node => node.GetAttributeValue("href", null));
                    var content = getArticleContent(href.ToList()[0]);
                    HtmlNode title = doc.DocumentNode.SelectSingleNode("//*[@id='main-content']/div[1]/div[1]/section/div[3]/div/div/div/div/div[" + i + "]/div[2]/a/h2");
                    article.Content = content;
                    article.Title = title.InnerText;
                    list.Add(article);
                    article = new Article();
                    // images.Add(image.InnerHtml);
                }
                // all.Add(images);
                return list;
            }
        }

        public static string getArticleContent(string link)
        {
            try
            {

                using (WebClient web = new WebClient())
                {
                    HtmlNode content = null;
                    string[] xpath = new string[] {
                "//*[@id='main-content']/article/div[2]/div/div/div/div[1]/div",
                "//*[@id='start-of-content']/article",
                "//*[@id='main-content']/article/div[2]/div[1]/div[1]/div[1]/div/div[1]/div",
                "//*[@id='main-content']/article/div[2]/div/div/div[1]/div/div/div",
                "//*[@id='main-content']/article/div[2]/div/div[1]/div/div[1]/div",
                "//*[@id='main-content']/article/div[2]/div[1]/div[1]/div[1]/div/div[1]",
                "//*[@id='main-content']/article/div[2]/div/div[1]/div/div[1]/div/p"
                };
                    string url = "https://www.wired.com" + link;
                    string htmlContent = web.DownloadString(url);
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(htmlContent);
                    foreach (var item in xpath)
                    {
                        content = doc.DocumentNode.SelectSingleNode(item);
                        if (content != null)
                        {
                            break;
                        }
                    }
                    return content.InnerText;
                }

            }
            catch (Exception)
            {

                return "";
            }
        }
    }
}
