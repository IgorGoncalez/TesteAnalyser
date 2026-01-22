namespace TesteAnalyser.Modelos
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int IdStatus { get; set; }
        public decimal Valor { get; set; }
    }
}
