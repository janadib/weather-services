using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherServices.ApiHelper.Models;
using WeatherServices.ApiHelper.Response;
using WeatherServices.Service.Request;
using WeatherServices.Service.Response;
using WeatherServices.Service.WeatherDetail;


namespace WeatherServices.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherDataController : ControllerBase
    {
        private readonly IWeatherDetailService _service;
        private readonly IConfiguration _configuration;


        public WeatherDataController(IWeatherDetailService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorModel))]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetLocations")]
        public async Task<ActionResult<GetLocationsResponse>> GetLocations()
        {
            var response = await _service.GetLocations();

            if (response.Error != null)
            {
                if (response.Error.ErrorCode.Equals(StatusCodes.Status400BadRequest))
                    return this.StatusCode(StatusCodes.Status400BadRequest, response.Error);

            }

            return Ok(response.Locations);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type= typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorModel))]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetCurrentWeather")]
        public async Task<ActionResult<GetCurrentWeatherDataResponse>> GetCurrentWeather([FromQuery] GetCurrentWeatherRequest request)
        {
                var response = await _service.GetCurrentWeather(request);

            if(response.Error != null)
            {
                if(response.Error.ErrorCode.Equals(StatusCodes.Status400BadRequest))
                    return this.StatusCode(StatusCodes.Status400BadRequest, response.Error);    
                if(response.Error.ErrorCode.Equals(StatusCodes.Status401Unauthorized))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, response.Error);
            }

            return Ok(response);
        }
    } 
}