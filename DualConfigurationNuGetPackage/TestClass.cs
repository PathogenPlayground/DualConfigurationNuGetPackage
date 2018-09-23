namespace DualConfigurationNuGetPackage
{
    public static class TestClass
    {
        public static string GetConfiguration()
        {
#if DEBUG
            return "Debug";
#else
            return "Release";
#endif
        }
    }
}
