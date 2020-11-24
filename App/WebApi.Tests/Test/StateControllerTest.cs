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
        private State stateWithId1;
        private Mock<IStateLogic> mockStateLogic;
        private StateController controllerState ;
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
            stateWithId1 = statesToReturn.First();
            mockStateLogic = new Mock<IStateLogic>(MockBehavior.Strict);
            controllerState = new StateController(mockStateLogic.Object);
        }
        [TestMethod]
        public void TestGetAllStatesOk()
        {
            mockStateLogic.Setup(m => m.GetAll()).Returns(statesToReturn);
            IEnumerable<StateBasicModel> statesBasic = statesToReturn.Select(m => new StateBasicModel(m));

            var result = controllerState.Get();

            var okResult = result as OkObjectResult;
            var states = okResult.Value as IEnumerable<StateBasicModel>;
            mockStateLogic.VerifyAll();
            Assert.IsTrue(statesBasic.SequenceEqual(states));
        }

        [TestMethod]
        public void TestGetAllEmptyStates ()
        {
            var mockStateLogic = new Mock<IStateLogic>(MockBehavior.Strict);
            mockStateLogic.Setup(m => m.GetAll()).Returns(statesToReturnEmpty);
            IEnumerable<StateBasicModel> statesBasic = statesToReturnEmpty.Select(m => new StateBasicModel(m));
            var controllerState = new StateController(mockStateLogic.Object);

            var result = controllerState.Get();

            var okResult = result as OkObjectResult;
            var states = okResult.Value as IEnumerable<StateBasicModel>;
            mockStateLogic.VerifyAll();
            Assert.IsTrue(statesBasic.SequenceEqual(states));

        }
        [TestMethod]
        public void TestGetByOk()
        {
            stateWithId1 = statesToReturn.First();
            mockStateLogic.Setup(m => m.GetBy(stateWithId1.Id)).Returns(stateWithId1);
            StateBasicModel statesBasic = new StateBasicModel(stateWithId1);

            var result = controllerState.GetBy(stateWithId1.Id);

            var okResult = result as OkObjectResult;
            var state = okResult.Value as StateBasicModel;
            mockStateLogic.VerifyAll();
            Assert.IsTrue(state.Equals(statesBasic));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFoud ()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mockStateLogic.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controllerState.GetBy(id);

            mockStateLogic.VerifyAll();
        }
        
    }
}