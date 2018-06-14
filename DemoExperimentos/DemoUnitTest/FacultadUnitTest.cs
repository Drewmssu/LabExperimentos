using DemoService;
using NUnit.Framework;
using System;
using System.Linq;

namespace DemoUnitTest
{
    [TestFixture]
    public class FacultadUnitTest
    {
        private readonly FacultadService facultadService = new FacultadService();

        [Test]
        public void ListarFacultad()
        {
            try
            {
                var actual = facultadService.ListFacultad().ToList();
                Assert.True(actual.Count != -1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
