using Application.Abstractions.Customers;
using Application.UseCases.Customers;
using ConsoleUI.Application;
using ConsoleUI.ViewModels.Abstractions;
using ConsoleUI.ViewModels.Application;
using Domain.Abstractions.Repositories;
using Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

// const string connectionString = "Data Source=(local);Initial Catalog=Store;Integrated Security=true";
const string connectionString = "Server=DESKTOP-66QB5BG\\MSSQLSERVER01;Database=Store;User Id=StoreUser;Password=Test123;TrustServerCertificate=True;";


var services = new ServiceCollection();
services.AddSingleton<IApplicationViewModel, DefaultApplicationViewModel>();
services.AddSingleton<ICreateCustomerUseCase, DefaultCreateCustomerUseCase>();
services.AddSingleton<IGetAllCustomersUseCase, DefaultGetAllCustomersUseCase>();
services.AddSingleton<IApplication, DefaultApplication>();
services.AddSingleton<ICustomerRepository>(provider =>
    new MsSqlCustomerRepository(connectionString)
);
var serviceProvider = services.BuildServiceProvider();

var application = serviceProvider.GetRequiredService<IApplication>();
application.Start();

