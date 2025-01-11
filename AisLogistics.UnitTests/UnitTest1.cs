using System;
using AisLogistics.App.Service;
using AisLogistics.DataLayer.Concrete;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AisLogistics.UnitTests
{
    public class Tests
    {
        private CaseService _caseService;

        [SetUp]
        public void Setup()
        {
           // _caseService = new CaseService();
        }

        [Test]
        public void Test1()
        {
           // ICaseService qqq = new CaseService(new AisLogisticsContext());
            //qqq.GetCases()
            var t = new Mock<ICaseService>();
            //var q = _caseService.Test("qq");
            //Console.WriteLine(q);
            Assert.Pass();
        }
    }
}