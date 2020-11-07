using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
       Task<T> IsertAsync(T item);
       Task<T> UpdateAsync (T item);
       Task<bool> DeleteAsync (Guid id);
       Task<T> SelectAsync (Guid id);
       Task<bool> ExistAsync (Guid item);
       Task<IEnumerable<T>> SelectAsync();
    }
}