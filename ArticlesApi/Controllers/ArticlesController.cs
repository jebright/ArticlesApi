using ArticlesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlesApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {

        /// <summary>
        /// Gets Articles published within the supplied time frame
        /// </summary>
        /// <param name="publish_date_to"></param>
        /// <param name="publish_date_from"></param>
        /// <remarks>
        /// Address = {https://localhost:44386/api/articles?}
        /// </remarks>
        /// <returns>List of Articles</returns>
        [HttpGet]
        public IEnumerable<Article> Get(DateTime publish_date_from, DateTime publish_date_to)
        {
            var instruments = new Instrument[] {
                new Instrument(1, "Amazon", "AMZN"),
                new Instrument(2, "Netflix", "NFLX"),
                new Instrument(3, "Google", "GOOG"),
                new Instrument(4, "Roku", "ROKU"),
                new Instrument(5, "Alcoa", "AA"),
                new Instrument(6, "Advance Auto Parts", "AAP"),
                //new Instrument(7, "ABB", "ABB"),
                //new Instrument(8, "AmerisourceBergen", "ABC"),
                //new Instrument(9, "Dominion Diamond Corporation", "DDC"),
                //new Instrument(10, "Asbury Automotive Group", "ABG"),
            };
            var articles = new List<Article>();
            instruments.ToList().ForEach(i =>
            {
                var article = new Article
                {
                    article_id = Guid.NewGuid(),
                    date_published = DateTime.Today,
                    date_created = DateTime.Today.AddDays(-1),
                    perma_link = $"http://example.com",
                    headline = $"Headline for {i.Name}",
                    byline = "Joe Ebright is the author of this article.",
                    authors = new Author[] { new Author {
                        author_id = 1,
                        first_name = "Joe",
                        last_name = "ebright",
                        email = "jebright@fastmail.com",
                        bio = ""
                    }},
                    instruments = new ArticleInstrument[] { new ArticleInstrument
                    {
                        instrument_id = i.Id,
                        symbol = i.Symbol,
                        company_name = i.Name
                    }}
                };
                articles.Add(article);
            });
            return articles;
        }
    }
}
