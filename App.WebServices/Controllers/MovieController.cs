using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Infrastructure.AmbientState;
using App.Infrastructure.DTOs;
using App.Services.Abstractions;
using App.WebServices.Extensions;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IAppAmbientState ambientState;
        private readonly IMovieServices movieServices;
    
        public MovieController(IAppAmbientState ambientState, IMovieServices movieServices)
        {
            this.ambientState = ambientState;
            this.movieServices = movieServices;
        }

        [HttpGet]
        public ActionResult GetMovies()
        {
            try
            {
                var resultData = movieServices.GetMovies();

                return Ok(ServicesExtension.SuccessfulResult(resultData));
            }
            catch(Exception exp)
            {
                return new JsonResult(ServicesExtension.ErrorResult(exp));
            }
        }

        [HttpGet]
        public ActionResult GetMovie(int movieId)
        {
            try
            {
                var resultData = movieServices.GetMovie(movieId);

                if(resultData == null)
                {
                    return NotFound();
                }

                return Ok(ServicesExtension.SuccessfulResult(resultData));
            }
            catch(Exception exp)
            {
                return new JsonResult(ServicesExtension.ErrorResult(exp));
            }
        }

        [HttpGet]
        public ActionResult GetMoviesStats()
        {
            try
            {
                var resultData = movieServices.GetMovieStats();

                return Ok(ServicesExtension.SuccessfulResult(resultData));
            }
            catch (Exception exp)
            {
                return new JsonResult(ServicesExtension.ErrorResult(exp));
            }
        }

        [HttpPost]
        public ActionResult CreateMovie([FromBody] MovieDto movie)
        {
            try
            {
                var resultData = movieServices.CreateMovie(movie);

                return Ok(ServicesExtension.SuccessfulResult(resultData));
            }
            catch (Exception exp)
            {
                return new JsonResult(ServicesExtension.ErrorResult(exp));
            }
        }

        [HttpPost]
        public ActionResult DeleteMovie(int movieId)
        {
            try
            {
                var resultData = movieServices.DeleteMovie(movieId);

                return Ok(ServicesExtension.SuccessfulResult(resultData));
            }
            catch (Exception exp)
            {
                return new JsonResult(ServicesExtension.ErrorResult(exp));
            }
        }

     /*   private ResultDto SuccessfulResult(dynamic data)
        {
            var result = new ResultDto
            {
                Ok = true,
                Data = data,
                Error = "No"
            };

            return result;
        }

        private ResultDto ErrorResult(Exception exp)
        {
            var result = new ResultDto
            {
                Ok = false,
                Data = exp,
                Error = exp.Message

            };

            return result;
        }
        */
    }
}