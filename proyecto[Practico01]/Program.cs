using proyecto_Practico01_.Utils;
using proyecto_Practico01_.Services;
using proyecto_Practico01_.Entities;
using proyecto_Practico01_.Repositories;

BillingManager serviceManager = new BillingManager();

//Crear articulo
var art = new Article
{
    Name = "Jabón",
    Price = 200,
};
bool newArt = serviceManager.AddArticle(art);
Console.WriteLine("Articulo agregado: " + newArt);