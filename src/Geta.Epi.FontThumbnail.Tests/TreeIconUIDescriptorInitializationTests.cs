using System;
using System.Collections.Generic;
using System.Configuration;
using EPiServer.Shell;
using Geta.Epi.FontThumbnail.Initialization;
using Geta.Epi.FontThumbnail.Tests.Models;
using Xunit;

namespace Geta.Epi.FontThumbnail.Tests
{
    public class TreeIconUIDescriptorInitializationTests : IDisposable
    {
        [Fact]
        public void Enabled_PageWithoutThumbnailIcon_NotInUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "true";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithoutThumbnailIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Null(descriptor.IconClass);
            Assert.False(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Disabled_PageWithoutThumbnailIcon_NotInUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "false";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithoutThumbnailIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Null(descriptor.IconClass);
            Assert.False(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Enabled_PageWithOnlyThumbnailIcon_InUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "true";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithOnlyThumbnailIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Equal("fas fa-road fa-fw", descriptor.IconClass);
            Assert.True(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Disabled_PageWithOnlyThumbnailIcon_NotInUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "false";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithOnlyThumbnailIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Null(descriptor.IconClass);
            Assert.False(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Enabled_PageWithThumbnailIconAndTreeIcon_InUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "true";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithThumbnailIconAndTreeIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Equal("fas fa-anchor fa-fw", descriptor.IconClass);
            Assert.True(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Disabled_PageWithThumbnailIconAndTreeIcon_NotInUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "false";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithThumbnailIconAndTreeIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Null(descriptor.IconClass);
            Assert.False(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Enabled_PageWithThumbnailIconAndTreeIconOnIgnore_NotInUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "true";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithThumbnailIconAndTreeIconOnIgnore));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Null(descriptor.IconClass);
            Assert.False(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Disabled_PageWithThumbnailIconAndTreeIconOnIgnore_NotInUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "false";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithThumbnailIconAndTreeIconOnIgnore));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Null(descriptor.IconClass);
            Assert.False(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Enabled_PageWithOnlyTreeIconWithoutIcon_NotInUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "true";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithOnlyTreeIconWithoutIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Null(descriptor.IconClass);
            Assert.False(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Enabled_PageWithOnlyTreeIcon_InUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "true";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithOnlyTreeIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Equal("fas fa-road fa-fw", descriptor.IconClass);
            Assert.True(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Enabled_PageWithInheritedThumbnailIcon_InUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "true";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithInheritedThumbnailIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Equal("fas fa-road fa-fw", descriptor.IconClass);
            Assert.True(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        [Fact]
        public void Enabled_PageWithThumbnailIconAndDifferentTreeIcon_InUse()
        {
            // Arrange
            ConfigurationManager.AppSettings[Constants.EnableTreeIcons] = "true";
            var initializableModule = new TreeIconUIDescriptorInitialization();
            var descriptor = new UIDescriptor(typeof(PageWithThumbnailIconAndDifferentTreeIcon));
            var uIDescriptors = new List<UIDescriptor>
            {
                descriptor
            };

            // Act
            initializableModule.EnrichDescriptorsWithIconClass(uIDescriptors);

            // Assert
            Assert.Equal("far fa-clock fa-fw", descriptor.IconClass);
            Assert.True(TreeIconUIDescriptorInitialization.EnabledAndInUse);
        }

        public void Dispose()
        {
            TreeIconUIDescriptorInitialization.EnabledAndInUse = false;
        }
    }
}
