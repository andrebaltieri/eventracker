using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eventracker.Domain;

namespace Eventracker.Tests
{
    [TestClass]
    public class Dado_um_novo_ticket
    {
        Event evnt = new Event("Mobile Day 2013", DateTime.Now, DateTime.Now.AddHours(1), 50, 19.00);
        Attendee attendee = new Attendee("André Baltieri", "andre.baltieri@sismat.com.br");
        PromotionCode promotionCode = new PromotionCode(10);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_atendente_nao_pode_ser_nulo()
        {
            var ticket = new Ticket(null, evnt);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_evento_nao_pode_ser_nulo()
        {
            var ticket = new Ticket(attendee, null);
        }

        [TestMethod]
        public void O_valor_deve_ser_19_dado_nenhum_codigo_promocional()
        {
            var ticket = new Ticket(attendee, evnt);
            Assert.AreEqual(19, ticket.Price);
        }

        [TestMethod]
        public void O_valor_deve_ser_9_dado_um_codigo_promocional()
        {
            var ticket = new Ticket(attendee, evnt, promotionCode);
            Assert.AreEqual(9, ticket.Price);
        }

        [TestMethod]
        public void O_valor_deve_ser_0_dado_um_codigo_promocional_maior_que_o_preco_do_evento()
        {
            var code = new PromotionCode(30);
            var ticket = new Ticket(attendee, evnt, code);
            Assert.AreEqual(0, ticket.Price);
        }

        [TestMethod]
        public void O_valor_deve_ser_14_dado_um_codigo_promocional_novo()
        {
            var code = new PromotionCode(5);
            var ticket = new Ticket(attendee, evnt, promotionCode);
            ticket.AddPromotionCode(code);
            Assert.AreEqual(14, ticket.Price);
        }
    }
}
