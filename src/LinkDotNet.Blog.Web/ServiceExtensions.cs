﻿using LinkDotNet.Blog.Web.Features.Admin.BlogPostEditor.Services;
using LinkDotNet.Blog.Web.Features.Admin.Dashboard.Services;
using LinkDotNet.Blog.Web.Features.Admin.Sitemap.Services;
using LinkDotNet.Blog.Web.Features.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDotNet.Blog.Web;

public static class ServiceExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ILocalStorageService, LocalStorageService>();
        services.AddSingleton<ISortOrderCalculator, SortOrderCalculator>();
        services.AddScoped<IUserRecordService, UserRecordService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<ISitemapService, SitemapService>();
        services.AddScoped<IXmlFileWriter, XmlFileWriter>();
        services.AddScoped<IFileProcessor, FileProcessor>();
    }
}