using Anima.Model;

namespace Anima.Api.Dto
{
    public class MatriculaDto
    {
        public int CodGrade { get; set; }
        public int Ra { get; set; }

        public Matricula ToMatricula()
        {
            return new Matricula
            {
                CodGrade = CodGrade,
                Ra = Ra
            };
        }
    }
}