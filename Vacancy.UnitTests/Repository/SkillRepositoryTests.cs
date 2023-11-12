using FluentAssertions;
using Vacancy.DataAccess.Entities;
using Vacancy.Repository;


namespace Vacancy.UnitTests.Repository
{

    [TestFixture]
    [Category("Integration")]
    public class SkillRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllSkillsTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var skills = new Skill[]
            {
            new Skill()
            {
                Name="Test1",
                ExternalId = Guid.NewGuid()
            },
            new Skill()
            {
                Name="Test2",
                ExternalId = Guid.NewGuid()
            },
            };
            context.Skills.AddRange(skills);
            context.SaveChanges();

            //execute
            var repository = new Repository<Skill>(DbContextFactory);
            var actualSkills = repository.GetAll();

            //assert        
            actualSkills.Should().BeEquivalentTo(skills);
        }

        [Test]
        public void GetAllSkillsWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var skills = new Skill[]
            {
            new Skill()
            {
                Name="Test1",
                ExternalId = Guid.NewGuid()
            },
            new Skill()
            {
                Name="Test2",
                ExternalId = Guid.NewGuid()
            },
            };
            context.Skills.AddRange(skills);
            context.SaveChanges();

            //execute
            var repository = new Repository<Skill>(DbContextFactory);
            var actualSkills = repository.GetAll(x => x.Name == "Test1");

            //assert
            actualSkills.Should().BeEquivalentTo(skills.Where(x => x.Name == "Test1"));
        }

        [Test]
        public void SaveNewSkillTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            //execute

            var skill = new Skill()
            {
                Name = "Test1",
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<Skill>(DbContextFactory);
            repository.Save(skill);

            //assert
            var actualSkill = context.Skills.SingleOrDefault();
            actualSkill.Should().BeEquivalentTo(skill, options => options.Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));
            actualSkill.Id.Should().NotBe(default);
            actualSkill.ModificationTime.Should().NotBe(default);
            actualSkill.CreationTime.Should().NotBe(default);
            actualSkill.ExternalId.Should().NotBe(Guid.Empty);
        }


        [Test]
        public void UpdateSkillTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var skill = new Skill()
            {
                Name = "Test1",
                ExternalId = Guid.NewGuid()
            };
            context.Skills.Add(skill);
            context.SaveChanges();

            //execute

            skill.Name = "new name";
            var repository = new Repository<Skill>(DbContextFactory);
            repository.Save(skill);

            //assert
            var actualSkill = context.Skills.SingleOrDefault();
            actualSkill.Should().BeEquivalentTo(skill);
        }

        [Test]
        public void DeleteSkillTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var skill = new Skill()
            {
                Name = "Test1",
                ExternalId = Guid.NewGuid()
            };
            context.Skills.Add(skill);
            context.SaveChanges();

            //execute

            var repository = new Repository<Skill>(DbContextFactory);
            repository.Delete(skill);

            //assert
            context.Skills.Count().Should().Be(0);
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
                context.Skills.RemoveRange(context.Skills);
                context.SaveChanges();
            }
        }
    }
}