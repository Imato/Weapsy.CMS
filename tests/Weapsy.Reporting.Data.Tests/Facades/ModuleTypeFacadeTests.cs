﻿using System;
using Moq;
using NUnit.Framework;
using Weapsy.Domain.Apps;
using Weapsy.Domain.ModuleTypes;
using Weapsy.Infrastructure.Caching;
using Weapsy.Reporting.Data.ModuleTypes;
using Weapsy.Reporting.ModuleTypes;

namespace Weapsy.Reporting.Data.Tests.Facades
{
    [TestFixture]
    public class ModuleTypeFacadeTests
    {
        private IModuleTypeFacade _sut;
        private Guid _siteId;
        private Guid _moduleTypeId;

        [SetUp]
        public void Setup()
        {
            _siteId = Guid.NewGuid();
            _moduleTypeId = Guid.NewGuid();

            var moduleTypeRepositoryMock = new Mock<IModuleTypeRepository>();
            var appRepositoryMock = new Mock<IAppRepository>();
            var cacheManagerMock = new Mock<ICacheManager>();

            var mapperMock = new Mock<AutoMapper.IMapper>();
            mapperMock.Setup(x => x.Map<ModuleTypeAdminModel>(It.IsAny<ModuleType>())).Returns(new ModuleTypeAdminModel());

            _sut = new ModuleTypeFacade(moduleTypeRepositoryMock.Object,
                appRepositoryMock.Object,
                cacheManagerMock.Object, 
                mapperMock.Object);
        }
    }
}
