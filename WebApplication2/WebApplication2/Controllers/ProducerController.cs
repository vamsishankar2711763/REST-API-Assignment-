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
    public class ProducerController : ControllerBase
    {
        private readonly ProducerRepository producerRepository;
        public ProducerController()
        {
            producerRepository = new ProducerRepository();
        }
        
        [HttpGet]
        public IEnumerable<Producer> GetAllProducerNames()
        {
            try
            {
                var producers = producerRepository.GetAllProducerNames();
                return producers;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public void AddProducer([FromBody] Producer producer)
        {
            if (ModelState.IsValid)
            {
                producerRepository.AddProducer(producer);
            }
        }
    }
}
