using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.BL.Admins.Entities;

namespace Vacancy.BL.Admins
{
    public interface IAdminProvider
    {
        IEnumerable<AdminModel> GetAdmins(AdminModelFilter filter = null);
        AdminModel GetAdminInfo(Guid id);
    }
}
