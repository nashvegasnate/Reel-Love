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
  [Route("api/moviesList")]
  [ApiController]
  [Authorize]
  public class MoviesListController : ControllerBase
  {
    
  }
}
