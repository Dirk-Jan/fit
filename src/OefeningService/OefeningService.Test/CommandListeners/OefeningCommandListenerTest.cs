﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Miffy;
using Minor.Miffy.MicroServices.Abstractions;
using Moq;
using OefeningService.CommandListeners;
using OefeningService.Commands;
using OefeningService.Events;
using OefeningService.Models;
using OefeningService.Repositories.Abstractions;

namespace OefeningService.Test.CommandListeners
{
    [TestClass]
    public class OefeningCommandListenerTest
    {
        [TestMethod]
        [DataRow("Push up", "Borst op de grond")]
        [DataRow("Squat", "Ver doorzakken")]
        public void HandleMaakKlantAanCommand_ShouldCallAddOnRepositoryWithOefening(string naam, string omschrijving)
        {
            // Arrange
            var repositoryMock = new Mock<IOefeningRepository>(MockBehavior.Strict);
            repositoryMock.Setup(x => x.Add(It.IsAny<Oefening>()));
            var evenPublisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            evenPublisherMock.Setup(x => x.PublishAsync(It.IsAny<DomainEvent>()))
                .Returns(new Task(() => { }));
            
            var target = new OefeningCommandListener(repositoryMock.Object, evenPublisherMock.Object);
            var oefening = new Oefening
            {
                Naam = naam,
                Omschrijving = omschrijving
            };
            var command = new MaakOefeningAanCommand
            {
                Oefening = oefening
            };

            // Act
            target.HandleMaakKlantAanCommand(command);
            
            // Assert
            repositoryMock.Verify(x => x.Add(oefening), Times.Once);
        }

        [TestMethod]
        [DataRow("Push up", "Borst op de grond")]
        [DataRow("Squat", "Ver doorzakken")]
        public void HandleMaakKlantAanCommand_ShouldPublishEventWithOefening(string naam, string omschrijving)
        {
            // Arrange
            var repositoryMock = new Mock<IOefeningRepository>(MockBehavior.Strict);
            repositoryMock.Setup(x => x.Add(It.IsAny<Oefening>()));
            var evenPublisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            evenPublisherMock.Setup(x => x.PublishAsync(It.IsAny<DomainEvent>()))
                .Returns(new Task(() => { }));
            
            var target = new OefeningCommandListener(repositoryMock.Object, evenPublisherMock.Object);
            var oefening = new Oefening
            {
                Naam = naam,
                Omschrijving = omschrijving
            };
            var command = new MaakOefeningAanCommand
            {
                Oefening = oefening
            };

            // Act
            target.HandleMaakKlantAanCommand(command);
            
            // Assert
            evenPublisherMock.Verify(x => x.PublishAsync(
                It.Is<OefeningAangemaaktEvent>(e => e.Oefening == oefening)), 
                Times.Once);
        }
        
        [TestMethod]
        [DataRow("Push up", "Borst op de grond")]
        [DataRow("Squat", "Ver doorzakken")]
        public void HandleMaakKlantAanCommand_ShouldReturnCommand(string naam, string omschrijving)
        {
            // Arrange
            var repositoryMock = new Mock<IOefeningRepository>(MockBehavior.Strict);
            repositoryMock.Setup(x => x.Add(It.IsAny<Oefening>()));
            var evenPublisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            evenPublisherMock.Setup(x => x.PublishAsync(It.IsAny<DomainEvent>()))
                .Returns(new Task(() => { }));
            
            var target = new OefeningCommandListener(repositoryMock.Object, evenPublisherMock.Object);
            var oefening = new Oefening
            {
                Naam = naam,
                Omschrijving = omschrijving
            };
            var command = new MaakOefeningAanCommand
            {
                Oefening = oefening
            };

            // Act
            MaakOefeningAanCommand result = target.HandleMaakKlantAanCommand(command);
            
            // Assert
            Assert.AreSame(command, result);
        }
    }
}