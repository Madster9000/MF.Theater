using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FluentAssertions;
using MF.Theater.Context.Factories;
using MF.Theater.DataModel;
using MF.Theater.Services.Queries;
using MF.Theater.Services.UnitTests.Stubs;
using Moq;
using NUnit.Framework;

namespace MF.Theater.Services.UnitTests
{
    [TestFixture]
    public class PerfomanceQueriesTests
    {
        private Mock<IDbContextFactory> mDbContextFactoryMock;
        private PerfomanceQueries mClassUnderTest;

        [SetUp]
        public void TestInitialize()
        {
            mDbContextFactoryMock = new Mock<IDbContextFactory>();
            mClassUnderTest = new PerfomanceQueries(mDbContextFactoryMock.Object);
        }

        [Test]
        public void SelectAll_ContextHasPerfomances_ReturnsCorrectCollection()
        {
            //Arrange
            var expectation = new List<Perfomance>
            {
                new Perfomance{Id = Guid.NewGuid(), Name = "Test"},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test"},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test"}
            };
            var perfomanceDbSet = PerfomanceStubs.CreateDbSet(expectation.AsQueryable());

            var contextMock = new Mock<DbContext>();
            contextMock
                .Setup(x => x.Set<Perfomance>())
                .Returns(perfomanceDbSet);
            mDbContextFactoryMock
                .Setup(x => x.CreateContext())
                .Returns(contextMock.Object);

            //Act
            var executionResult = mClassUnderTest.SelectAll();

            //Assert
            executionResult.ShouldBeEquivalentTo(expectation);
        }

    }
}