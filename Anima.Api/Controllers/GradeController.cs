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
    [Route("school/grade")]
    public class GradeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GradeGetDto>> Get([FromServices] AppDbContext dbContext, [FromQuery] int codGrade)
        {
            var grade = await dbContext.Grades
                .Where(x => x.CodGrade == codGrade)
                .Include(x => x.Docente)
                .FirstAsync();
            var alunos = await dbContext.Grades
                .Where(x => x.CodGrade == codGrade)
                .SelectMany(x => x.Matriculas)
                .Select(x => x.Aluno)
                .ToListAsync();
            return new GradeGetDto(grade, alunos);
        }

        [HttpPost]
        public async Task<ActionResult<GradePostDto>> Post([FromServices] AppDbContext dbContext, [FromBody] GradePostDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var professor = await dbContext.Professores
                .FindAsync(model.CodFuncionario);
            await dbContext.Grades.AddAsync(model.ToGrade(professor));
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}