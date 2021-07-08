using Application.Abstract;
using Application.Concrete.Services;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.Abstract;
using Domain.Concrete;
using Infrastructure.Data.Abstract;
using Infrastructure.Data.Concrete.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Map
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterProject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("Default")).UseLazyLoadingProxies());

            services.AddDefaultIdentity<User>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                //Tm7&kk

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 3;
                //Makes the user wait for 10 minutes after 3 failed attempts
            }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DatabaseContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();

            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<IBlockService, BlockService>();
            services.AddScoped<IBlockRepository, BlockRepository>();

            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IBillRepository, BillRepository>();

            services.AddScoped<IDebtTypeService, DebtTypeService>();
            services.AddScoped<IDebtTypeRepository, DebtTypeRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddHttpClient<ICreditCardService, CreditCardService>(options => {
                options.BaseAddress = new Uri(configuration["CreditCard:Url"]);
            });


            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.AddProfile(new MapProfiles());
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper); 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}