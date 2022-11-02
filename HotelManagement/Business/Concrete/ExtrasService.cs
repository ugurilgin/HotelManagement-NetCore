using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class ExtrasService : IExtrasService
    {
       private IExtrasRepository _extrasRepository;
        public ExtrasService(IExtrasRepository extrasRepository)
        {
            _extrasRepository = extrasRepository;
        }

        public Extras createExtra(Extras extras)
        {
            return _extrasRepository.createExtra(extras);
        }

        public void deleteExtra(int id)
        {
            if (id > 0)
                _extrasRepository.deleteExtra(id);
            else
                throw new Exception("Id can not be less than 1");
            
        }



        public List<Extras> getAllExtras()
        {
            return _extrasRepository.getAllExtras();
        }

        public Extras getExtra(int id)
        {
            if (id > 0)
                return _extrasRepository.getExtra(id);
            else
                throw new Exception("Id can not be less than 1");
        }


        public Extras updateExtra(int id , Extras extras)
        {
            if (id > 0) {
                return _extrasRepository.updateExtra(extras);
            }
            else
                throw new Exception("Id can not be less than 1");
        }

      
    }
}
