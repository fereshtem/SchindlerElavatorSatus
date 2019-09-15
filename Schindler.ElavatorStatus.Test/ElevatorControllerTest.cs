using NUnit.Framework;
using FluentAssertions;
using System;
using Moq;
using Schindler.ElavatorStatus.Domain;
using Schindler.ElavatorStatus.WebService.Controllers.V1;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace Schindler.ElavatorStatus.Test
{
    public class ElevatorControllerTest
    {
        ElevatorController _controller;
        private Mock<IElavatoStatusRepository> MockElavatoStatusRepository
        {
            get
            {
                var mock = new Mock<IElavatoStatusRepository>();
                return mock;
            }
        }
        private Mock<IMapper> Mapper
        {
            get
            {
                var mock = new Mock<IMapper>();
                return mock;
            }
        }
        public ElevatorControllerTest()
        {
            _controller = new ElevatorController(MockElavatoStatusRepository.Object, Mapper.Object);
        }
        private Domain.ElavatorStatus DefaultElavatorStatus =>
            new Domain.ElavatorStatus(StatusType.Status1.ToString());

        [Test]
        public void Post_WhenCalled_ReturnsCreatedResponse()
        {
            var createdResponse = _controller.Post(DefaultElavatorStatus);

            createdResponse.Should().BeOfType<CreatedAtActionResult>();
        }

        [Test]
        public void InsertStatus__ShouldAddCorrectElevatorStatus()
        {
            var elavatorStatusRepository = new ElavatorStatusRepository();

            var firstElavatorStatus = elavatorStatusRepository.InsertStatus(DefaultElavatorStatus);

            elavatorStatusRepository.GetStatuses().Should().NotBeNull();
            elavatorStatusRepository.GetElavatorStatus(firstElavatorStatus.Id).Should().NotBeNull();
            elavatorStatusRepository.GetElavatorStatus(firstElavatorStatus.Id).Status.Should().Be(DefaultElavatorStatus.Status);
        }
        [Test]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            var notFoundResult = _controller.Get(Guid.NewGuid());
            notFoundResult.Result.Should().BeOfType<NotFoundResult>();
        }
        
        [Test]
        public void GetById_ExistingGuidPassed_ShouldOnceCalled()
        {
            var mock = new Mock<IElavatoStatusRepository>();
            var elavatorStatusRepository = new ElavatorStatusRepository();
            var mockMapper = new Mock<IMapper>();

            var result = elavatorStatusRepository.InsertStatus(DefaultElavatorStatus);
            mock.Setup(m => m.GetElavatorStatus(result.Id));
            var controller = new ElevatorController(mock.Object, mockMapper.Object);
            controller.Get(result.Id);

            mock.Verify(x => x.GetElavatorStatus(result.Id), Times.Once);
        }

        [Test]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.Get();
            okResult.Result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void Get_WhenCalled_ShouldCalledOnce()
        {
            var mock = new Mock<IElavatoStatusRepository>();
            mock.Setup(m => m.GetStatuses());
            var elavatorStatusRepository = new ElavatorStatusRepository();
            var mockMapper = new Mock<IMapper>();
            elavatorStatusRepository.InsertStatus(DefaultElavatorStatus);

            var controller = new ElevatorController(mock.Object, mockMapper.Object);
            controller.Get();

            mock.Verify(x => x.GetStatuses(), Times.Once);
        }
        
        [Test]
        public void Remove__ShouldDeleteCorrectElevatorStatus()
        {
            var elavatorStatusRepository = new ElavatorStatusRepository();

            var firstElavatorStatus = elavatorStatusRepository.InsertStatus(DefaultElavatorStatus);
            var secondElavatorStatus = elavatorStatusRepository.InsertStatus(new Domain.ElavatorStatus(StatusType.Status2.ToString()));

            elavatorStatusRepository.GetElavatorStatus(firstElavatorStatus.Id).Should().NotBeNull();
            elavatorStatusRepository.DeleteElavatorStatus(firstElavatorStatus.Id);
            elavatorStatusRepository.GetElavatorStatus(firstElavatorStatus.Id).Should().BeNull();
        }
        [Test]
        public void UpdateElevatorStatus__ShouldUpdateElevatorStatus()
        {
            var elavatorStatusRepository = new ElavatorStatusRepository();
            var secondElevatorStatus = new Domain.ElavatorStatus(StatusType.Status2.ToString());

            elavatorStatusRepository.InsertStatus(DefaultElavatorStatus);
            elavatorStatusRepository.InsertStatus(secondElevatorStatus);
            DefaultElavatorStatus.Status = StatusType.Status3.ToString();

            elavatorStatusRepository.GetElavatorStatus(secondElevatorStatus.Id).Status.Should().Be(secondElevatorStatus.Status);
            elavatorStatusRepository.UpdateElavatorStatus(DefaultElavatorStatus);
            elavatorStatusRepository.GetElavatorStatus(secondElevatorStatus.Id).Status.Should().Be(secondElevatorStatus.Status);
        }
    }
}
