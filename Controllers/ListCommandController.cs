using Reel_Love.Data_Access;
using Reel_Love.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace Reel_Love.Controllers
{
  [Route("api/listCommand")]
  [ApiController]
  public class ListCommandController : ControllerBase
  {

    ListCommandRepository _repo;

    public ListCommandController(ListCommandRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAllListCommands()
    {
      return Ok(_repo.GetAll());
    }

    [HttpGet("/GetById/{Id}")]
    public List<ListCommand> GetById(Guid Id)
    {
      return _repo.GetById(Id);
    }
  }
}
