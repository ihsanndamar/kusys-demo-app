namespace kusys_demo_app.Data
{
    public static class Registration
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var seed = new DataSeed(configuration["ConnectionString"]);
            seed.Seeding();

            return services;
        }
    }
}
