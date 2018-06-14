using DemoDataLayer;
using DemoService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoUnitTest
{
    [TestFixture]
    public class DocenteUnitTest
    {
        private readonly DocenteService docenteService = new DocenteService();
        private readonly List<int> Ids = new List<int>();
        private Docente docente = new Docente();
        private readonly string lastName = "Perez";

        public Docente GetDocenteMock1() => new Docente
        {
            Nombre = "Francis",
            Apellido = "Marquez",
            DNI = "12345678",
            Sexo = "M",
            Descripcion = "Best teacher",
            FacultadId = 2,
            Bonificacion = true,
            FechaNacimiento = DateTime.Parse("09/11/1993")
        };

        public Docente GetDocenteMock2() => new Docente
        {
            Nombre = "Diego",
            Apellido = "Jara",
            DNI = "23455543",
            Sexo = "M",
            Descripcion = "Best teacher",
            FacultadId = 3,
            Bonificacion = false,
            FechaNacimiento = DateTime.Parse("07/07/1997")
        };

        public Docente[] GetDocentesMock()
        {
            Docente[] docentesMock = { GetDocenteMock1(), GetDocenteMock2() };
            return docentesMock;
        } 
        
        [Test]
        public void A_Insertar_Docente()
        {
            try
            {
                Console.WriteLine("Método Ingresar");
                docente = GetDocenteMock1();
                docente = docenteService.AddDocente(docente);
                Ids.Add(docente.Id);
                Assert.That(docente.Id, Is.GreaterThan(0));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
        }

        [Test]
        public void B_Listar_Docente()
        {
            try
            {
                Console.WriteLine("Metodo Listar");
                var actual = docenteService.ListDocente().ToList();
                Assert.True(actual.Count != -1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void C_FiltrarPorApellido()
        {
            try
            {
                Console.WriteLine("Metodo Filtrar por Apellido");
                var actual = docenteService.ListDocenteByLastName(lastName);
                foreach (var d in actual)
                {
                    if (!d.Apellido.Equals(lastName))
                        Assert.Fail();
                }
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void D_ObtenerDocente()
        {
            try
            {
                int id = 4;
                Console.WriteLine("Metodo Obtener");
                Assert.NotNull(docenteService.FindDocente(id));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void E_EliminarDocente()
        {
            try
            {
                Console.WriteLine("Metodo Eliminar");
                Console.WriteLine(docente.Id);
                Console.WriteLine(Ids.Count);

                for (int i = 0; i < Ids.Count; i++)
                {
                    Console.WriteLine(Ids[i]);
                    docenteService.DeleteDocente(Ids[i]);
                }
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
