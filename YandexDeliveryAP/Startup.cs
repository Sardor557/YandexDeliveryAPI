using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO.Compression;
using ZNetCS.AspNetCore.Compression.Compressors;
using ZNetCS.AspNetCore.Compression;
using YandexDeliveryAPI.Services;
using Newtonsoft.Json.Serialization;
using YandexDeliveryAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Serilog;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using YandexDeliveryAPI.Services.Models;

namespace YandexDeliveryAPI
{
    public class Startup
    {
        public IConfiguration conf { get; }
        public Startup(IConfiguration config) => conf = config;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddCompression(options =>
            {
                options.Compressors = new List<ICompressor>
                {
                    new GZipCompressor(CompressionLevel.Fastest), 
                    new DeflateCompressor(CompressionLevel.Fastest), 
                    new BrotliCompressor(CompressionLevel.Fastest) 
                };
            });

            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options => { options.Level = CompressionLevel.Fastest; });
            services.Configure<BrotliCompressionProviderOptions>(options => { options.Level = CompressionLevel.Fastest; });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                        });
            });

            services.Configure<Settings>(conf.GetSection("YandexAPI"));
            
            services.AddEndpointsApiExplorer();
            services.AddMySwagger();

            services.AddMyServices();

            services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddMemoryCache();
            services.AddMyAuthentication(conf);
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseCompression();
            app.UseDeveloperExceptionPage();

            app.UseRequestLocalization();

            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            var FileStorePath = AppDomain.CurrentDomain.BaseDirectory + $"wwwroot{Path.DirectorySeparatorChar}store";
            if (!Directory.Exists(FileStorePath)) Directory.CreateDirectory(FileStorePath);
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx => { ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age=604800"); },
                FileProvider = new PhysicalFileProvider(FileStorePath),
                RequestPath = "/store"
            });

            app.UseRouting();

            app.UseCors("AllowAllHeaders");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSerilogRequestLogging();
            app.UseMySwagger();
        }
    }
}
