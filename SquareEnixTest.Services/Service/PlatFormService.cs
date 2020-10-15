using SquareEnixTest.Data.Models;
using SquareEnixTest.Services.Interfaces;
using SquareEnixTest.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SquareEnixTest.Services
{
    public class PlatformService: IPlatformService
    {
        private PlatFormRepository _platformRepository;
        public PlatformService(PlatFormRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public IList<Platform> getAllPlatform()
        {
            return _platformRepository.GetAll(x=>x!=null).ToList();
        }

        public Platform getPlatformById(int id)
        {
            return _platformRepository.GetAll(x => x.Id == id).SingleOrDefault();
        }

        public Platform getPlatformByName(string name)
        {
            return _platformRepository.GetAll(x => x.Name == name).FirstOrDefault();
        }

       
    }
}
