using Newtonsoft.Json;

Product product = new Product();
product.Name = "Apple";
product.Expiry = new DateTime(2008, 12, 28);
product.Sizes = new string[] { "Small" };

SerializeToJson(product);

string json = File.ReadAllText("product.json");
Product? p = JsonConvert.DeserializeObject<Product>(json);
Console.WriteLine($"Product {p?.Name},Expiry:{p?.Expiry},Sizes: {p?.Sizes[0]} ");

static void SerializeToJson(Product product)
{
    string json = JsonConvert.SerializeObject(product);


    Console.WriteLine(json);

    File.WriteAllText(@"product.json", JsonConvert.SerializeObject(product));
    using (StreamWriter file = File.CreateText(@"product2.json"))
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, product);
    }
}

//why would I ever use this?
// because I want people to receive my object without telling them to use c#
// data transfering format
// actually human readable - hyper TEXT transfer protocol