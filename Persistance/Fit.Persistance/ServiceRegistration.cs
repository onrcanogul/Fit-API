using Fit.Domain.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Fit.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fit.Application.Repositories.Drink;
using Fit.Persistance.Repositories.Drink;
using Fit.Application.Repositories.Food;
using Fit.Persistance.Repositories.Food;
using Fit.Application.Repositories.Exercise;
using Fit.Persistance.Repositories.Exercise;
using Fit.Application.Repositories.Category;
using Fit.Persistance.Repositories.Category;
using Fit.Application.Abstractions.Services;
using Fit.Persistance.Services;
using Fit.Application.Repositories.BasketCalorie;
using Fit.Persistance.Repositories.BasketCalories;
using Fit.Application.Repositories.BasketItem;
using Fit.Persistance.Repositories.BasketItem;

namespace Fit.Persistance
{
    public static class ServiceRegistration
    {
        

   
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();


            
            services.AddScoped<IDrinkReadRepository, DrinkReadRepository>();
            services.AddScoped<IDrinkWriteRepository,DrinkWriteRepository>();
            services.AddScoped<INutrientReadRepository, NutrientReadRepository>();
            services.AddScoped<INutrientWriteRepository, NutrientWriteRepository>();
            services.AddScoped<IExerciseReadRepository, ExerciseReadRepository>();
            services.AddScoped<IExerciseWriteRepository, ExerciseWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<INutrientService, NutrientService>();
            services.AddScoped<IDrinkService, DrinkService>();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IBasketCalorieReadRepository, BasketCaloriesReadRepository>();
            services.AddScoped<IBasketCalorieWriteRepository, BasketCaloriesWriteRepository>();
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBasketCalorieService, BasketCalorieService>();


        }
    }
}
