using Anima.Model;

namespace Anima.Api.Dto
{
    public class GradeAlunoGetDto
    {
        public int Ra { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        
        public GradeAlunoGetDto() { }

        public GradeAlunoGetDto(Aluno aluno)
        {
            Ra = aluno.Ra;
            Nome = aluno.Nome;
            Email = aluno.Email;
        }
    }
}