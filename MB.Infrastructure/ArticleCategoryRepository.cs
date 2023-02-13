﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure
{
    public class ArticleCategoryRepository:IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Add(ArticleCategory category)
        {
            _context.ArticleCategories.Add(category);
            Save();

        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(x=>x.Id).ToList();
        }

        public ArticleCategory Get(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(string title)
        {
           return _context.ArticleCategories.Any(x => x.Title == title);
        }
    }
}
