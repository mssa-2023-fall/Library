using Microsoft.AspNetCore.Mvc;
using GlizzyFactsDemo;
using GlizzyServices;
using GlizzyServices.GlizzyFacts;


namespace GlizzyFactsDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlizzyFactsController : ControllerBase
    {
        private readonly IGlizzyFacts glizzyFactsRepository;

        public GlizzyFactsController(IGlizzyFacts glizzyFacts)
        {
            this.glizzyFactsRepository = glizzyFacts;
        }


      /*  [HttpGet(Name = "GetGlizzyFacts")]
        public ActionResult<GlizzyFactsController> Get()
        {
            Random random = new Random();
            int randomIndex = random.Next(.Count);
            return glizzyFacts[randomIndex];
        }*/

        [HttpGet]
        public IActionResult GetRandomGlizzyFact()
        {
            GlizzyFact randomFact = glizzyFactsRepository.GetGlizzyFact();

            if (randomFact != null)
            {
                return Ok(randomFact);
            }
            else
            {
                return NotFound(); // Handle the case where no facts are available.
            }
        }

    }
}