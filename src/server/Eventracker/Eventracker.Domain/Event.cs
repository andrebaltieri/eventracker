using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Eventracker.Domain
{
    public class Event
    {
        public Event(string title, DateTime startDate, DateTime endDate, int avaliableTickets, double basePrice)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(title), "O título é obrigatório.");
            Contract.Requires<ArgumentOutOfRangeException>(title.Length > 3, "O título deve conter pelo menos 3 caracteres.");
            Contract.Requires<ArgumentOutOfRangeException>(startDate >= DateTime.Now.AddMinutes(-1), "A data de início deve estar no futuro.");
            Contract.Requires<ArgumentOutOfRangeException>(endDate > startDate, "A data de término deve ser maior que a data de início.");
            Contract.Requires<ArgumentOutOfRangeException>(avaliableTickets >=5, "Um evento deve iniciar com pelo menos 3 tickets a venda.");
            Contract.Requires<ArgumentOutOfRangeException>(basePrice > 0, "O valor base do evento deve ser maior que zero");

            this.Title = title;
            this.StartDate = startDate;
            this.EndDate = EndDate;
            this.AvaliableTickets = avaliableTickets;
            this.BasePrice = basePrice;
            this.Tickets = new List<Ticket>();
        }

        public int Id { get; protected set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AvaliableTickets { get; set; }
        public double BasePrice { get; set; }
        public IList<Ticket> Tickets { get; protected set; }

        public void AddTicket(Ticket ticket)
        {
            Contract.Requires<ArgumentNullException>(ticket != null, "O ticket fornecido é inválido");
            Contract.Requires<ArgumentOutOfRangeException>(this.Tickets.Count() < this.AvaliableTickets, "Tickets para o evento esgotados.");

            this.Tickets.Add(ticket);
        }
    }
}
