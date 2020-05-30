﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entities
{
    /// <summary>
    /// Model
    /// </summary>
    public sealed class AreaEntity
    {
        public AreaEntity(int areaId, string areaName)
        {
            AreaId = areaId;
            AreaName = areaName;
        }

        public int AreaId { get;}
        public string AreaName { get;}
    }
}
