using Application;
using Application.DTOs;
using Application.Guest;
using Application.Guest.Requests;
using Domain.Entities;
using Domain.Ports;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Specialized;
using System.Reflection.Metadata;

namespace ApplicationTests
{

    #region -- Forma de testar criando os prórios fakes do repo
    //class FakeRepo : IGuestRepository
    //{
    //    public Task<int> Create(Guest guest)
    //    {
    //        return Task.FromResult(111);
    //    }

    //    public Task Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Guest> Get(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<List<Guest>> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<int> Update(Guest guest)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    #endregion 

    public class Tests
    {

        GuestManager guestManager;
        [SetUp]
        public void Setup()
        {
            //var fakeRepo = new FakeRepo(); Forma de criar o repo de teste na unha


        }

        [Test]
        public async Task HappyPath()
        {
            var guestDTO = new GuestDTO
            {
                Name = "Fulano",
                SurName = "Ciclano",
                Email = "email@test.com",
                IdNumber = "1234",
                IdTypeCode = 1
            };

            int expectedId = 222;

            var guestRequest = new CreateGuestRequest
            {
                Data = guestDTO,
            };

            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Create(
                It.IsAny<Guest>())).Returns(Task.FromResult(222));

            guestManager = new GuestManager(fakeRepo.Object);

            var res = await guestManager.CreateGuest(guestRequest);
            Assert.IsNotNull(res);
            Assert.True(res.Success);
            Assert.AreEqual(res.Data.Id, expectedId);
            Assert.AreEqual(res.Data.Name, guestDTO.Name);
            Assert.AreEqual(res.Data.SurName, guestDTO.SurName);
            Assert.AreEqual(res.Data.Email, guestDTO.Email);
            Assert.AreEqual(res.Data.IdNumber, guestDTO.IdNumber);
            Assert.AreEqual(res.Data.IdTypeCode, guestDTO.IdTypeCode);
        }

        [TestCase("")]
        [TestCase("a")]
        [TestCase("1")]
        [TestCase("ab")]
        [TestCase(null)]
        public async Task ShouldReturnInvalidPersondocumentWhenDocsAreInvalid(string docNumber)
        {
            var guestDTO = new GuestDTO
            {
                Name = "Fulano",
                SurName = "Ciclano",
                Email = "email@test.com",
                IdNumber = docNumber,
                IdTypeCode = 1
            };

            var guestRequest = new CreateGuestRequest
            {
                Data = guestDTO,
            };

            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Create(
                It.IsAny<Guest>())).Returns(Task.FromResult(222));

            guestManager = new GuestManager(fakeRepo.Object);

            var res = await guestManager.CreateGuest(guestRequest);
            Assert.IsNotNull(res);
            Assert.False(res.Success);
            Assert.AreEqual(res.ErrorCode, ErrorCode.INVALID_DOCUMENT);
            Assert.AreEqual(res.Message, "Document Id is not valid");

        }

        [TestCase("", "surname", "maro@gmail.com")]
        [TestCase(null, "surname", "maro@gmail.com")]

        [TestCase("name", "", "maro@gmail.com")]
        [TestCase("name", null, "maro@gmail.com")]

        [TestCase("name", "surname", "")]
        [TestCase("name", "surname", null)]

        public async Task ShouldReturnMissingInformationWhenInfosAreInvalid(string name, string surname, string email)
        {
            var guestDTO = new GuestDTO
            {
                Name = name,
                SurName = surname,
                Email = email,
                IdNumber = "abcd",
                IdTypeCode = 1
            };

            var guestRequest = new CreateGuestRequest
            {
                Data = guestDTO,
            };

            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Create(
                It.IsAny<Guest>())).Returns(Task.FromResult(222));

            guestManager = new GuestManager(fakeRepo.Object);

            var res = await guestManager.CreateGuest(guestRequest);
            Assert.IsNotNull(res);
            Assert.False(res.Success);
            Assert.AreEqual(res.ErrorCode, ErrorCode.MISSING_REQUIRED_INFORMATION);
            Assert.AreEqual(res.Message, "Missing required information");

        }

        [TestCase("b@b.com")]       

        public async Task ShouldReturnInvalidEmailWhenEmailIsInvalid(string email)
        {
            var guestDTO = new GuestDTO
            {
                Name = "Teste",
                SurName = "Surname",
                Email = email,
                IdNumber = "abcd",
                IdTypeCode = 1
            };

            var guestRequest = new CreateGuestRequest
            {
                Data = guestDTO,
            };

            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Create(
                It.IsAny<Guest>())).Returns(Task.FromResult(222));

            guestManager = new GuestManager(fakeRepo.Object);

            var res = await guestManager.CreateGuest(guestRequest);
            Assert.IsNotNull(res);
            Assert.False(res.Success);
            Assert.AreEqual(res.ErrorCode, ErrorCode.INVALID_EMAIL);
            Assert.AreEqual(res.Message, "Invalid Email");

        }
    }
}