﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using MillionaireGame.Question.Application.Questions.Queries;
using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Persistence.DbConcrete;

namespace MillionaireGame.Question.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddMvcOptions(options => options.EnableEndpointRouting = false);

            //// Add MediatR
            services
                .AddMediatR(Assembly.GetAssembly(typeof(GetQuestionQuery)), Assembly.GetExecutingAssembly());

            //dependencies
            services.AddTransient(typeof(IRepository<Domain.Question>), typeof(RepositoryMock));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
