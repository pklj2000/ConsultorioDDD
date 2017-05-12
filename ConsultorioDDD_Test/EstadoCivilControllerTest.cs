using Moq;
using Consultorio.Service.Infrastructure;
using ConsultorioDDD.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using Consultorio.Domain.Models;
using System.Web.Mvc;
using System;


//instalar NUnit3, NUnit3 Test Adapter

namespace ConsultorioDDD_Test
{
    [TestFixture]
    public class EstadoCivilControllerTest
    {
        private Mock<IEstadoCivilService> _mockContactService;
        private EstadoCivilController _controller;

       
        [Test]  
        public void Controller_Get_EstadoCivil()
        {
            var stubEstadoCivil = new List<EstadoCivil>
            {
                new EstadoCivil()
                {
                    Id = 1,
                    Descricao = "Solteiro",
                    Ativo = 1
                },
                new EstadoCivil()
                {
                    Id = 2,
                    Descricao = "Casado",
                    Ativo = 1
                }
            };

            _mockContactService = new Mock<IEstadoCivilService>();
            _mockContactService.Setup(x => x.GetAll()).Returns(stubEstadoCivil);
            _controller = new EstadoCivilController(_mockContactService.Object);
            var result = _controller.Index() as ViewResult;
            var actualModel = result.Model as List<EstadoCivil>;

            for (int i = 0; i < stubEstadoCivil.Count; i++)
            {
                Assert.AreEqual(stubEstadoCivil[i].Id, actualModel[i].Id);
                Assert.AreEqual(stubEstadoCivil[i].Descricao, actualModel[i].Descricao);
                Assert.AreEqual(stubEstadoCivil[i].Ativo, actualModel[i].Ativo);
            }
        }

        [Test]
        public void Controller_Save_EstadoCivil_ok()
        {

         EstadoCivilController _controller;
        var estadoCivil = new EstadoCivil()
            {
                Id = 0,
                Descricao = "Divorciado",
                Ativo = 1,
                AddedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
                
            };

            Mock<IEstadoCivilService> _service = new Mock<IEstadoCivilService>();

          
            _service.Setup(x => x.Insert(It.IsAny<EstadoCivil>()));
            _controller = new EstadoCivilController(_service.Object);
            var result = (RedirectToRouteResult)_controller.Create(estadoCivil);

            _service.Verify(x=> x.Insert(estadoCivil), Times.AtLeast(1));
             Assert.AreEqual("Index", result.RouteValues["action"]);


        }

    }
}
