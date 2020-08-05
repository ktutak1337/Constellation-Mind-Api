using System;
using ConstellationMind.Core.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace ConstellationMind.UnitTests.Core.Domains
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Given_valid_params_player_should_be_created()
        {
            // ------------==== Arrange ====------------

            var idnetity = Guid.NewGuid();
            var email = "user@domain.com"; 
            var password = "Secret123!";
            var nickname = "user";
            var firstName = "Bob";
            var role = Role.Admin;

            // ------------====   Act   ====------------
            
            var player = new Player(idnetity, email, password, nickname, firstName, role);

            // ------------====  Assert ====------------
            
            player.Should().NotBeNull();
            player.Identity.Should().Be(idnetity);
            player.Email.Should().Be(email);
            player.Password.Should().Be(password);
            player.Nickname.Should().Be(nickname);
            player.FirstName.Should().Be(firstName);
            player.Role.Should().Be(role);
        }

        [Test]
        public void Given_new_password_should_be_set()
        {
            // ------------==== Arrange ====------------

            var idnetity = Guid.NewGuid();
            var email = "user@domain.com"; 
            var currentPassword = "Secret123!";
            var nickname = "user";
            var firstName = "Bob";
            var role = Role.Admin;
            var newPassword = "Secret321!";

            var player = new Player(idnetity, email, currentPassword, nickname, firstName, role);

            // ------------====   Act   ====------------
            
            player.SetPassword(newPassword);

            // ------------====  Assert ====------------
            
            player.Password.Should().Be(newPassword);
        }
    }
}
