using Bogus;
using Core.Domain;
using Microsoft.AspNetCore.JsonPatch;

namespace Core.Intrastructure
{
    public class FakeEntityRepository<TKey, TEntity> : IEntityRepository<TKey, TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : struct
    {
        protected readonly IDictionary<TKey, TEntity> _entities;

        public FakeEntityRepository(Faker<TEntity> faker)
        {
            _entities = faker.Generate(100).ToDictionary(p => p.Id);
        }

        public Task AddAsync(TEntity entity)
        {
            _entities.Add(entity.Id, entity);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<TEntity>> GetAsync()
        {
            return Task.FromResult(_entities.Values.AsEnumerable());
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            if (_entities.TryGetValue(id, out var entity))
            {
                return Task.FromResult(entity);
            }
            else
            {
                return Task.FromResult<TEntity>(null);
            }
        }

        public async Task PatchAsync(TKey id, JsonPatchDocument<TEntity> patchEntity)
        {
            TEntity entity = await GetAsync(id);

            patchEntity.ApplyTo(entity);

        }

        public Task RemoveAsync(TKey id)
        {
            _entities.Remove(id);

            return Task.CompletedTask;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await RemoveAsync(entity.Id);
            await AddAsync(entity);
        }
    }
}