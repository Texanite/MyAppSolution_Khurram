using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;
using Moq;
using App.WebServices.Controllers;
using App.Services.Abstractions;
using System.Linq;
using App.Infrastructure.AmbientState;
using App.Infrastructure.DataModels;
using App.Infrastructure.DTOs;
using App.WebServices.Extensions;
using Microsoft.AspNetCore.Mvc;
using App.WebServices.Test.Extentions;


namespace App.WebServices.Test.Controller
{
    public class MovieControllerTest
    {
        private readonly MovieController sut;
        private readonly Mock<IAppAmbientState> mockAmbientState = new Mock<IAppAmbientState>();
        private readonly Mock<IMovieServices> mockMovieService = new Mock<IMovieServices>();
        
        

        public MovieControllerTest()
        {
            sut = new MovieController(mockAmbientState.Object, mockMovieService.Object);
        }


        [Fact]
        public void GetMovies_ShouldReturn_MoviesList_DataTypeOfMovieDataView()
        {
            //Arrange 
            var fixture = new Fixture();
            var movieMockData = fixture.Create<List<MovieDataView>>().AsQueryable();
            var movieResultData = ServicesExtension.SuccessfulResult(movieMockData);
            mockMovieService.Setup(m => m.GetMovies()).Returns(movieMockData);


            //Act
            var actualDataResult = sut.GetMovies() as OkObjectResult;
            var extractedActualResultData =  ((ResultDto)actualDataResult.Value).Data;

            //Assert
            Assert.Equal(movieMockData, extractedActualResultData);
            var items = Assert.IsAssignableFrom<IQueryable<MovieDataView>>(extractedActualResultData);
        }


        [Fact]
        public void GetMovies_ShouldReturn_MoviesList_AllListOfAllMovies()
        {
            //Arrange 
            var fixture = new Fixture();
            var movieMockData = fixture.Create<List<MovieDataView>>().AsQueryable();
            mockMovieService.Setup(m => m.GetMovies()).Returns(movieMockData);

            //Act
            var actualDataResult = sut.GetMovies() as OkObjectResult;
            var extractedActualResultData = ((ResultDto)actualDataResult.Value).Data;

            //Assert
            var items = Assert.IsAssignableFrom<IQueryable<MovieDataView>>(extractedActualResultData);
            Assert.Equal(3, Enumerable.Count(items));
        }
    }
}
