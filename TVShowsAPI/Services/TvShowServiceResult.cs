namespace TVShowsAPI.Services
{
    /**
     *  Resultados de las operaciones CRUD sobre los TV shows.
     *  <typeparam name="T">Tipo de datos devueltos (generalmente un DTO o string para mensajes)</typeparam> 
     */
    public class TvShowServiceResult<T>
    {
        public T Data { get; set; }
        public string Message { get; set; } 
        public bool Success => string.IsNullOrEmpty(Message);

        public TvShowServiceResult(T data, string message = null)
        {
            Data = data;
            Message = message;
        }

        public TvShowServiceResult(string message)
        {
            Message = message;
        }

    }
}
