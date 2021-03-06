﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hi_Core.Services;
using Hi_Core.Repositories;
using UEditorNetCore;

namespace Hi_Core.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            //返回json  大小写
            services.AddMvc().AddJsonOptions(op => op.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());

            //添加UEditorNetCore服务
            services.AddUEditorService();

            //跨域配置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                 builder => builder.WithOrigins("http://localhost:28708").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            services.AddTransient<IViewArticleRepository, ViewArticleRepository>();
            services.AddTransient<IViewArticleService, ViewArticleService>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IArticleSortRepository, ArticleSortRepository>();
            services.AddTransient<IArticleSortService, ArticleSortService>();
            services.AddTransient<IAdvertiseRepository, AdvertiseRepository>();
            services.AddTransient<IAdvertiseService, AdvertiseService>();
            services.AddTransient<IInfoRepository, InfoRepository>();
            services.AddTransient<IInfoService, InfoService>();
            services.AddTransient<IInitRepository, InitRepository>();
            services.AddTransient<IInitService, InitService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseStaticFiles();

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });

        }
    }
}
