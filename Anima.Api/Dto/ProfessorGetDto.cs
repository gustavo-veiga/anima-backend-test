using System;
using Anima.Model;

namespace Anima.Api.Dto
{
    public class ProfessorGetDto
    {
        public int CodFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int TotalGrades { get; set; }
        public int TotalAlunos { get; set; }
        public decimal Salario { get; set; }
        
        public ProfessorGetDto() { }

        public ProfessorGetDto(Professor professor, int totalGrades, int totalAlunos)
        {
            CodFuncionario = professor.CodFuncionario;
            Nome = professor.Nome;
            Cpf = professor.Cpf;
            Email = professor.Email;
            TotalGrades = totalGrades;
            TotalAlunos = totalAlunos;
            Salario = professor.Salario(totalAlunos, totalGrades);
        }
    }
}