using Newtonsoft.Json;

Product product = new Product();
product.Name = "Apple";
product.Expiry = new DateTime(2008, 12, 28);
product.Sizes = new string[] { "Small" };

SerializeJson(product);

string json = File.ReadAllText("product.json");
Product p = JsonConvert.DeserializeObject<Product>(json);
Console.WriteLine(p.Name);

static void SerializeJson(Product product)
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