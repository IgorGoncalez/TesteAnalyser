using TesteAnalyser.Dtos;
using TesteAnalyser.Enums;
using TesteAnalyser.Modelos;
using TesteAnalyser.Repository;

namespace TesteAnalyser.Negocio
{
    public class ClienteNegocio
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteCadastroRepository _clienteCadastroRepository;
        private readonly IProdutoRepository _produtoRepository;

        public ClienteNegocio(IClienteRepository clienteRepository, IClienteCadastroRepository clienteCadastroRepository, IProdutoRepository produtoRepository)
        {
            _clienteRepository = clienteRepository;
            _clienteCadastroRepository = clienteCadastroRepository;
            _produtoRepository = produtoRepository;
        }

        public void Teste()
        {
            _clienteRepository.Save();
            _clienteCadastroRepository.Save();
            _produtoRepository.Save();
        }

        public void Teste2()
        {
            var pedidos = new List<Pedido>();
            var pedidosItens = new List<PedidoItem>();

            var documentos = new List<Documento>();
            var parametrizacoes = new List<Parametrizacao>();

            var teste1 =
            (
                from p in pedidos
                join pi in pedidosItens
                    on p.Id equals pi.IdPedido
                select new
                {
                    idPedido = p.Id,
                    idPedidoItem = pi.Id
                }
            ).ToList();

            var teste2 =
            (
                from p in pedidos
                from pi in pedidosItens
                where pi.IdPedido == p.Id
                select new
                {
                    idPedido = p.Id,
                    idPedidoItem = pi.Id
                }
            ).ToList();

            var teste3 =
            (
                from p in pedidos
                from pi in pedidosItens
                    .Where(pi => pi.IdPedido == p.Id)
                select new
                {
                    idPedido = p.Id,
                    idPedidoItem = pi.Id
                }
            ).ToList();

            var teste4 =
            (
                from p in pedidos
                where pedidosItens.Any(pi => pi.IdPedido == p.Id)
                select new
                {
                    idPedido = p.Id,
                }
            ).ToList();

            var teste5 =
            (
                from p in pedidos
                where p.IdCliente == 1
                select new
                {
                    idPedido = p.Id,
                }
            ).ToList();

            var teste6 = pedidos.Any(p => p.IdCliente == 1);

            var teste7 =
            (
                from d in documentos
                from p in parametrizacoes
                where d.DataReferencia >= p.DataInicio && d.DataReferencia <= (p.DataFim ?? d.DataReferencia)
                select new
                {
                    idDocumento = d.Id,
                    idParametrizacao = p.Id,
                }
            ).ToList();

            var teste8 = pedidos.Any(p => p.IdStatus == (int)StatusPedidoEnum.Finalizado);

            var pedido = new Pedido();
            var teste9 = pedidosItens.Any(x => x.IdPedido == pedido.Id);

            var teste10 = pedidos.Select(p => new
            {
                idPedido = p.Id,
                itens = pedidosItens.Where(pi => pi.IdPedido == p.Id).ToList()
            }).ToList();

            var teste11 = pedidos.Select(p => new
            {
                idPedido = p.Id,
                itens =
                (
                    from pi in pedidosItens
                    where pi.IdPedido == p.Id
                    select pi
                )
            }).ToList();

            var teste12 = pedidos.Select(p => new
            {
                idPedido = p.Id,
                itens = pedidosItens.Any(pi => pi.IdPedido == p.Id)
            }).ToList();

            var produtos = new List<Produto>();
            var pedidosDtos = new List<PedidoDto>();

            var teste13 =
            (
                from p in pedidosDtos
                select new
                {
                    idPedido = p.Id,
                    itens =
                    (
                        from pi in p.Itens
                        join pd in produtos
                            on pi.IdProduto equals pd.Id
                        select new
                        {
                            idPedidoItem = pi.Id,
                            idProduto = pd.Id,
                        }
                    ).ToList()
                }
            ).ToList();
        }
    }
}
