using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/stations")]
public class TrainStationsController : ControllerBase
{
    private DataContext dataContext;
    public TrainStationsController(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }
}