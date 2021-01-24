namespace Kudo
{
    public class App
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "http://localhost:3000";

        public static void Initialize()
        {
            ServiceLocator locator = ServiceLocator.Instance;
            if (UseMockDataStore)
                locator.Register<IDataStore<Game>, MockDataStore>();
            else
                locator.Register<IDataStore<Game>, CloudDataStore>();
        }
    }
}
