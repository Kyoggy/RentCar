namespace rentCar.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using rentCar.Data;
    using rentCar.Models;

    [ApiController]
    [Route("api/aluguel")]
    public class AluguelController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public AluguelController(AppDataContext context)
        {
            _ctx = context;
        }

        // POST: api/aluguel/registrar
        [HttpPost]
        [Route("registrar")]
        public ActionResult RegistrarAluguel([FromBody] Aluguel aluguel)
        {
            try
            {
                // Verifica se o cliente e o carro existem
                Cliente clienteCadastrado = _ctx.Clientes.Find(aluguel.ClienteId);
                Carro carroCadastrado = _ctx.Carros.Find(aluguel.CarroId);

                if (clienteCadastrado == null || carroCadastrado == null)
                {
                    return NotFound("Cliente ou Carro não encontrado.");
                }

                // Calcula o valor total com base nos dias de aluguel e valor diário do carro
                aluguel.ValorTotal = aluguel.DiasAlugados * carroCadastrado.ValorDia;

                // Adiciona o aluguel ao contexto e salva as alterações
                _ctx.Alugueis.Add(aluguel);
                _ctx.SaveChanges();

                return Created("", aluguel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/aluguel/alterar/5
        [HttpPut]
        [Route("alterar/{id}")]
        public IActionResult AlterarAluguel([FromRoute] int id, [FromBody] Aluguel aluguel)
        {
            try
            {
                Aluguel aluguelCadastrado = _ctx.Alugueis.FirstOrDefault(x => x.AluguelId == id);

                if (aluguelCadastrado != null)
                {
                    // Atualiza os dados do aluguel
                    aluguelCadastrado.DataInicio = aluguel.DataInicio;
                    aluguelCadastrado.DataTermino = aluguel.DataTermino;
                    aluguelCadastrado.DiasAlugados = aluguel.DiasAlugados;

                    // Calcula o novo valor total com base nos dias de aluguel e valor diário do carro
                    Carro carroCadastrado = _ctx.Carros.Find(aluguelCadastrado.CarroId);
                    aluguelCadastrado.ValorTotal = aluguel.DiasAlugados * carroCadastrado.ValorDia;

                    _ctx.SaveChanges();
                    return Ok(aluguelCadastrado);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/aluguel/excluir/5
        [HttpDelete]
        [Route("excluir/{id}")]
        public IActionResult ExcluirAluguel([FromRoute] int id)
        {
            try
            {
                Aluguel aluguelCadastrado = _ctx.Alugueis.Find(id);

                if (aluguelCadastrado != null)
                {
                    _ctx.Alugueis.Remove(aluguelCadastrado);
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
