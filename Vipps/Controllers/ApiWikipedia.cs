using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vipps.Models;
using Vipps.Services;

namespace Vipps.Controllers
{
    
    [Route("api/[action]")]
    public class ApiWikipedia : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Wikipedia(string searchTopic)
        {
            SearchWord searchWord = new SearchWord();
            WikipediaResponse response = await searchWord.GetArticleFromWikipedia(searchTopic);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}