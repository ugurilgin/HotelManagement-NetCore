using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IExtrasService
    {
        List<Extras> getAllExtras();
        Extras getExtra(int id);
        Extras createExtra(Extras extras);
        Extras updateExtra(int id,Extras extras);
        void deleteExtra(int id);
    }
}
