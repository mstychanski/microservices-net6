using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public interface IEntityRepository<TKey, TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : struct
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TKey id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task PatchAsync(TKey id, JsonPatchDocument<TEntity> patchEntity);
        Task RemoveAsync(TKey id);
    }
}
