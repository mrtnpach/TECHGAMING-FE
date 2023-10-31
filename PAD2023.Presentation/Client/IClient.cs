namespace PAD2023.Presentation.Client
{
    public interface IClient : IDisposable
    {
        Task<T> GetAsync<T>(string uri);
        // Otras operaciones sin usar
        // List<T> GetCollection<T>(string uri);
        // ...
    }
}
