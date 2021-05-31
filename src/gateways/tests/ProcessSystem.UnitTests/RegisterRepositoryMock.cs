using System;
using System.Threading;
using Common.DB;
using Moq;
using ProcessSystem.Contracts;
using ProcessSystem.DB;

namespace ProcessSystem.UnitTests
{
    public class RegisterRepositoryMock
    {
        private readonly Mock<IRegisterRepository> _registerRepositoryMock = new Mock<IRegisterRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

        #region SuccessSetups
        public void SetupAddSuccess()
        {
            _registerRepositoryMock.Setup(sw => sw.AddAsync(It.IsAny<Register>()))
                .ReturnsAsync((Register req) => req);
        }

        public void SetupDeleteSuccess(Register swr)
        {
            _registerRepositoryMock.Setup(sw => sw.DeleteAsync(It.Is<string>(s => s == swr.Token)))
                .ReturnsAsync(swr);
        }

        public void SetupFindByTokenSuccess(Register swr)
        {
            _registerRepositoryMock.Setup(sw => sw.FindByTokenAsync(It.Is<string>(s => s == swr.Token)))
                .ReturnsAsync(swr);
        }

        public void SetupFindByChannelAndUrlSuccess()
        {
            _registerRepositoryMock.Setup(sw => sw.FindByChannelAndUrlAsync(It.IsAny<Register>()))
                .ReturnsAsync((Register req) => req);
        }

        public void SetupUnitOfWorkSuccess()
        {
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            _unitOfWorkMock.Setup(u => u.SaveEntitiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _registerRepositoryMock.SetupGet(sw => sw.UnitOfWork).Returns(_unitOfWorkMock.Object);
        }

        #endregion

        #region FailureSetups
        public void SetupAddFailure()
        {
            _registerRepositoryMock.Setup(sw => sw.AddAsync(It.IsAny<Register>()))
                .ReturnsAsync((Register)null);
        }

        public void SetupDeleteFailure()
        {
            _registerRepositoryMock.Setup(sw => sw.DeleteAsync(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentNullException(nameof(Register), "По токену не найдена запись"));
        }

        public void SetupFindByTokenFailure()
        {
            _registerRepositoryMock.Setup(sw => sw.FindByTokenAsync(It.IsAny<string>()))
                .ReturnsAsync((Register)null);
        }

        public void SetupFindByChannelAndUrlFailure()
        {
            _registerRepositoryMock.Setup(sw => sw.FindByChannelAndUrlAsync(It.IsAny<Register>()))
                .ReturnsAsync((Register)null);
        }

        public void SetupUnitOfWorkFailure()
        {
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);
            _unitOfWorkMock.Setup(u => u.SaveEntitiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(false);
            _registerRepositoryMock.SetupGet(sw => sw.UnitOfWork).Returns(_unitOfWorkMock.Object);
        }

        #endregion
        
        /// <summary>
        /// Возвращает сам заглушенный объект 
        /// </summary>
        /// <returns></returns>
        public IRegisterRepository GetMockObject()
        {
            return _registerRepositoryMock.Object;
        }
    }
}