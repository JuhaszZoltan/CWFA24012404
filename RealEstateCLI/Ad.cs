using System.Runtime;
using System.Text;

namespace RealEstateCLI
{
    internal class Ad
    {
        public int ID { get; set; }
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floor { get; set; }
        public bool IsFreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public (double Lat, double Long) Coords { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

        public double DistanceTo(double x, double y)
            => Math.Sqrt(
                    Math.Pow(x - Coords.Lat, 2) 
                  + Math.Pow(y - Coords.Long, 2));

        public override string ToString() =>
            $"\tElado neve:         {Seller.Name}\n" +
            $"\tElado telefonszama: {Seller.Phone}\n" +
            $"\tAlapterulet:        {Area} m^2\n" +
            $"\tSzobak szama:       {Rooms}";

        public static List<Ad> LoadFromCSV(string fileName)
        {
            List<Ad> ads = new();

            using StreamReader sr = new($"..\\..\\..\\src\\{fileName}", Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] v = sr.ReadLine().Split(";");

                string[] latlong = v[2].Split(',');

                Ad ad = new()
                {
                    ID = int.Parse(v[0]),
                    Rooms = int.Parse(v[1]),
                    Coords = (
                        Lat: double.Parse(latlong[0].Replace('.', ',')),
                        Long: double.Parse(latlong[1].Replace('.', ','))),
                    Floor = int.Parse(v[3]),
                    Area = int.Parse(v[4]),
                    Description = v[5],
                    IsFreeOfCharge = v[6] == "1",
                    ImageUrl = v[7],
                    CreateAt = DateTime.Parse(v[8]),
                    Seller = new()
                    {
                        ID = int.Parse(v[9]),
                        Name = v[10],
                        Phone = v[11],
                    },
                    Category = new()
                    {
                        ID = int.Parse(v[12]),
                        Name = v[13],
                    },
                };
                ads.Add(ad);
            }

            return ads;
        }
    }
}
