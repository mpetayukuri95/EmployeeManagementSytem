using EmsEmployeeManagementSytem.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//string connectionString = "Server=tcp:servermpeta.database.windows.net,1433;Initial Catalog=empdata;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\"";

//SqlConnection connection = new(connectionString);

//// Open the database connection
//connection.Open();

//// Create a SQL command
//string sqlQuery = "SELECT * FROM YourTable";
//SqlCommand command = new SqlCommand(sqlQuery, connection);

//// Execute the query and retrieve data
//SqlDataReader reader = command.ExecuteReader();

//// Process the data
//while (reader.Read())
//{
//    // Access data using reader.GetString(), reader.GetInt32(), etc.
//}

//// Close the reader when done
//reader.Close();

//// Perform database operations (e.g., execute SQL commands)

//// Close the connection when done
//connection.Close();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
