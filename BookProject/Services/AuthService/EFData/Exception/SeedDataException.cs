namespace EFData.Exception
{
    public class SeedDataException : System.Exception
    {
        public const string DefaultMessage = "Don't append the seed data";
        public SeedDataException() : base(DefaultMessage) { }
        public SeedDataException(string message) : base(message) { }
    }
}
