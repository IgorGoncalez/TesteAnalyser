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
    }
}
