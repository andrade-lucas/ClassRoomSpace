using System;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.Professor;
using ClassRoomSpace.Tests.Mocks.Repositories;
using ClassRoomSpace.Tests.Mocks.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Commands.Handlers
{
    [TestClass]
    public class ProfessorHandlerTests
    {
        private readonly CreateProfessorCommand _validCreateCommand;
        private readonly CreateProfessorCommand _invalidCreateCommand;
        private readonly ProfessorHandler _handler;

        public ProfessorHandlerTests()
        {
            _validCreateCommand = new CreateProfessorCommand();
            _validCreateCommand.FirstName = "FirstName";
            _validCreateCommand.LastName = "LastName";
            _validCreateCommand.Document = "402.020.980-44";
            _validCreateCommand.Email = "example@example.com";
            _validCreateCommand.IdCourse = Guid.NewGuid();
            _validCreateCommand.Phone = "0000000000000";

            _invalidCreateCommand = new CreateProfessorCommand();
            _invalidCreateCommand.FirstName = "";
            _invalidCreateCommand.LastName = "";
            _invalidCreateCommand.Document = "402.020.-44";
            _invalidCreateCommand.Email = "example.com";
            _invalidCreateCommand.IdCourse = Guid.NewGuid();
            _invalidCreateCommand.Phone = "";
            
            _handler = new ProfessorHandler(new ProfessorRepositoryMock(), new EmailServiceMock());
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenInvalid()
        {
            var result = _handler.Handle(_invalidCreateCommand);
            Assert.AreEqual(false, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenValid()
        {
            var result = _handler.Handle(_validCreateCommand);
            Assert.AreEqual(true, result.Status);
        }
    }
}