namespace ToursApi.Services
{
    public class ClsGenre : IGenre
    {
        private readonly ApplecationDbContext _Context;
        public ClsGenre(ApplecationDbContext context)
        {
            _Context = context;
        }

        public async Task<bool> isAllowed(int id) => await _Context.Genras.AnyAsync(c => c.Id == id);
        public async Task<IEnumerable<Genra>> GetAll() => await _Context.Genras.ToListAsync();
        public async Task<Genra> GetById(byte id) => await _Context.Genras.FindAsync(id);
        public async Task<Genra> Create(Genra genre)
        {
            await _Context.AddAsync(genre);
            _Context.SaveChanges();
            return genre;
        }
        public async Task<Genra> Update(Genra genra)
        {
            _Context.Update(genra);
            await _Context.SaveChangesAsync();
            return genra;
        }
        public async Task<Genra> Delete(Genra genra)
        {
            _Context.Remove(genra);
            await _Context.SaveChangesAsync();
            return genra; 
        }

    }
}
