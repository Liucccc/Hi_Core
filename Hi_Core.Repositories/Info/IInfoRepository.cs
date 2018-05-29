using Hi_Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Repositories
{
    public interface IInfoRepository : IDependency, IRepository<Hi_Core_Info>
    {
    }
}
