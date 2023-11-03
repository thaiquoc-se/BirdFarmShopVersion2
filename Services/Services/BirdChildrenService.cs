using BusinessObjects.Models;
using Repositories.IRepository;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BirdChildrenService : IBirdChildrenService
    {
        private readonly IBirdChildrenRepository _birdChildrenRepository;
        public BirdChildrenService(IBirdChildrenRepository birdChildrenRepository) 
        {
            _birdChildrenRepository = birdChildrenRepository;
        }
        public List<Tblchildrenbird> GetAllBirdChildren() => _birdChildrenRepository.GetAllBirdChildren();
        
    }
}
