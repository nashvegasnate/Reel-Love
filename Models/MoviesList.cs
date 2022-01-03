using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reel_Love.Models
{
  public class MoviesList
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PartnerId { get; set; }
    public string ListName { get; set; }
  }
}
