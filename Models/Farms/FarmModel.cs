namespace WebApi.Models.Farms
{
  public class FarmModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set;}
        public int Size { get; set; }
        public string SizeUnit { get; set; }
        public string Country { get; set;}
        public string Province { get; set;}
        public string City { get; set;}
        public double Latitude { get; set;}
        public double Longitude { get; set;}
        public bool isDeleted { get; set;}
    }
}