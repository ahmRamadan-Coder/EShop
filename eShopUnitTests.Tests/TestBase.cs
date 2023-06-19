namespace eShopUnitTests.Tests
{
    using static Testing;
    public class TestBase
    {
        [SetUp]
        public static async Task SetUp()
        {
            await ResetState();
        }
    }
}
