using DDD.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{

    public sealed class Temparature : ValueObject<Temparature>
    {

        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        public Temparature(float value)
        {
            Value = value;
        }

        public float Value { get;}
        public string DisplayValue => Value.RoundString(DecimalPoint) + UnitName;
        public string DisplayValueWithUnit => Value.RoundString(DecimalPoint) + " " + UnitName;

        protected override bool EqualsCore(Temparature other)
        {
            return other.Value == this.Value;
        }

    }
}
