using System;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.Authentication.Interfaces;
using ConstellationMind.Infrastructure.Services.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace ConstellationMind.UnitTests.Services
{
    [TestFixture]
    public class AccountServiceTests
    {
        private Mock<IPlayerRepository> _playerRepositoryMock;
        private Mock<IScoreboardRepository> _scoreboardRepositoryMock;
        private Mock<IPasswordHasher<Player>> _passwordHasherMock;
        private Mock<IJwtProvider> _jwtProviderMock;

        [SetUp]
        public void BeforeEach()
        {
            _playerRepositoryMock = new Mock<IPlayerRepository>();
            _scoreboardRepositoryMock = new Mock<IScoreboardRepository>();
            _passwordHasherMock = new Mock<IPasswordHasher<Player>>();
            _jwtProviderMock = new Mock<IJwtProvider>();
        }

        [Test]
        public async Task SignUpAsync_ShouldCreateANewAccount_ShouldInvokeAddAsyncOnPlayerAndScoreboardRepository()
        {
            // ------------==== Arrange ====------------

            var accountService = new AccountService(_playerRepositoryMock.Object,
                                                    _scoreboardRepositoryMock.Object,
                                                    _passwordHasherMock.Object,
                                                    _jwtProviderMock.Object);                                      

            // ------------====   Act   ====------------
            
            await accountService.SignUpAsync(Guid.NewGuid(), "player@email.com", "Secret123!", "Player", "Player", "Player");

            // ------------====  Assert ====------------
            _playerRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Player>()), Times.Once);
            _scoreboardRepositoryMock.Verify(x => x.AddAsync(It.IsAny<PlayerScore>()), Times.Once);
        }
    }
}
