
using System;
using System.Linq;
using System.Threading.Tasks;
using Anima.Api.Dto;
using Anima.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anima.Api.Controllers
{
    [ApiController]
    [Route("school/matricula")]
    public class MatriculaController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<MatriculaDto>> Post(
            [FromServices] AppDbContext dbContext,
            [FromBody] MatriculaDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var qtdAlunos = dbContext.Matriculas.Count(x => x.CodGrade == model.CodGrade);
            if (qtdAlunos >= 10)
            {
                var grade = await dbContext.Grades.FindAsync(model.CodGrade);
                var codigo = dbContext.Grades
                    .Where(x => x.Curso == grade.Curso)
                    .Where(x => x.Turma == grade.Turma)
                    .Where(x => x.Disciplina == grade.Disciplina)
                    .Max(x => x.CodGrade);
                qtdAlunos = dbContext.Matriculas.Count(x => x.CodGrade == codigo);
                if (qtdAlunos >= 10)
                {
                    codigo = dbContext.Grades
                        .Max(x => x.CodGrade);
                    grade.CodGrade = ++codigo;
                    await dbContext.AddAsync(grade);
                    await dbContext.SaveChangesAsync();
                    model.CodGrade = grade.CodGrade;
                }
                model.CodGrade = codigo;
            }
            await dbContext.AddAsync(model.ToMatricula());
            await dbContext.SaveChangesAsync();
            return model;
        }

        [HttpDelete]
        public async Task<ActionResult<MatriculaDto>> Delete(
            [FromServices] AppDbContext dbContext,
            [FromBody] MatriculaDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            dbContext.Remove(model.ToMatricula());
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}