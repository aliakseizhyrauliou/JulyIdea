using JulyIdea.Services.AuthAPI.Services;
using Xunit;

namespace JulyIdea.AuthAPI.Tests
{
    public class PasswordHashingServiceTests
    {
        const string salt = "66CAF1CF23E8FA3323CFD9379515719376E8C1130B36D74C9CAB875E3A1A55F1";
        const string password = "admin";
        const string hash = "XQ6QLr+clWF+d9DGvcwFCw==";

        [Fact]
        public void GenerateSaltNotNull()
        {
            var hashingService = new PasswordHashingService();
            var salt = hashingService.GenerateSalt();

            Assert.NotNull(salt);
        }

        [Fact]
        public void IsGetHashOfPasswordCorrectOutput() 
        {
            var hashingService = new PasswordHashingService();
            var result = hashingService.GetHashOfPassword(password, StringToByteArray(salt));

            Assert.Equal(hash, result);
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}