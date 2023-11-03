using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BirdChildrenDAO
    {
        private static BirdChildrenDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmShopContext _context;

        public BirdChildrenDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static BirdChildrenDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BirdChildrenDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Tblchildrenbird> GetAllBirdChildren()
        {
           return _context.Tblchildrenbirds.Include(b => b.Bird).ToList();
        }
    }
}
