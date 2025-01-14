using McBonaldsMVC.Enums;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        PedidoRepository pedidoRepository = new PedidoRepository();

        [HttpGet] // marcar que as requisições que chegarem a ele são do tipo Get.... se for do tipo POST é necessário mudar HttpPost
        public IActionResult DashBoard()
        {
            var tipoUsuarioSessao = uint.Parse(ObterUsuarioTipoSession());
            if(tipoUsuarioSessao.Equals((uint)TiposUsuario.ADMINISTRADOR))
            {
            var pedidos = pedidoRepository.ObterTodos();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            foreach (var pedido in pedidos)
            {
                switch(pedido.Status)
                {
                    case (uint) StatusPedido.REPROVADO:
                    dashboardViewModel.PedidosReprovados++;
                    break;
                    case (uint) StatusPedido.APROVADO:
                        dashboardViewModel.PedidosAprovados++;
                    break;
                    default:
                        dashboardViewModel.PedidosPendentes++;
                        dashboardViewModel.Pedidos.Add(pedido);
                    break;
                }
            }
            dashboardViewModel.NomeView = "Dashboard";
            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

            return View(dashboardViewModel); 
            }
            
            return View("Erro", new RepostaViewModel()
            {
                NomeView = "Dashboard",
                Mensagem = "Acesso restrito"
            });

        }
    }
}