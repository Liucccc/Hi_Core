using System;
using System.Collections.Generic;
using System.Text;
using Hi_Core.Domain.Entities;
using Hi_Core.Repositories;

namespace Hi_Core.Services
{
    public class ArticleService: GenericService<ViewArticle>, IArticleService
    {
        private readonly IArticleRepository _repository;
        public ArticleService(IArticleRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
