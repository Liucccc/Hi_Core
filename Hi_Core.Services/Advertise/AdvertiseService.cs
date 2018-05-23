using Hi_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Services
{
    public class AdvertiseService : GenericService<Hi_Core.Domain.Entities.Hi_Core_Advertise>, IAdvertiseService
    {
        private readonly IAdvertiseRepository _repository;
        public AdvertiseService(IAdvertiseRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
