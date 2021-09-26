using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ActorRepository actorRepository;
        public ActorController()
        {
            actorRepository = new ActorRepository();
        }
        [HttpGet]
        public IEnumerable<Actor> GetAllActorsNames()
        {
            try
            {
                var actors = actorRepository.GetAllActorNames();
                return actors;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public void AddActor([FromBody]Actor actor)
        {
            if(ModelState.IsValid)
            {
                actorRepository.AddActor(actor);
            }
        }
    }
}
