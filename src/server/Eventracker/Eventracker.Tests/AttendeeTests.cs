using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eventracker.Domain;

namespace Eventracker.Tests
{
    [TestClass]
    public class Dado_um_novo_atendente
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void O_nome_deve_conter_mais_que_tres_caracteres()
        {
            var att = new Attendee("", "andre.baltieri@sismat.com.br");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_email_deve_ser_fornecido()
        {
            var att = new Attendee("André Baltieri", "");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void O_email_deve_ser_valido()
        {
            var att = new Attendee("André Baltieri", "fakemail");
        }
    }
}
