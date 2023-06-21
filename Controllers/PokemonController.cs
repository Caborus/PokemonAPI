using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAPI.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/Pokemon")]
    public class PokemonController : ControllerBase{
        private PokemonDbContext _context;
        public PokemonController(PokemonDbContext context){ 
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<List<Pokemon>> GetAllPokemon([FromQuery] int? id){
            if(!_context.Pokemons.Any())
                return BadRequest("Pokemon Not Found");
            if(id != null){
                if(!_context.Pokemons.Any(x => x.Id == id))
                    return BadRequest("Pokemon Not Found");
                return Ok(_context.Pokemons.Include(x => x.EvolutionPokemons).Include(x => x.Abilities).Where(p => p.Id == id));
            }
            return Ok(_context.Pokemons.Include(x => x.EvolutionPokemons));
        }
    }
}
