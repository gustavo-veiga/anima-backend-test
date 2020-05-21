using Anima.Model;

namespace Anima.Api.Dto
{
    public class GradePostDto
    {
        public int CodGrade { get; set; }
        public string Curso { get; set; }
        public string Turma { get; set; }
        public string Disciplina { get; set; }
        public int CodFuncionario { get; set; }
        
        public Grade ToGrade(Professor professor)
        {
            return new Grade()
            {
                CodGrade = CodGrade,
                Curso = Curso,
                Turma = Turma,
                Disciplina = Disciplina,
                Docente = professor
            };
        }
    }
}