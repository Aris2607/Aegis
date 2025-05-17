using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AegisTest.Models;
using ClosedXML.Excel;
using AegisTest.Data.Interfaces;
using Rotativa.AspNetCore;

namespace AegisTest.Controllers;

[Route("[controller]")]
public class HomeController : Controller
{
    private readonly IOrderRepository _orderRepository;

    public HomeController(ILogger<HomeController> logger, IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("GetOrders")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderRepository.GetOrdersAsync();
        return Ok(orders);
    }

    [Route("export/excel")]
    public async Task<IActionResult> ExportToExcel()
    {
        var orders = await _orderRepository.GetOrdersAsync();

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Orders");
            worksheet.Cell(1, 1).Value = "Order ID";
            worksheet.Cell(1, 2).Value = "Customer Name";
            worksheet.Cell(1, 3).Value = "Email";
            worksheet.Cell(1, 4).Value = "Product Name";
            worksheet.Cell(1, 5).Value = "Price";
            worksheet.Cell(1, 6).Value = "Quantity";
            worksheet.Cell(1, 7).Value = "Total";
            worksheet.Cell(1, 8).Value = "Order Date";

            int row = 2;
            foreach (var order in orders)
            {
                worksheet.Cell(row, 1).Value = order.OrderId;
                worksheet.Cell(row, 2).Value = order.CustomerName;
                worksheet.Cell(row, 3).Value = order.Email;
                worksheet.Cell(row, 4).Value = order.ProductName;
                worksheet.Cell(row, 5).Value = order.Price;
                worksheet.Cell(row, 6).Value = order.Quantity;
                worksheet.Cell(row, 7).Value = order.Total;
                worksheet.Cell(row, 8).Value = order.OrderDate.ToString("yyyy-MM-dd");
                row++;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = $"Orders_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                return File(stream.ToArray(), contentType, fileName);
            }
        }
    }

    [Route("export/pdf")]
    public IActionResult Pdf()
    {
        var orders = _orderRepository.GetOrdersAsync().Result;
        return new ViewAsPdf("PdfTemplate", orders)
        {
            FileName = "OrderReport.pdf"
        };
    }

    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [Route("error")]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
