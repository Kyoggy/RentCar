namespace rentCar.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using rentCar.Data;
    using rentCar.Models;

    [ApiController]
    [Route("api/carro")]
    public class CarroController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public CarroController(AppDataContext context)
        {
            _ctx = context;
        }

        // GET: api/carro/listar
        [HttpGet]
        [Route("listar")]
        public ActionResult Listar()
        {
            try
            {
                List<Carro> carros = _ctx.Carros.ToList();
                return carros.Count == 0 ? NotFound() : Ok(carros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/carro/buscar/{modelo}
        [HttpGet]
        [Route("buscar/{modelo}")]
        public ActionResult Buscar([FromRoute] string modelo)
        {
            try
            {
                Carro carroCadastrado = _ctx.Carros.FirstOrDefault(x => x.Modelo == modelo);
                return carroCadastrado != null ? Ok(carroCadastrado) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/carro/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public ActionResult Cadastrar([FromBody] Carro carro)
        {
            try
            {
                _ctx.Carros.Add(carro);
                _ctx.SaveChanges();
                return Created("", carro);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/carro/alterar/5
        [HttpPut]
        [Route("alterar/{id}")]
        public IActionResult Alterar([FromRoute] int id, [FromBody] Carro carro)
        {
            try
            {
                Carro carroCadastrado = _ctx.Carros.FirstOrDefault(x => x.CarroId == id);
                if (carroCadastrado != null)
                {
                    carroCadastrado.ValorDia = carro.ValorDia;
                    carroCadastrado.UnidadesDisponiveis = carro.UnidadesDisponiveis;
                    carroCadastrado.Modelo = carro.Modelo;
                    carroCadastrado.UnidadesTotais = carro.UnidadesTotais;
                    _ctx.SaveChanges();
                    return Ok(carro);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/carro/deletar/5
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            try
            {
                Carro carroCadastrado = _ctx.Carros.Find(id);
                if (carroCadastrado != null)
                {
                    _ctx.Carros.Remove(carroCadastrado);
                    _ctx.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
