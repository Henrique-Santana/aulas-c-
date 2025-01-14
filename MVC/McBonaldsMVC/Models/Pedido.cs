using System;
using McBonaldsMVC.Enums;

namespace McBonaldsMVC.Models
{
    public class Pedido
    {
        public ulong Id {get;set;}  // atributo para identificar o pedido
        public Cliente Cliente {get;set;}
        public Hamburguer Hamburguer {get;set;}
        public Shake Shake {get;set;}
        public DateTime DatadoPedido {get;set;}
        public double PrecoTotal {get;set;}
        public uint Status {get; set;} // atributo para saber se o pedido esta aprovado, reprovado ou pendente

        public Pedido()
        {
            this.Cliente = new Cliente();
            this.Hamburguer = new Hamburguer();
            this.Shake = new Shake();
            this.Id = 0;
            this.Status = (uint) StatusPedido.PENDENTE;
        }

        
    }
}