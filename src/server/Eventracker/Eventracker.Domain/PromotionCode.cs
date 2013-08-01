using System;
using System.Diagnostics.Contracts;

namespace Eventracker.Domain
{
    public class PromotionCode
    {
        public PromotionCode(double price)
        {
            Contract.Requires<ArgumentOutOfRangeException>(price > 0, "O valor base do evento deve ser maior que zero");

            string[] code = Guid.NewGuid().ToString().Split('-');

            this.Code = String.Format("{0}-{1}-{2}", code[1], code[2], code[3]).ToUpper();
            this.Price = price;
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
    }
}
