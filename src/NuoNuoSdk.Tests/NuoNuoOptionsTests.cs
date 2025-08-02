using Xunit;

namespace NuoNuoSdk.Tests;

public class NuoNuoOptionsTests
{
    [Fact]
    public void NuoNuoOptions_DefaultValues_ShouldBeCorrect()
    {
        // Arrange & Act
        var options = new NuoNuoOptions();

        // Assert
        Assert.Null(options.AppKey);
        Assert.Null(options.AppSecret);
    }

    [Fact]
    public void NuoNuoOptions_SetProperties_ShouldRetainValues()
    {
        // Arrange
        var options = new NuoNuoOptions();
        var expectedAppKey = "test_app_key";
        var expectedAppSecret = "test_app_secret";

        // Act
        options.AppKey = expectedAppKey;
        options.AppSecret = expectedAppSecret;

        // Assert
        Assert.Equal(expectedAppKey, options.AppKey);
        Assert.Equal(expectedAppSecret, options.AppSecret);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void NuoNuoOptions_WithWhitespaceValues_ShouldAcceptValues(string whitespaceValue)
    {
        // Arrange
        var options = new NuoNuoOptions();

        // Act
        options.AppKey = whitespaceValue;
        options.AppSecret = whitespaceValue;

        // Assert
        Assert.Equal(whitespaceValue, options.AppKey);
        Assert.Equal(whitespaceValue, options.AppSecret);
    }

    [Fact]
    public void NuoNuoOptions_WithNullValues_ShouldAcceptNull()
    {
        // Arrange
        var options = new NuoNuoOptions()
        {
            AppKey = "test",
            AppSecret = "test"
        };

        // Act
        options.AppKey = null;
        options.AppSecret = null;

        // Assert
        Assert.Null(options.AppKey);
        Assert.Null(options.AppSecret);
    }

    [Fact]
    public void NuoNuoOptions_WithLongValues_ShouldAcceptLongStrings()
    {
        // Arrange
        var options = new NuoNuoOptions();
        var longString = new string('a', 1000);

        // Act
        options.AppKey = longString;
        options.AppSecret = longString;

        // Assert
        Assert.Equal(longString, options.AppKey);
        Assert.Equal(longString, options.AppSecret);
    }

    [Theory]
    [InlineData("test_key_1")]
    [InlineData("test_key_2")]
    [InlineData("another_app_key")]
    public void NuoNuoOptions_WithDifferentAppKeys_ShouldAcceptValidKeys(string appKey)
    {
        // Arrange
        var options = new NuoNuoOptions();

        // Act
        options.AppKey = appKey;

        // Assert
        Assert.Equal(appKey, options.AppKey);
    }

    [Fact]
    public void NuoNuoOptions_WithSpecialCharacters_ShouldAcceptSpecialChars()
    {
        // Arrange
        var options = new NuoNuoOptions();
        var specialChars = "!@#$%^&*()_+-=[]{}|;':,.<>?";

        // Act
        options.AppKey = specialChars;
        options.AppSecret = specialChars;

        // Assert
        Assert.Equal(specialChars, options.AppKey);
        Assert.Equal(specialChars, options.AppSecret);
    }

    [Fact]
    public void NuoNuoOptions_PropertyIndependence_ShouldNotAffectEachOther()
    {
        // Arrange
        var options = new NuoNuoOptions();

        // Act
        options.AppKey = "key1";
        options.AppSecret = "secret1";

        // 修改一个属性
        options.AppKey = "key2";

        // Assert
        Assert.Equal("key2", options.AppKey);
        Assert.Equal("secret1", options.AppSecret); // 其他属性不应受影响
    }
}