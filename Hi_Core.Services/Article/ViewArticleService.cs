using System;
using System.Collections.Generic;
using System.Text;
using Hi_Core.Domain.Entities;
using Hi_Core.Repositories;

namespace Hi_Core.Services
{
    public class ViewArticleService : GenericService<ViewArticle>, IViewArticleService
    {
        private readonly IViewArticleRepository _repository;
        public ViewArticleService(IViewArticleRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
