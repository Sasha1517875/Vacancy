using AutoMapper;
using Vacancy.BL.Admins.Entities;
using Vacancy.BL.Exceptions;
using Vacancy.DataAccess.Entities;
using Vacancy.Repository;

namespace Vacancy.BL.Admins
{
    public class AdminManager : IAdminManager
    {
        private readonly IRepository<Admin> _repository;
        private readonly IMapper _mapper;

        public AdminManager(IRepository<Admin> trainersRepository, IMapper mapper)
        {
            _repository = trainersRepository;
            _mapper = mapper;
        }

        public AdminModel CreateAdmin(CreateAdminModel model)
        {

            var entity = _mapper.Map<Admin>(model);

            _repository.Save(entity);

            return _mapper.Map<AdminModel>(entity);
        }

        public void DeleteAdmin(Guid id)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                throw new NotFoundException();
            }
            _repository.Delete(entity);
        }

        public AdminModel UpdateAdmin(Guid id, UpdateAdminModel model)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                throw new NotFoundException();
            }
            entity.Name = model.Name;
            entity.Email = model.Email;
            _repository.Save(entity);
            return _mapper.Map<AdminModel>(entity);

        }
    }
}
