namespace WebApi.Entities
{
    public class Farm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set;}
        public int Size { get; set; }
        public string SizeUnit { get; set; }
        public string Country { get; set;}
        public string Province { get; set;}
        public string City { get; set;}
        public int Latitude { get; set;}
        public int Longitude { get; set;}
        public bool isDeleted { get; set;}
    }
}