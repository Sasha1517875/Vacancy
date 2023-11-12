using FluentAssertions;
using Vacancy.DataAccess.Entities;
using Vacancy.Repository;

namespace Vacancy.UnitTests.Repository
{

    [TestFixture]
    [Category("Integration")]
    public class UserRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllUsersTest()
        {
            using var context = DbContextFactory.CreateDbContext();
            var person = new UserType()
            {
                Type = "Person",
                ExternalId = Guid.NewGuid()
            };
            var company = new UserType()
            {
                Type = "Company",
                ExternalId = Guid.NewGuid()
            };
            context.UserTypes.Add(person);
            context.UserTypes.Add(company);
            context.SaveChanges();

            var users = new User[]
            {
            new User()
            {
                Name="Test1",
                Email="Test1",
                SecretHash="Test1",
                UserTypeId = person.Id,
                ExternalId = Guid.NewGuid()
            },
            new User()
            {
                Name="Test2",
                Email="Test2",
                SecretHash="Test2",
                UserTypeId = company.Id,
                ExternalId = Guid.NewGuid()
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<User>(DbContextFactory);
            var actualUsers = repository.GetAll();

            //assert        
            actualUsers.Should().BeEquivalentTo(users, options => options.Excluding(x => x.UserType));
        }

        [Test]
        public void GetAllUsersWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var person = new UserType()
            {
                Type = "Person",
                ExternalId = Guid.NewGuid()
            };
            var company = new UserType()
            {
                Type = "Company",
                ExternalId = Guid.NewGuid()
            };
            context.UserTypes.Add(person);
            context.UserTypes.Add(company);
            context.SaveChanges();

            var users = new User[]
            {
            new User()
            {
                Name="Test1",
                Email="Test1",
                SecretHash="Test1",
                UserTypeId = person.Id,
                ExternalId = Guid.NewGuid()
            },
            new User()
            {
                Name="Test2",
                Email="Test2",
                SecretHash="Test2",
                UserTypeId = company.Id,
                ExternalId = Guid.NewGuid()
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();
            //execute

            var repository = new Repository<User>(DbContextFactory);
            var actualUsers = repository.GetAll(x => x.Name == "Test1").ToArray();

            //assert
            actualUsers.Should().BeEquivalentTo(users.Where(x => x.Name == "Test1"),
                options => options.Excluding(x => x.UserType));
        }

        [Test]
        public void SaveNewUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var person = new UserType()
            {
                Type = "Person",
                ExternalId = Guid.NewGuid()
            };

            context.UserTypes.Add(person);
            context.SaveChanges();

            //execute

            var user = new User()
            {
                Name = "Test1",
                Email = "Test1",
                SecretHash = "Test1",
                UserTypeId = person.Id,
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<User>(DbContextFactory);
            repository.Save(user);

            //assert
            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.UserType)
                .Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));
            actualUser.Id.Should().NotBe(default);
            actualUser.ModificationTime.Should().NotBe(default);
            actualUser.CreationTime.Should().NotBe(default);
            actualUser.ExternalId.Should().NotBe(Guid.Empty);
        }


        [Test]
        public void UpdateUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var person = new UserType()
            {
                Type = "Person",
                ExternalId = Guid.NewGuid()
            };

            context.UserTypes.Add(person);
            context.SaveChanges();

            var user = new User()
            {
                Name = "Test1",
                Email = "Test1",
                SecretHash = "Test1",
                UserTypeId = person.Id,
                ExternalId = Guid.NewGuid()
            };
            context.Users.Add(user);
            context.SaveChanges();

            //execute

            user.Name = "new name";
            user.Email = "new email";
            user.SecretHash = "new secret hash";
            var repository = new Repository<User>(DbContextFactory);
            repository.Save(user);

            //assert
            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.UserType));
        }

        [Test]
        public void DeleteUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var person = new UserType()
            {
                Type = "Person",
                ExternalId = Guid.NewGuid()
            };

            context.UserTypes.Add(person);
            context.SaveChanges();

            var user = new User()
            {
                Name = "Test1",
                Email = "Test1",
                SecretHash = "Test1",
                UserTypeId = person.Id,
                ExternalId = Guid.NewGuid()
            };
            context.Users.Add(user);
            context.SaveChanges();

            //execute

            var repository = new Repository<User>(DbContextFactory);
            repository.Delete(user);

            //assert
            context.Users.Count().Should().Be(0);
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            using (var context = DbContextFactory.CreateDbContext())
            {
                context.Users.RemoveRange(context.Users);
                context.UserTypes.RemoveRange(context.UserTypes);
                context.SaveChanges();
            }
        }
    }
}