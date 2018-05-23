using Hi_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Services
{
    public interface IAdvertiseService : IDependency, IService<Hi_Core.Domain.Entities.Hi_Core_Advertise>
    {
    }
}
