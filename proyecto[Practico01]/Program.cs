using proyecto_Practico01_.Utils;
using proyecto_Practico01_.Services;
using proyecto_Practico01_.Entities;
using proyecto_Practico01_.Repositories;

BillingManager serviceManager = new BillingManager();

//Agregar articulo
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
    Console.WriteLine($"id: {shapePay.Id}, Tipo de pago: {shapePay.Name}");
}

InvoiceManager invoiceManager = new InvoiceManager();
var invoice = invoiceManager.GetInvoices();
Console.WriteLine("\n Facturas disponibles:");
foreach (var inv in invoice)
{
    Console.WriteLine($"id: {inv.Code}, Cliente: {inv.Client}, Forma Pago: {inv.ShapePayId}, Fecha: {inv.Date}");
}

Console.WriteLine("\n Cantidad de articulos totales:");
var art = serviceManager.GetLotArticle();
foreach(var count in art)
{
    Console.WriteLine($"{count.Lot}");
}