using AutoMapper;
using hqh.project.Application.Contract;
using hqh.project.Application.Services;
using hqh.project.Common;
using hqh.project.EntityFrameCore;
using hqh.project.EntityFrameCore.DbMigration;
using hqh.project.EntityFrameCore.DbMigration.EntityFrameCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace hqh.project.web
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))] // 在模块上添加依赖AbpAutofacModule
    [DependsOn(typeof(EntityFrameCoreModule))]
    [DependsOn(typeof(EntityFrameCoreDbMigrationModule))]
    [DependsOn(typeof(ApplicationContractModule))]
    [DependsOn(typeof(ApplicationServiceModule))]
    [DependsOn(typeof(CommonModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    public class WebModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            services.AddMvc(options => { options.EnableEndpointRouting = false; });
            services.AddAssemblyOf<WebModule>();
            //数据库表Configure DbContext
            services.AddAbpDbContext<HqhProjectDbContext>();
            base.ConfigureServices(context);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
            app.UseMvc();
        }
    }
}
