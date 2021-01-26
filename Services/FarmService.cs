using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IFarmService
    {
        
        IEnumerable<Farm> GetAll();
        Farm GetById(int id);
        Farm Create(Farm farm);
        void Update(Farm farm);
        void Delete(int id);
    }

    public class FarmService : IFarmService
    {
        private DataContext _context;

        public FarmService(DataContext context)
        {
            _context = context;
        }

        
        public IEnumerable<Farm> GetAll()
        {
            return _context.Farms;
        }

        public Farm GetById(int id)
        {
            return _context.Farms.Find(id);
        }

        public Farm Create(Farm farm)
        {
            // validation
            

            if (_context.Farms.Any(x => x.Name == farm.Name)&& _context.Farms.Any(x => x.Owner == farm.Owner) && _context.Farms.Any(x=> x.City == farm.City))
                throw new AppException("Farm \"" + farm.Name + "\" is already registered");

            

            _context.Farms.Add(farm);
            _context.SaveChanges();

            return farm;
        }

        public void Update(Farm farmParam)
        {
            var farm = _context.Farms.Find(farmParam.Id);

            if (farm == null)
                throw new AppException("Farm not found");

            // update farm properties if provided
            if (!string.IsNullOrWhiteSpace(farmParam.Name))
                farm.Name = farmParam.Name;

            if (!string.IsNullOrWhiteSpace(farmParam.Owner))
                farm.Owner = farmParam.Owner;

            if (!string.IsNullOrWhiteSpace((farmParam.Size).ToString()))
                farm.Size = farmParam.Size;

            if (!string.IsNullOrWhiteSpace(farmParam.SizeUnit))
                farm.SizeUnit = farmParam.SizeUnit;
            
            if (!string.IsNullOrWhiteSpace(farmParam.Country))
                farm.Country = farmParam.Country;
                
            if (!string.IsNullOrWhiteSpace(farmParam.Province))
                farm.Province = farmParam.Province;
                
            if (!string.IsNullOrWhiteSpace(farmParam.City))
                farm.City = farmParam.City;
                                
            if (!string.IsNullOrWhiteSpace((farmParam.Latitude).ToString()))
                farm.Latitude = farmParam.Latitude;

            if (!string.IsNullOrWhiteSpace((farmParam.Longitude).ToString()))
                farm.Longitude = farmParam.Longitude;
                

            

            _context.Farms.Update(farm);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var farm = _context.Farms.Find(id);
            if (farm != null)
            {
                _context.Farms.Remove(farm);
                _context.SaveChanges();
            }
        }

        

        
    }
}