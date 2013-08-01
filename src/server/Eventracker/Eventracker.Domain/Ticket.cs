using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Eventracker.Domain
{
    public class Ticket
    {
        public Ticket(Attendee attendee, Event evnt, PromotionCode promotionCode = null)
        {
            Contract.Requires<ArgumentNullException>(attendee != null, "O atendente fornecido é inválido");
            Contract.Requires<ArgumentNullException>(evnt != null, "O evento fornecido é inválido");

            this.Attendee = attendee;
            this.Event = evnt;
            if (promotionCode != null)          
                this.PromotionCode = promotionCode;
            UpdatePrice();
        }

        public int Id { get; set; }
        public Attendee Attendee { get; set; }
        public Event Event { get; set; }
        public PromotionCode PromotionCode { get; set; }
        public double Price { get; set; }

        public void AddPromotionCode(PromotionCode promotionCode)
        {
            Contract.Requires<ArgumentNullException>(promotionCode != null, "Código promocional inválido.");
            this.PromotionCode = promotionCode;
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            Contract.Requires<ArgumentNullException>(this.Event != null, "Evento inválido.");

            if (this.PromotionCode != null)
            {
                this.Price = this.Event.BasePrice - this.PromotionCode.Price;

                if (this.Price < 0)
                    this.Price = 0;
            }
            else
            {
                this.Price = this.Event.BasePrice;
            }
        }
    }
}
