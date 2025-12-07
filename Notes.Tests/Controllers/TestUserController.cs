using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notes.Controllers;
using Notes.Dal;
using Notes.Dal.Repositories;
using Notes.JWT;
using Notes.Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Notes.Domain.DTOs.UserDTOs;

namespace Notes.Tests.Controllers
{
    public class TestUserController
    {
        private ApplicationDBContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseNpgsql("Host=localhost;Database=notesdb;Username=postgres;Password=root")
                .Options;
            return new ApplicationDBContext(options);
        }

        [Fact]
        public async Task RegisterUser_ReturnsOk()
        {
            using var db = GetDbContext();
            var userService = new UsersService(new UserRepository(db));
            var controller = new UsersController(userService, null);

            var dto = new UserRegisterDto { Login = "testuser", Password = "123" };
            var result = await controller.Register(dto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }
    }
}
