using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SP23.P01.Web.Entities;

[ApiController]
[Route("api/stations")]
public class TrainStationsController : ControllerBase
{
    private DataContext dataContext;
    public TrainStationsController(DataContext dataContext)
    {
        this.dataContext= dataContext;
    }

   // [HttpGet]
   // [Route("{id}")]
   // public ActionResult<TrainStationDto> GetById(int id)
   // {
   //     var trains = dataContext.Set<TrainStation>();
   //     return Ok(trains.Where(x => x.Id == id).Select(x => new TrainStationDto)
   // }
}