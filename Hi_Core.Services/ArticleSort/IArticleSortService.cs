using Hi_Core.Domain.Entities;
using Hi_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Services
{
    public interface IArticleSortService : IDependency, IService<Hi_Core_ArticleSort>
    {
    }
}
