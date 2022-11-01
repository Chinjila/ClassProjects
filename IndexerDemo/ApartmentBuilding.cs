namespace IndexerDemo
{
    public class ApartmentBuilding
    {
        Dictionary<string, Apartment> apartmentDirectory;
        //List<Payment>
        public ApartmentBuilding()
        {
            apartmentDirectory = new Dictionary<string, Apartment>();
            for (int i = 0; i < 3; i++)
            {
                apartmentDirectory.Add($"{i}A", new Apartment { Owner = $"Bob-{i}A" });
                apartmentDirectory.Add($"{i}B", new Apartment { Owner = $"Bob-{i}B" });
                apartmentDirectory.Add($"{i}C", new Apartment { Owner = $"Bob-{i}C" });
            }
        }

        public int ApartmentCount
        {
            get

            { return apartmentDirectory.Count; }
        }

        public Apartment GetApartment(string Apartment)
        {
            if (apartmentDirectory.TryGetValue(Apartment, out Apartment result))
            { return result; }
            else
            {
                throw new Exception("Apartment not found");
            }
        }

        public class Apartment
        {
            public int Price { get; set; }
            public string Owner { get; set; }
            public int NumberOfRoom { get; set; }
            public string ApartmentNumber { get; set; }
        }
    }
}