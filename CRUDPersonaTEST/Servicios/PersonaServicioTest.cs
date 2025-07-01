using AutoMapper;
using CRUDPersonaBLL.Servicios.Persona;
using CRUDPersonaDAL.Repositorios.Persona;
using CRUDPersonaObjetos.Modelos;
using CRUDPersonaObjetos.ViewModelos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaTEST.Servicios
{
    public class PersonaServicioTest
    {
        private readonly PersonaServicio _personaServicio;
        private readonly Mock<IPersonaRepositorio> _personaRepositorio;  
        private readonly Mock<IMapper> _mapper;

        public PersonaServicioTest()
        {
            _personaRepositorio = new Mock<IPersonaRepositorio>();
            _mapper = new Mock<IMapper>();
            _personaServicio = new PersonaServicio(_personaRepositorio.Object, _mapper.Object);
        }

        [Fact]
        public async Task ObtenerPersonaAsync_DeberiaRetornarListaDeViewModelos()
        {
            // Arrange
            var personas = new List<CRUDPersonaObjetos.Modelos.Persona> //simular base de datos
            {
                new CRUDPersonaObjetos.Modelos.Persona { Id = 1, Nombre = "Juan" },
                new CRUDPersonaObjetos.Modelos.Persona { Id = 2, Nombre = "Maria" }
            };

            var viewModels = new List<PersonaViewModelo> {   //simular el mapper
                new PersonaViewModelo { Id = 1, Nombre = "Juan" },
                new PersonaViewModelo { Id = 2, Nombre = "Maria" }
            };

            _personaRepositorio.Setup(repo => repo.ObtenerPersonasAsync()).ReturnsAsync(personas);  
            _mapper.Setup(m => m.Map<List<PersonaViewModelo>>(personas)).Returns(viewModels);

            // Act

            var resultado = await _personaServicio.ObtenerPersonasAsync();  

            // Assert
            Assert.NotNull(resultado);
        }

        [Fact]
        public async Task ObtenerPersonaPorIdAsync_RetornaPersonaViewModelo_CuandoExiste()
        {
            // Arrange
            var persona = new Persona { Id = 1, Nombre = "Juan", Apellido = "Pérez", Edad = 30, ProvinciaIdfk = 2 };
            var personaViewModelo = new PersonaViewModelo { Id = 1, Nombre = "Juan", Apellido = "Pérez", Edad = 30, ProvinciaIdfk = 2 };

            var mockRepo = new Mock<IPersonaRepositorio>();
            mockRepo.Setup(r => r.ObtenerPersonaPorIdAsync(1)).ReturnsAsync(persona);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<PersonaViewModelo>(persona)).Returns(personaViewModelo);

            var servicio = new PersonaServicio(mockRepo.Object, mockMapper.Object);

            // Act
            var resultado = await servicio.ObtenerPersonaPorIdAsync(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(personaViewModelo.Id, resultado.Id);
            Assert.Equal(personaViewModelo.Nombre, resultado.Nombre);
            Assert.Equal(personaViewModelo.Apellido, resultado.Apellido);
            Assert.Equal(personaViewModelo.Edad, resultado.Edad);
            Assert.Equal(personaViewModelo.ProvinciaIdfk, resultado.ProvinciaIdfk);
        }

        [Fact]
        public async Task ObtenerPersonaPorIdAsync_RetornaNull_CuandoNoExiste()
        {
            // Arrange
            Persona? persona = null;

            var mockRepo = new Mock<IPersonaRepositorio>();
            mockRepo.Setup(r => r.ObtenerPersonaPorIdAsync(99)).ReturnsAsync(persona);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<PersonaViewModelo>(persona)).Returns((PersonaViewModelo?)null);

            var servicio = new PersonaServicio(mockRepo.Object, mockMapper.Object);

            // Act
            var resultado = await servicio.ObtenerPersonaPorIdAsync(99);

            // Assert
            Assert.Null(resultado);
        }


    }
}
