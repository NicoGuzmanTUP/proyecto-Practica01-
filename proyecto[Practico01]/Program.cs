using proyecto_Practico01_.Utils;
using proyecto_Practico01_.Services;
using proyecto_Practico01_.Entities;
using proyecto_Practico01_.Repositories;

BillingManager serviceManager = new BillingManager();

//Crear articulo
//var art = new Article
//{
//    Name = "Jabón",
//    Price = 200,
//};
//bool newArt = serviceManager.AddArticle(art);
//Console.WriteLine("Articulo agregado: " + newArt);


Console.WriteLine("Formas de pagos disponibles... ");
var tipePay = serviceManager.GetShapePays();
foreach (var shapePay in tipePay)
{
    Console.WriteLine($"id: {shapePay.Id} /n name: {shapePay.Name}");
}