using Anima.Model;

namespace Anima.Api.Dto
{
    public class ProfessorPostDto : Usuario
    {
        public  ProfessorPostDto() { }
        
        public ProfessorPostDto(Professor professor)
        {
            Codigo = professor.CodFuncionario;
            Cpf = professor.Cpf;
            Nome = professor.Nome;
            Email = professor.Email;
            Login = professor.Login;
            Senha = professor.Senha;
        }
        
        public int Codigo { get; set; }

        public Professor ToProfessor()
        {
            return new Professor()
            {
                CodFuncionario = Codigo,
                Cpf = Cpf,
                Nome = Nome,
                Email = Email,
                Login = Login,
                Senha = Senha,
            };
        }
    }
}