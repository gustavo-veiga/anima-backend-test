using System.Linq;
using System.Threading.Tasks;
using Anima.Api.Dto;
using Anima.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Anima.Api.Controllers
{
    [ApiController]
    [Route("school/professor")]
    public class ProfessorController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProfessorGetDto>> Get(
            [FromServices] AppDbContext dbContext,
            [FromQuery] string cpf)
        {
            var professor = await dbContext.Professores
                .Where(x => x.Cpf == cpf)
                .AsNoTracking()
                .FirstAsync();
            var grades = await dbContext.Grades
                .Include(x => x.Docente)
                .Where(x => x.Docente == professor)
                .AsNoTracking()
                .ToListAsync();
            var alunos = from p in dbContext.Professores
                join g in dbContext.Grades on p equals g.Docente
                join m in dbContext.Matriculas on g.CodGrade equals m.CodGrade
                where p.Cpf == cpf
                select new
                {
                    AlunoRa = m.Ra,
                    DocenteCpf = p.Cpf,
                    CodigoGrade = g.CodGrade
                };
            return new ProfessorGetDto(professor, alunos.Count(), grades.Count());
        }

        [HttpPost]
        public async Task<ActionResult<ProfessorPostDto>> Post(
            [FromServices] AppDbContext dbContext,
            [FromBody] ProfessorPostDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await dbContext.Professores.AddAsync(model.ToProfessor());
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}