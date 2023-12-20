using EasyCRM.BAL.Interface;
using EasyCRM.BAL.Service;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Repository;


namespace EasyCRM
{
    public static class DependencyResolver
    {
        public static void Resolve(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ICompanyService,CompanyService>();
            builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
            builder.Services.AddScoped<ICustomersService, CustomersService>();
            builder.Services.AddScoped<IEmployeeRepository, EmplyeeRepository>();
            builder.Services.AddScoped<IEmployeeservice, Employeeservice>();
            builder.Services.AddScoped<IEngineersrepository , Engineersrepository>();
            builder.Services.AddScoped<IEngineersService, EngineersService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IStaffRepository, StaffRepository>();
            builder.Services.AddScoped<IStaffService, StaffService>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();
            builder.Services.AddScoped<IReportService, ReportService>();





        }
    }
    
}
