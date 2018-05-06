using Hi_Core.Domain.Entities;
using Hi_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Services
{
    public class ArticleSortService : GenericService<Hi_Core_ArticleSort>, IArticleSortService
    {
        private readonly IArticleSortRepository _repository;
        public ArticleSortService(IArticleSortRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
