using DDD.Domain.Entities;
using System.Collections.Generic;


namespace DDD.Domain.Repository
{
    public interface IAreasRepository
    {
        IReadOnlyList<AreaEntity> GetData();
    }
}
