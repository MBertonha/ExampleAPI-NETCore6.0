namespace ExempleAPI.Configuracoes
{
    public class DataBaseConfig
    {
        public string ConnectionString { get; set; }

        public DataBaseConfig(IConfiguration configuration)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            ConnectionString = config.GetConnectionString("DefaultConnection");
        }
    }
}
