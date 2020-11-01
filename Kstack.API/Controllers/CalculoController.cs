using System;
using System.Dynamic;
using Kstack.Domain;
using Kstack.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kstack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly IKstackRepository _repo;

        public CalculoController(IKstackRepository repo) 
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Post(Calculo model) 
        {
           double distancia = 0;
           double litros = 0;
           Resultado resultado = new Resultado();
        
           if(model.Tempo >= 0 && model.Velocidade >= 0)
           {
               distancia =  _repo.CalcularDistancia(model.Tempo, model.Velocidade);
           } 

           if(model.KmPorLitro >= 0 && distancia >= 0)
           {
               litros =  _repo.CalcularLitros(distancia, model.KmPorLitro);
           }         

           resultado.KmPorLitro = model.KmPorLitro;
           resultado.Tempo = model.Tempo;
           resultado.Velocidade = model.Velocidade;
           resultado.Distancia = distancia;
           resultado.LitrosUsados = litros;

           var json = Newtonsoft.Json.JsonConvert.SerializeObject(resultado);

           return Ok(json);
        }
    }
}