// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text;

const string vaultUrl = "https://mssavault.vault.azure.net/";

string tenantID = "75202359-8ca2-4185-af85-e8d288e60729";
string applicationID = "7793bb05-3a54-487d-9795-83f89c2f3b92";

var configuration = new ConfigurationBuilder().AddUserSecrets<Program>(); //this works too
var configs = configuration.Build();

string secret = configs["secret"];

ClientSecretCredential clientCredential = new ClientSecretCredential(tenantID, applicationID, secret); // this credential is establish through client id and secret

var client = new KeyClient(vaultUri: new Uri(vaultUrl), credential: clientCredential);

// Create a new key using the key client.
KeyVaultKey key = client.CreateKey("victor-key", KeyType.Rsa);


// Retrieve a key using the key client.
key = client.GetKey("victor-key");

CryptographyClient cryptoClient = client.GetCryptographyClient(key.Name, key.Properties.Version);

var encryptedData = cryptoClient.Encrypt(EncryptionAlgorithm.RsaOaep, Encoding.UTF8.GetBytes("HelloWorld"));
Console.WriteLine(Convert.ToBase64String(encryptedData.Ciphertext));

var decryptedData = cryptoClient.Decrypt(EncryptionAlgorithm.RsaOaep, encryptedData.Ciphertext);
Console.WriteLine(Encoding.UTF8.GetString(decryptedData.Plaintext));

