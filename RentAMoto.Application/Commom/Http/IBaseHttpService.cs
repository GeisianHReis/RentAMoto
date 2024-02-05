namespace RentAMoto.Application.Commom.Http
{
    public interface IBaseHttpService<T> where T : class
    {
        Task<T> SendAsync(string url);
        Task<T> PatchAsync(string url, object body);
        Task<T> PostJsonAsync<TValue>(string url, TValue value);
    }
}