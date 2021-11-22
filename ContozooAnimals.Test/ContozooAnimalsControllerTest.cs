using ContozooAPI.Controllers;
using ContozooAPI.Data;
using ContozooAPI.Interfaces;
using ContozooAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ContozooAnimals.Test
{
    public class ContozooAnimalsControllerTest
    {
        //public ContozooAnimalsControllerTest()
        //{
        //    _service = new ContozooRepository();
        //    _controller = new ContozooAnimalsController(_service);
        //}

        [Fact]
        public static void GetTestAnimalsUnitTest()
        {
            //arrange
            var mockRepo = new Mock<IContozooRepository>();
            mockRepo.Setup(n => n.GetAnimalsAsync()).Returns(MockData.GetTestAnimals());
            var controller = new ContozooAnimalsController(mockRepo.Object);

            //act
            var result = controller.GetContozooAnimals();

            //assert
            var actionResult = Assert.IsType<Task<ActionResult<IEnumerable<ContozooAnimal>>>>(result);
            var okObjectResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result.Result);
            var animals = (List<ContozooAnimal>)okObjectResult.Value;
            Assert.Equal(2, animals.Count);
            Assert.Equal("Shark", animals[0].Animal);
            Assert.Equal("Flamingo", animals[1].Animal);
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

