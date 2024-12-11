using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using System.Globalization;
using BudgetLens.Core.Models.Statements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.AddServiceDefaults();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

public static class ImportEndpoints
{
    public static void RegisterImportEndpoints(this WebApplication app)
    {
        var imports = app.MapGroup("/imports");
    }

    public static async Task<IResult> ImportChaseStatement([FromForm] IFormFile myFile)
    {

        using var reader = new StreamReader(myFile.OpenReadStream());
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<ChaseStatement>();


    }
}

// app.MapPost("/import/chase", async ([FromForm] IFormFile myFile) =>
// {
//     try
//     {
//         using var reader = new StreamReader(myFile.OpenReadStream());
//         using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
//         var records = csv.GetRecords<ChaseStatement>();

//         foreach (var record in records)
//         {
//             Console.WriteLine(record);
//         }
//     }
//     catch (FileNotFoundException ex)
//     {
//         Console.WriteLine($"File not found: {ex.Message}");
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"An error occurred: {ex.Message}");
//     }
// });

// {
//     using var reader = new StreamReader("ChaseExample.txt");
//     using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
//     var records = csv.GetRecords<ChaseStatement>();

//     foreach (var record in records)
//     {
//         Console.WriteLine(record);
//     }
// }
//         catch (FileNotFoundException ex)
//         {
//             Console.WriteLine($"File not found: {ex.Message}");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"An error occurred: {ex.Message}");
//         }
