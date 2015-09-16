#region

using System;

#endregion

namespace Ansur.Dominio
{
    public class Aluno
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Cargo { get; set; }
        public DateTime DataNasc { get; set; }
    }
}