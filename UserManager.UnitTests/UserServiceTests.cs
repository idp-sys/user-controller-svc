using UserManager.Application.Services;
using UserManager.Domain.Entities;
using UserManager.Infra.CrossCutting.Identity.Repositories;
using Xunit;

namespace UserManager.UnitTests
{
    public class UserServiceTests
    {
        private UserService _service;
        private UserRepository _repository;

        public UserServiceTests()
        {
            _repository = new UserRepository(); 
            _service = new UserService(_repository);
        }



        [Fact]
        public void CreateUserValid()
        {
            var create = new
            {
                name = "fulano",
                email = "teste@teste.com.br",
                password = "123",
                status = true
            };

            User user = new User
            {
                UserName = create.name,
                Email = create.email,
                Password = create.password,
                Status = create.status

            };


            //TODO Validar
         
        }


    }
}
