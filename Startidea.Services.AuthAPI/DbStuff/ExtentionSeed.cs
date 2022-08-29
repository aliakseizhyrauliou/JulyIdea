using JulyIdea.Services.AuthAPI.Models;
using JulyIdea.Services.AuthAPI.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace JulyIdea.Services.AuthAPI.DbStuff
{
    public static class ExtentionSeed
    {

        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {

            }

            return host;
        }
        private async static void SeedUsers(IServiceScope scope)
        {
            var userRepository = scope.ServiceProvider.GetService<IUserRepository>();

            if (!await userRepository.Any())
            {
                return;
            }

        }
    }
}
