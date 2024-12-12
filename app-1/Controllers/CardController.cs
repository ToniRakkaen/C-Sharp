using app_1.Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        public static List<Card> cards = new List<Card>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(cards);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {


                var card = cards.SingleOrDefault(x => x.Id == id);
                if (card == null)
                {
                    return NotFound();
                }
                return Ok(card);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(Card card)
        {
            var gameCard = new Card
            {
                Id = card.Id,
                Title = card.Title,
                Description = card.Description,
                img = card.img
            };
            cards.Add(gameCard);
            return Ok(cards);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCard(int id, Card card)
        {
            try
            {



                var temp = cards.SingleOrDefault(x => x.Id == id);
                if (temp == null)
                {
                    Console.WriteLine("Chay vao temp == null");
                    return BadRequest();
                }
                Console.WriteLine(temp.Id);
                if (id == temp.Id)
                {
                    if (card == null)
                    {
                        return NotFound();
                    }
                    temp.Id = card.Id;
                    return Ok(card);
                }
                else
                {
                    Console.WriteLine("i temp.id");
                    return BadRequest();
                }

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

