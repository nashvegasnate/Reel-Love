using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reel_Love.Models
{
  public class ListCommand
  {
    public Guid Id { get; set; }
    public Guid ListId { get; set; }
    public string MovieId {get; set;}
  }
}
