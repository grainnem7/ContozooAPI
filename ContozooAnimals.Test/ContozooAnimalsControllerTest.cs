using ContozooAPI.Controllers;
using ContozooAPI.Data;
using ContozooAPI.Interfaces;
using ContozooAPI.Model;
using ContozooAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ContozooAnimals.Test
{
    public class ContozooAnimalsControllerTest
    {
        ContozooAnimalsController _controller;
        IContozooRepository _service;

        //public ContozooAnimalsControllerTest()
        //{
        //    _service = new ContozooRepository();
        //    _controller = new ContozooAnimalsController(_service);
        //}

        [Fact]
        public static void IndexUnitTest()
        {
            //arrange
            var mockRepo = new Mock<IContozooRepository>();
            mockRepo.Setup(n => n.GetAnimals()).Returns(MockData.GetTestAnimals());
            var controller = new ContozooAnimalsController(mockRepo.Object);

            //act
            var result = controller.GetContozooAnimals();

            //assert
            var actionResult = Assert.IsType<Task<ActionResult<IEnumerable<ContozooAnimal>>>>(result);
            var actionResultAnimals = Assert.IsAssignableFrom<Task<List<ContozooAnimal>>>(actionResult.Result.Value);
            Assert.Equal(2, actionResultAnimals.Result.Count);
        }

        //[Fact]
        //public void GetAnimalTest()
        //{
        //        //arrange
        //        //act
        //        var result = _controller.GetContozooAnimals();
        //        //assert
        //        Assert.IsType<OkObjectResult>(result.Result);

        //    var list = result.Result;
        //    Assert.IsType<List<ContozooAnimal>>(list.Value);

        //    var listAnimals = list.Value as List<ContozooAnimal>;
        //        Assert.Equal(3, listAnimals.Count);
        //    }

        //[Fact]
        //public async Task GetContozooEndpoint()
        //{
        //    var apiClient = new HttpClient();

        //    var apiResponse = await apiClient.GetAsync("http://localhost:39795/api/contozooanimals");

        //    Assert.True(apiResponse.IsSuccessStatusCode);

        //    var stringResponse = await apiResponse.Content.ReadAsStringAsync();

        //    Assert.Equal("Healthy", stringResponse);
        //}
    }
    }

