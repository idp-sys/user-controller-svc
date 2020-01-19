using FluentAssertions;
using UserManager.API.Models;
using Xunit;

namespace UserManager.UnitTests
{
    
    public class ApiModelsTests
    {
        [Fact]
        public void UpdateModelValid()
        {
            var update = new
            {
                name = "fulano",
                email = "teste@teste.com.br"
            };

            UserViewModelUpdate userViewModel = new UserViewModelUpdate
            {
                Name = update.name,
                Email = update.email
            };
            
            userViewModel.Name.Should().BeOfType<string>();
            userViewModel.Email.Should().BeOfType<string>();
            userViewModel.Should().BeOfType<UserViewModelUpdate>();
             
        }

        [Fact]
        public void CreateModelValid()
        {
            var create = new
            {
                name = "fulano",
                email = "teste@teste.com.br",
                password = "123"
            };

            UserViewModelCreate userViewModel = new UserViewModelCreate
            {
                Name = create.name,
                Email = create.email,
                Password = create.password
            };

            userViewModel.Name.Should().BeOfType<string>();
            userViewModel.Email.Should().BeOfType<string>();
            userViewModel.Password.Should().BeOfType<string>();
            userViewModel.Should().BeOfType<UserViewModelCreate>();

        }


    }
}
