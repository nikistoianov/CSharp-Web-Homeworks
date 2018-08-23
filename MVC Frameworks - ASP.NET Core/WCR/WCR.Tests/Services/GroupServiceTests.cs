namespace WCR.Tests.Services
{
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using WCR.Data;
    using WCR.Models;
    using WCR.Services.Competition;
    using WCR.Tests.Mocks;

    [TestClass]
    public class GroupServiceTests
    {
        private WCRDbContext dbContext;
        private IMapper mapper;

        [TestMethod]
        public void GetGroups_WithFewGrous_ShoudReturnAll()
        {
            this.dbContext.Groups.Add(new Group() { Date = DateTime.Now, Name = "C" });
            this.dbContext.Groups.Add(new Group() { Date = DateTime.Now, Name = "A" });
            this.dbContext.Groups.Add(new Group() { Date = DateTime.Now, Name = "B" });
            this.dbContext.SaveChanges();

            var tt = dbContext.Groups.ToList();

            var service = new GroupService(dbContext, null);

            var groups = service.GetGroups();

            Assert.IsNotNull(groups);
            Assert.AreEqual(3, groups.Count);
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetDbContext();
            this.mapper = MockAutoMapper.GetAutoMapper();
        }
    }
}
