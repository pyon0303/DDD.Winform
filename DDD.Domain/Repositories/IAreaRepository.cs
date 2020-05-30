using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories
{
    /// <summary>
    /// リストの各項目にもModelとViewModelを作成する必要がある。
    /// </summary>
    public interface IAreaRepository
    {
        IReadOnlyList<AreaEntity> GetData();
    }
}
