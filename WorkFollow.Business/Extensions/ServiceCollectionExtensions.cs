using AutoMapper;
using EmployeeManagement.Data.Implementaions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Business.Implementaions;
using WorkFollow.Business.Interfaces;
using WorkFollow.Core.AutoMapper;
using WorkFollow.Data.DataContext;
using WorkFollow.Data.Interfaces;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddAutoMapper(typeof(Mappers));
            serviceCollection.AddDbContext<WorkFollowDataContext>();
            serviceCollection.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireDigit = true; //Sayı zorunluluğu kalkmaz
                opt.Password.RequireLowercase = true; //Küçük Harf Zorunluluğu kalkmaz
                opt.Password.RequiredLength = 2; //En az 6 karakterlik sayı default ama ben 2 yaptım
                opt.Password.RequireNonAlphanumeric = true; //Nokta Ünlem zorunlu
                opt.Password.RequireUppercase = true; //Büyük Harf Zorunlu

                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10); //Eğer 10 defa yanlış girerse 10 dk kitle
                opt.Lockout.MaxFailedAccessAttempts = 10; //10 kere yanlış girersek hesabı kitler 

            }).AddEntityFrameworkStores<WorkFollowDataContext>();

            serviceCollection.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Home/Login"); //Oturum açmış kullanıcı girebilir demek eğer oturum açmadan bi sayfata giderse bu sayfayı dönderecek
                opt.AccessDeniedPath = new PathString("/Home/AccesDenied");
                opt.Cookie.HttpOnly = true; //Js ile o cookienin bilgilerine ulaşamaz ;)
                opt.Cookie.Name = "WorkFollowCookie"; //Tarayıcıda gözüken 
                opt.Cookie.SameSite = SameSiteMode.Strict; //Domainlerde dahil olmaz üzeri bu cookie bilgilerine ulaşılamaz
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Ne üzerinden çalışırsak ona göre ayarlanır http ise http  https ise https
                opt.ExpireTimeSpan = TimeSpan.FromDays(1);  //Benim uygulamamdaki cookie kaç gün ayakta kalacak 60 yada 90 gün olarak kullanılır.Ben 1gün olarak belirledim


            });
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IUrgencyBusiness, UrgencyBusiness>();
            serviceCollection.AddScoped<ITaskBusiness, TaskBusiness>();
            serviceCollection.AddScoped<IUserBusiness, UserBusiness>();
            serviceCollection.AddScoped<IReportBusiness, ReportBusiness>();
            return serviceCollection;
        }
    }
}
