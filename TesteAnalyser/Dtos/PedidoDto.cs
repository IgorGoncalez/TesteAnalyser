namespace TesteAnalyser.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdStatus { get; set; }
        public int Data { get; set; }

        public IList<PedidoItemDto> Itens { get; set; } = null!;
    }
}
