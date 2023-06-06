using Nucleus.Blog.Contracts.Collections;
using Nucleus.Blog.Contracts.Models;
using System;
using System.Linq.Expressions;

namespace Nucleus.Blog.Persistence.Services
{
    public static class Projections
    {
        public static Expression<Func<BlogCollection, BlogModel>> Blogs => item => new BlogModel()
        { 
            BlogId = item.BlogId,
            Content = item.Content,
            Tags = item.Tags,
            Preview = item.Preview,
            Slug = item.Slug,
            Title = item.Title,
            Enabled = item.Enabled,
            Author = item.Author,
            CreatedOn = item.CreatedOn,
        };
    }
}
