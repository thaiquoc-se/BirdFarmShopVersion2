using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BirdDAO
    {
        private static BirdDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmShopContext _context;

        public BirdDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static BirdDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BirdDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Bird> GetAllBirds()
        {
            try
            {
                return _context.Birds.ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bird GetBirdByID(int id)
        {
            try
            {
                return _context.Birds.Where(b => b.BirdId == id).SingleOrDefault()!;
            }catch (Exception ex)
            {
            throw new Exception(ex.Message);
            }
        }
    }
}
