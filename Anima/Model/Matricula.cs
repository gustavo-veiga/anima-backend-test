namespace Anima.Model
{
    public class Matricula
    {
        public int CodGrade { get; set; }
        public Grade Grade { get; set; }
        
        public int Ra { get; set; }
        public Aluno Aluno { get; set; }
    }
}