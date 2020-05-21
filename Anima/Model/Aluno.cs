using System.Collections.Generic;

namespace Anima.Model
{
    public class Aluno : Usuario
    {
        public int Ra { get; set; }
        public List<Matricula> Matriculas { get; set; }
    }
}