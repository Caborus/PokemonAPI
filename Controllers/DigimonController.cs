using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("Digimon")]
    public class DigimonController : Controller
    {
        private static List<Digimon> digimonList = new() {
            new Digimon(1, "Agumon", "Reptile", "Rookie"),
            new Digimon(2, "Gabumon", "Beast", "Rookie"),
            new Digimon(3, "Palmon", "Vegetation", "Rookie"),
            new Digimon(4, "Patamon", "Mammal", "Rookie"),
            new Digimon(5, "Gomamon", "Aquatic", "Rookie"),
            new Digimon(6, "Tentomon", "Insectoid", "Rookie"),
            new Digimon(7, "Gatomon", "Mammal", "Rookie"),
            new Digimon(8, "Veemon", "Dragon", "Rookie"),
            new Digimon(9, "Hawkmon", "Bird", "Rookie"),
            new Digimon(10, "Armadillomon", "Beast", "Rookie"),
            new Digimon(11, "Kabuterimon", "Insectoid", "Champion"),
            new Digimon(12, "Stingmon", "Insectoid", "Champion"),
            new Digimon(13, "Kuwagamon", "Insectoid", "Champion"),
            new Digimon(14, "Flymon", "Insectoid", "Champion"),
            new Digimon(15, "HerakleKabuterimon", "Insectoid", "Ultimate"),
            new Digimon(16, "Greymon", "Reptile", "Champion"),
            new Digimon(17, "MetalGreymon", "Reptile", "Ultimate"),
            new Digimon(18, "Tyrannomon", "Reptile", "Champion"),
            new Digimon(19, "Seadramon", "Reptile", "Champion"),
            new Digimon(20, "Megidramon", "Reptile", "Mega")
        };

        [HttpPost]
        [Route("AddDigimon")]
        public ActionResult<Digimon> AddDigimon(Digimon digimon){
            if(digimonList.Exists(x => x.Id == digimon.Id)){
                int digimonIndex = digimonList.FindIndex(x => x.Id == digimon.Id) ;
                digimonList[digimonIndex] = digimon;
                return Ok(digimonList[digimonIndex]);
            }
            digimonList.Add(digimon);
            return Ok(digimon);
        }

        [HttpGet]
        public ActionResult<List<Digimon>> GetDigimonList([FromQuery] int? minID,[FromQuery] string? type, [FromQuery] string? desc){
            List<Digimon> newList = new(); 
            if(!digimonList.Any())
                return BadRequest("Digimon Not Found");
            newList = digimonList;
            if(minID != null)
                newList = newList.FindAll(x => x.Id == minID);
            if(type != null)
                newList = newList.FindAll(x => x.Type == type);
            if(desc != null)
                newList = newList.FindAll(x => x.Description == desc);
            return Ok(newList);
        }

        [HttpGet("ByID/{id}")]
        public ActionResult<Digimon> GetDigimonByID(int id){
            if(!digimonList.Exists(x => x.Id == id))
                return BadRequest("Digimon Not Found");
            return digimonList.First(x => x.Id == id);
        }

        [HttpGet("ByName/{name}")]
        public ActionResult<Digimon> GetDigimonByName(string name){
            if(!digimonList.Exists(x => x.Name == name))
                return BadRequest("Digimon Not Found");
            return digimonList.First(x => x.Name == name);
        }

        [HttpGet("ByType/{type}")]
        public ActionResult<List<Digimon>> GetDigimonListByType(string type){
            if(!digimonList.Any(x => x.Type == type))
                return BadRequest("Digimon Not Found");
            return digimonList.FindAll(x => x.Type == type);
        }

        [HttpGet("ByDescription/{desc}")]
        public ActionResult<List<Digimon>> GetDigimonListByDesc(string desc){
            if(!digimonList.Any(x => x.Description == desc))
                return BadRequest("Digimon Not Found");
            return digimonList.FindAll(x => x.Description == desc);
        }
    }


}