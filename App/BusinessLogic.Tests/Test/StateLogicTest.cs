using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Logics;
using DataAccessInterface.Repositories;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests.Test
{
    [TestClass]
    public class StateLogicTest
    {
        private  List<State> statesToReturn;
        private  List<State>  emptyStates;
        private StateLogic stateLogic;
        private Mock<IStateRepository> mock;

        [TestInitialize]
        public void InitVariables()
        {
            statesToReturn = new List<State>()
            {
                new State()
                {
                    Id = 1,
                    Name = "State 1",
                },
                new State()
                {
                    Id = 2,
                    Name = "State 2",
                }
            };
            emptyStates = new List<State>();
            mock = new Mock<IStateRepository>(MockBehavior.Strict);
            stateLogic = new StateLogic(mock.Object);
        }
        [TestMethod]
        public void GetAll()
        {
            mock.Setup(m => m.GetElements()).Returns(statesToReturn);

            var result = stateLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(statesToReturn));
        }
        [TestMethod]
        public void GetAllEmpty()
        {
            mock.Setup(m => m.GetElements()).Returns(emptyStates);

            var result = stateLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(emptyStates));
        }
        [TestMethod]
        public void GetByTestOk()
        {
            State state = statesToReturn.First();
            mock.Setup(m => m.Find(state.Id)).Returns(state);

            var result = stateLogic.GetBy(state.Id);

            Assert.AreEqual(result,state);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            State state = statesToReturn.First();
            State empty = null;
            mock.Setup(m => m.Find(state.Id)).Returns(empty);

            var result = stateLogic.GetBy(state.Id);

            Assert.IsNull(result);
        }
    }
}