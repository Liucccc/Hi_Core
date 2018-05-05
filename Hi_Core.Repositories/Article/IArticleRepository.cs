using System;
using System.Collections.Generic;
using System.Text;
using Hi_Core.Domain.Entities;

namespace Hi_Core.Repositories
{
    public interface IArticleRepository : IDependency, IRepository<Hi_Core_Article>
    {
    }
}
