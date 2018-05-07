using Hi_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Hi_Core.Domain.Entities;

namespace Hi_Core.Services
{
    public interface IArticleService: IDependency, IService<ViewArticle>
    {
    }
}
