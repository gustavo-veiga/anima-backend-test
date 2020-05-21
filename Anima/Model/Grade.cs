using System.Collections.Generic;

namespace Anima.Model
{
    public class Grade
    {
        public int CodGrade { get; set; }
        public string Curso { get; set; }
        public string Turma { get; set; }
        public string Disciplina { get; set; }
        public Professor Docente { get; set; }
        public List<Matricula> Matriculas { get; set; }
    }
}