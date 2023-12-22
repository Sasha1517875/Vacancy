using Moq;
using NUnit.Framework;
using System.Linq.Expressions;
using Vacancy.BL.Admins;
using Vacancy.BL.UnitTests.Mapper;
using Vacancy.DataAccess.Entities;
using Vacancy.Repository;

namespace Vacancy.BL.UnitTests
{
    [TestFixture]
    public class AdminProviderTest
    {
        [Test]
        public void TestGetAllAdmins()
        {
            Expression expression = null;
            Mock<IRepository<Admin>> adminRepository = new Mock<IRepository<Admin>>();
            adminRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Admin, bool>>>()))
                .Callback((Expression<Func<Admin, bool>> x) => { expression = x; });
            var adminProvider = new AdminProvider(adminRepository.Object, MapperHelper.Mapper);
            var admin = adminProvider.GetAdmins();

            adminRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<Admin, bool>>>()), Times.Exactly(1));
        }
    }
}