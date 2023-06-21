using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Digimon
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Type{get; set;}
        public string Description{get; set;}

        public Digimon( int id, string nameIn, string type, string description ) {
            this.Id = id;
            this.Name = nameIn;
            this.Type = type;
            this.Description = description;
        }

    }
}