using Microsoft.AspNetCore.Mvc;
using pizza.models;
using pizza.services;

namespace pizza.controller
{
    [ApiController]
    [Route("/api")]
    public class PizzaController : ControllerBase
    {

        [HttpGet]
        [Route("pizzas")]
        public ActionResult<List<Pizza>> GetAllPizzas()
        {
            return PizzaService.GetAllPizzas();
        }

        [HttpGet()]
        [Route("pizzas/{id}")]
        public ActionResult<Pizza> GetPizzaById(string id)
        {
            var p = PizzaService.GetPizzaByID(id);

            if (p is null)
            {
                return NotFound();
            }

            return p;

        }

        [HttpPost]
        [Route("pizzas")]
        public IActionResult AddPizza(Pizza p)
        {
            PizzaService.AddPizza(p);
            return CreatedAtAction(nameof(GetPizzaById), new { id = p.Id }, p);
        }

        [HttpPut()]
        [Route("pizzas/{id}")]
        public IActionResult UpdatePizza(string id, Pizza p)
        {
            if (Guid.Parse(id) != p.Id)
            {
                return BadRequest();
            }

            var existingPizza = PizzaService.GetPizzaByID(id);

            if (existingPizza is null)
            {
                return BadRequest();
            }

            PizzaService.UpdatePizza(p);
            return NoContent();
        }

        [HttpDelete()]
        [Route("pizzas/{id}")]
        public IActionResult Delete([FromRoute] string id)
        {

            var pizza = PizzaService.GetPizzaByID(id);

            if (pizza is null)
                return NotFound();

            PizzaService.RemovePizzaById(id);

            return NoContent();
        }
    }
}