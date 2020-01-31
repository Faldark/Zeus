using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Zeux.Test.Models;
using Zeux.Test.Repositories;
using Zeux.Test.Server.Controllers;
using Zeux.Test.Services;

namespace Zeux.Test.Server.UnitTests.Controllers
{
    public class AssetControllerTests
    {
        [Fact]
        public async void Get_ReturnsAllAssets_WhenTypeIsEmpty()
        {
            var context = new FakeContext();

            // Arrange
            var mockService = new Mock<IAssetService>();
            mockService.Setup(service => service.Get())
                .ReturnsAsync(context.Assets);

            var controller = new AssetController(mockService.Object);

            // Act
            var res = await controller.Get(string.Empty);

            // Assert
            Assert.Equal(context.Assets.Count(), res.Count());
            Assert.IsAssignableFrom<IEnumerable<Asset>>(res);
        }

        [Fact]
        public async void Get_ReturnsAllAssets_WhenTypeIsNoneEmpty()
        {
            var context = new FakeContext();

            // Arrange
            var type = "Savings";
            var mockService = new Mock<IAssetService>();
            mockService.Setup(service => service.Get(type))
                .ReturnsAsync(context.Assets.Where(a => a.Type.Name == type));

            var controller = new AssetController(mockService.Object);

            // Act
            var res = await controller.Get(type);

            // Assert
            Assert.Equal(context.Assets.Count(a => a.Type.Name == type), res.Count());
            Assert.IsAssignableFrom<IEnumerable<Asset>>(res);
        }

        [Fact]
        public async void Get_ReturnsAllAssets_WhenTypeIsNoneExists()
        {
            var context = new FakeContext();

            // Arrange
            var type = "Non exists type";
            var mockService = new Mock<IAssetService>();
            mockService.Setup(service => service.Get(type))
                .ReturnsAsync(context.Assets.Where(a => a.Type.Name == type));

            var controller = new AssetController(mockService.Object);

            // Act
            var res = await controller.Get(type);

            // Assert
            Assert.Empty(res);
            Assert.IsAssignableFrom<IEnumerable<Asset>>(res);
        }

        [Fact]
        public async void Get_ReturnsAllAssetsTypes()
        {
            var context = new FakeContext();

            // Arrange
            var mockService = new Mock<IAssetService>();
            mockService.Setup(service => service.GetTypes())
                .ReturnsAsync(context.AssetTypes);

            var controller = new AssetController(mockService.Object);

            // Act
            var res = await controller.GetTypes();

            // Assert
            Assert.Equal(context.AssetTypes.Count(), res.Count());
            Assert.IsAssignableFrom<IEnumerable<AssetType>>(res);
        }
    }
}
