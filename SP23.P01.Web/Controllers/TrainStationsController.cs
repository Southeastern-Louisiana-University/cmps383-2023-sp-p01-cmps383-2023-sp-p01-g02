using SP23.P01.Web.Dtos;
using Microsoft.AspNetCore.Mvc;
using Azure;
using static System.Net.WebRequestMethods;
using SP23.P01.Web.Entities;
using Microsoft.IdentityModel.Tokens;

namespace SP23.P01.Web.Controllers
{
    [ApiController]
    [Route("/api/stations")]
    public class TrainStationsController : ControllerBase
    {

        private DataContext _dataContext;

        public TrainStationsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public ActionResult GetStations()
        {
            var returnedStations = _dataContext.TrainStations.Select(x => new TrainStationDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
            }).ToList();
            return Ok(returnedStations);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            List<String> Errors = new List<String>();
            if (id <= 0)
            {
                Errors.Add("Must be at least a positive value of 1!");
                return BadRequest(Errors);
            }
            var matchingStation = _dataContext.TrainStations.FirstOrDefault(x => x.Id == id);
            if (matchingStation == null)
            {
                Errors.Add("The train station that was requested could not be found!");
                return NotFound(Errors);
            }
            else
            {
                var returnStation = new TrainStationDto
                {
                    Id = matchingStation.Id,
                    Name = matchingStation.Name,
                    Address = matchingStation.Address
                };
                return Ok(returnStation);
            }
        }

        [HttpPost]
        public ActionResult CreateStation(TrainStationsCreateDto createDto)
        {
            List<String> Errors = new List<String>();

            if (createDto.Name.IsNullOrEmpty())
            {
                return BadRequest("A name must be entered!");
            }
            if (createDto.Name.Trim().Length > 120)
            {
                return BadRequest("The name length cannot be longer than 120!");
            }
            if (createDto.Address.IsNullOrEmpty())
            {
                return BadRequest("An address must be entered!");
            }

            var TrainStationtoAdd = new TrainStation
            {
                Name = createDto.Name,
                Address = createDto.Address,
            };
            _dataContext.TrainStations.Add(TrainStationtoAdd);
            _dataContext.SaveChanges();

            TrainStationDto returnStation = new TrainStationDto
            {
                Id = TrainStationtoAdd.Id,
                Name = TrainStationtoAdd.Name,
                Address = TrainStationtoAdd.Address,
            };
            string Url = $"http://localhost/api/stations/{returnStation.Id}";
            return Created(Url, returnStation);


        }

        [HttpPut("{id}")]
        public ActionResult UpdateStation(int id, TrainStationsUpdateDto updatesDto)
        {
            List<String> Errors = new List<String>();
            if (id <= 0)
            {
                Errors.Add("Must be at least a positive value of 1!");
            }
            if (updatesDto.Name.IsNullOrEmpty())
            {
                return BadRequest("A name must be entered!");
            }
            if (updatesDto.Name.Trim().Length > 120)
            {
                Errors.Add("The name length cannot be longer than 120!");
            }
            if (updatesDto.Address.IsNullOrEmpty())
            {
                Errors.Add("An address must be entered!");
            }
            var stationToUpdate = _dataContext.TrainStations.FirstOrDefault(x => x.Id == id);
            if (stationToUpdate == null)
            {
                Errors.Add("The train station that was requested could not be found!");
                return NotFound(Errors);
            }

            stationToUpdate.Name = updatesDto.Name;
            stationToUpdate.Address = updatesDto.Address;
            _dataContext.SaveChanges();

            TrainStationDto returnStation = new TrainStationDto
            {
                Id = stationToUpdate.Id,
                Name = stationToUpdate.Name,
                Address = stationToUpdate.Address,
            };
            return Ok(returnStation);
        }

        [HttpDelete("{id}")]
        public ActionResult deleteStation(int id)
        {
            var station = _dataContext.TrainStations.FirstOrDefault(x => x.Id == id);

            if (station == null)
            {
                return NotFound("The train station that was requested could not be found!");
            }

            _dataContext.TrainStations.Remove(station);
            _dataContext.SaveChanges();
            return Ok();

        }
    }
}