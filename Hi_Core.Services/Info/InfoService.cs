using Hi_Core.Domain.Entities;
using Hi_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Services
{
    public class InfoService : GenericService<Hi_Core_Info>, IInfoService
    {
        private readonly IInfoRepository _repository;
        public InfoService(IInfoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
