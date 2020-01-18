using FluentAssertions;
using UserManager.Domain.Entities;
using Xunit;

namespace UserManager.UnitTests
{
    public class DomainTests
    {
        [Fact]
        public void CreateDomainValid()
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

            user.UserName.Should().BeOfType<string>();
            user.Email.Should().BeOfType<string>();
            user.Password.Should().BeOfType<string>();
            user.Status.Should().BeTrue();
            user.Should().BeOfType<User>();

        }




    }
}
