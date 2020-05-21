using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anima.Api.Dto;
using Anima.Api.Services;
using Anima.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anima.Api.Controllers
{
    [ApiController]
    [Route("school/aluno")]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<AlunoDto>>> Get([FromServices] AppDbContext dbContext)
        {
            var alunos = await dbContext.Alunos
                .AsNoTracking()
                .Select(aluno => new AlunoDto(aluno))
                .ToListAsync();
            return alunos;
        }

        public async Task<ActionResult<AlunoDto>> Post([FromServices] AppDbContext dbContext, [FromBody] Aluno model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await dbContext.Alunos.AddAsync(model);
            await dbContext.SaveChangesAsync();
            return new AlunoDto(model);
        }
    }
}