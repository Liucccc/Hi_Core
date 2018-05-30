using Hi_Core.Domain.Entities;
using Hi_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Services
{
    public class InitService : GenericService<Hi_Core_Init>, IInitService
    {
        private readonly IInitRepository _repository;
        public InitService(IInitRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
