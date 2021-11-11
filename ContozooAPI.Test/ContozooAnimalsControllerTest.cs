using ContozooAPI.Controllers;
using ContozooAPI.Interfaces;
using ContozooAPI.Repositories;
using NUnit.Framework;

namespace ContozooAPI.Test
{
    public class ContozooAnimalsControllerTest
    {
        ContozooAnimalsController _controller;
        IContozooRepository _service;

        public ContozooAnimalsControllerTest()
        {
            _service = new ContozooRepository();
            _controller = new ContozooAnimalsController(_service);
        }

        [Fact]
        public void GetContozooAnimals()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}