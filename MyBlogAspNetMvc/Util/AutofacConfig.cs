using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using MyBlogAspNetMvc.Domains;
using MyBlogAspNetMvc.Repositories;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using MyBlogAspNetMvc.Models;

namespace MyBlogAspNetMvc.Util
{
    /*
     * Библиотеки для внедрения зависимостей:
     * Autofac
     * Autofac.Mvc5
     */
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            //Получаем объект контейнера
            var builder = new ContainerBuilder();
            //Регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //Регистрируем сопоставление типов
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            //Создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();
            //Установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}