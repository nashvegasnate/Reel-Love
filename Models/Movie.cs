using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reel_Love.Models
{
  public class Movie
  {
    //public int Id { get; set; }
    public string ImdbID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Runtime { get; set; }
    public int Year { get; set; }
    public string Poster { get; set; }
    public string Plot { get; set; }
  }
}
