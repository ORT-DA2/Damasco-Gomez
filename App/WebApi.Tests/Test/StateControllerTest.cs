using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests.Test
{
    [TestClass]
    public class StateControllerTest
    {
        private List<State> statesToReturn;
        private List<State> statesToReturnEmpty;
        private State stateId1;
        private Mock<IStateLogic> mock;
        private StateController controller ;
        [TestInitialize]
        public void InitVariables()
        {
            statesToReturn = new List<State>()
            {
                new State()
                {
                    Id = 1,
                    Name = "New state",
                },
                new State()
                {
                    Id = 2,
                    Name = "Other state",
                },
                new State()
                {
                    Id = 3,
                    Name = "And other state",
                },
                new State()
                {
                    Id = 4,
                    Name = "And one more state",
                }
            };
            statesToReturnEmpty = new List<State>();
            stateId1 = statesToReturn.First();
            mock = new Mock<IStateLogic>(MockBehavior.Strict);
            controller = new StateController(mock.Object);
        }
        [TestMethod]
        public void TestGetAllStatesOk()
        {
            mock.Setup(m => m.GetAll()).Returns(statesToReturn);
            IEnumerable<StateBasicModel> statesBasic = statesToReturn.Select(m => new StateBasicModel(m));

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var states = okResult.Value as IEnumerable<StateBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(statesBasic.SequenceEqual(states));
        }

        [TestMethod]
        public void TestGetAllEmptyStates ()
        {
            var mock = new Mock<IStateLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(statesToReturnEmpty);
            IEnumerable<StateBasicModel> statesBasic = statesToReturnEmpty.Select(m => new StateBasicModel(m));
            var controller = new StateController(mock.Object);

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var states = okResult.Value as IEnumerable<StateBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(statesBasic.SequenceEqual(states));

        }
        [TestMethod]
        public void TestGetByOk()
        {
            stateId1 = statesToReturn.First();
            mock.Setup(m => m.GetBy(stateId1.Id)).Returns(stateId1);
            StateBasicModel statesBasic = new StateBasicModel(stateId1);

            var result = controller.GetBy(stateId1.Id);

            var okResult = result as OkObjectResult;
            var state = okResult.Value as StateBasicModel;
            mock.VerifyAll();
            Assert.IsTrue(state.Equals(statesBasic));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFoud ()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mock.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mock.VerifyAll();
        }
        
    }
}