namespace DespesaViagem.Domain.DTOs.Records
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string CPF { get; set; }
        public required string Matricula { get; set; }
    }
}
