using System.ComponentModel.DataAnnotations;


namespace BlazorApp1.Models
{
    //Why did I put this in models instead of data
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        //Look up DataAnnotations and DataTypes
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
