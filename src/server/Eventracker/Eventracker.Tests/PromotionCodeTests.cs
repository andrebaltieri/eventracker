using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eventracker.Domain;

namespace Eventracker.Tests
{
    [TestClass]
    public class Dado_um_novo_promotion_code
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void O_valor_deve_ser_maior_que_zero()
        {
            var promotionCode = new PromotionCode(0);
        }

        [TestMethod]
        public void O_codigo_gerado_e_valido()
        {
            var promotionCode = new PromotionCode(5.99);
            Assert.AreEqual(14, promotionCode.Code.Length);
        }
    }
}
