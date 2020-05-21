using System.Collections.Generic;
using System.Linq;
using Anima.Model;

namespace Anima.Api.Dto
{
    public class GradeGetDto
    {
        public int CodGrade { get; set; }
        public string Curso { get; set; }
        public string Turma { get; set; }
        public string Disciplina { get; set; }
        public int CodFuncionario { get; set; }
        public string NomeProfessor { get; set; }
        public string CpfProfessor { get; set; }
        public string EmailProfessor { get; set; }
        public List<GradeAlunoGetDto> Alunos { get; set; } = new List<GradeAlunoGetDto>();
        
        public GradeGetDto() { }

        public GradeGetDto(Grade grade, List<Aluno> alunos)
        {
            CodGrade = grade.CodGrade;
            Turma = grade.Turma;
            Disciplina = grade.Disciplina;
            CodFuncionario = grade.Docente.CodFuncionario;
            NomeProfessor = grade.Docente.Nome;
            CpfProfessor = grade.Docente.Cpf;
            EmailProfessor = grade.Docente.Email;
            foreach (var aluno in alunos)
            {
                Alunos.Add(new GradeAlunoGetDto(aluno));
            }
        }
    }
}