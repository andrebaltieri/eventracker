using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eventracker.Domain;

namespace Eventracker.Tests
{
    [TestClass]
    public class Dado_um_novo_evento
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_titulo_nao_pode_ser_vazio()
        {
            var evnt = new Event("", DateTime.Now, DateTime.Now.AddHours(1), 50, 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void O_titulo_deve_conter_mais_que_tres_caracteres()
        {
            var evnt = new Event("Mob", DateTime.Now, DateTime.Now.AddHours(1), 50, 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void O_numero_minimo_de_tickets_disponiveis_deve_ser_cinco()
        {
            var evnt = new Event("Mobile Day 2013", DateTime.Now, DateTime.Now.AddHours(1), 2, 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void A_data_inicio_deve_ser_no_futuro()
        {
            var evnt = new Event("Mobile Day 2013", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(2), 50, 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void A_data_termino_deve_ser_maior_que_a_data_inicio()
        {
            var evnt = new Event("Mobile Day 2013", DateTime.Now.AddDays(1), DateTime.Now, 50, 19.99);
        }

        [TestMethod]
        public void A_lista_de_tickets_deve_estar_zerada()
        {
            var evnt = new Event("Mobile Day 2013", DateTime.Now, DateTime.Now.AddHours(1), 50, 19.99);
            Assert.AreEqual(evnt.Tickets.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void O_valor__base_deve_ser_maior_que_zero()
        {
            var evnt = new Event("Mobile Day 2013", DateTime.Now.AddDays(1), DateTime.Now, 50, 0);
        }
    }

    [TestClass]
    public class Ao_adicionar_um_novo_ticket
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_ticket_nao_pode_ser_nulo()
        {
            var evnt = new Event("Mobile Day 2013", DateTime.Now, DateTime.Now.AddHours(1), 7, 19.99);
            evnt.AddTicket(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void A_quantidade_disponiveis_de_tickets_deve_ser_satisfatoria()
        {
            int avaliableTickets = 7;
            Event evnt = new Event("Mobile Day 2013", DateTime.Now, DateTime.Now.AddHours(1), avaliableTickets, 19.99);
            for (int i = 0; i <= avaliableTickets; i++)
                evnt.AddTicket(new Ticket(new Attendee("André Baltieri", "andre.baltieri@sismat.com.br"), evnt));
        }
    }
}
