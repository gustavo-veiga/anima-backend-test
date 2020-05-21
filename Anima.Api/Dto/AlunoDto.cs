using Anima.Model;

namespace Anima.Api.Dto
{
    public class AlunoDto : Usuario
    {
        public AlunoDto() { }
        public AlunoDto(Aluno aluno)
        {
            Ra = aluno.Ra;
            Cpf = aluno.Cpf;
            Nome = aluno.Nome;
            Email = aluno.Email;
            Login = aluno.Login;
            Senha = aluno.Senha;
        }
        public int Ra { get; set; }
    }
}