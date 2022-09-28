namespace ToursApi.Services
{
    public interface IGenre
    {
        Task<bool> isAllowed(int id);
        Task<IEnumerable<Genra>> GetAll();
        Task<Genra> Create(Genra genre);
        Task<Genra> GetById(byte id);
        Task<Genra> Delete(Genra genra);
        Task<Genra> Update(Genra genra);
    }
}
