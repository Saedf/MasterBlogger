using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using MB.Application;
using MB.Application.Contract.Article;
using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;
using MB.Infrastructure;
using MB.Infrastructure.Repositories;
using MB.Infrastrucutre.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastrucutre.Core
{
    public class Bootstrapper
    {
        public static void Configure(IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<MasterBloggerContext>(x => x.UseSqlServer(connectionString));

            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidationService, ArticleCategoryValidationService>();

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleValidatorServices, ArticleValidatorService>();

            services.AddTransient<IArticleQuery,ArticleQuery>();

        }
    }
}
