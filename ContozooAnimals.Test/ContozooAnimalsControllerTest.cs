using ContozooAPI.Controllers;
using ContozooAPI.Interfaces;
using ContozooAPI.Model;
using ContozooAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
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
        public void GetAnimalTest()
        {
                //arrange
                //act
                var result = _controller.GetContozooAnimals();
                //assert
                Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result;
            Assert.IsType<List<ContozooAnimal>>(list.Value);

            var listAnimals = list.Value as List<ContozooAnimal>;
                Assert.Equal(3, listAnimals.Count);
            }

        [Fact]
        public async Task GetContozooEndpoint()
        {
            var apiClient = new HttpClient();

            var apiResponse = await apiClient.GetAsync("http://localhost:39795/api/contozooanimals");

            Assert.True(apiResponse.IsSuccessStatusCode);

            var stringResponse = await apiResponse.Content.ReadAsStringAsync();

            Assert.Equal("Healthy", stringResponse);
        }
    }
    }

