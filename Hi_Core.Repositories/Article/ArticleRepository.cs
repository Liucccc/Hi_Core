using System;
using System.Collections.Generic;
using System.Text;
using Hi_Core.Domain.Entities;
using SqlSugar;

namespace Hi_Core.Repositories
{
    public class ArticleRepository : GenericRepository<Hi_Core_Article>, IArticleRepository
    {
    }
}
