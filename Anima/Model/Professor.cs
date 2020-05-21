using System.Collections.Generic;

namespace Anima.Model
{
    public class Professor : Usuario
    {
        public int CodFuncionario { get; set; }

        public decimal Salario(int totalAlunos, int totalGrades)
        {
            
            return (decimal) (totalAlunos / 10m * totalGrades * 50 + 1200);
        }
    }
}