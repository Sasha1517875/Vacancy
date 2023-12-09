using Vacancy.BL.Admins.Entities;

namespace Vacancy.BL.Admins
{
    public interface IAdminManager
    {
        AdminModel CreateAdmin(CreateAdminModel model);
        void DeleteAdmin(Guid id);
        AdminModel UpdateAdmin(Guid id, UpdateAdminModel model);
    }
}
