using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag06.ValutaExercise.Library
{
    public struct ValutaStruct
    {
        public ValutaEnum Type { get; set; }
        public decimal Amount { get; set; }

        public ValutaStruct(ValutaEnum valutaEnum, decimal amount)
        {
            Type = valutaEnum;
            Amount = amount;
        }

        public ValutaStruct ConvertTo(ValutaEnum valutaEnum)
        {
            switch (Type)
            {
                case ValutaEnum.Gulden:
                    switch (valutaEnum)
                    {
                        case ValutaEnum.Gulden:
                            return new(valutaEnum, Amount);
                        case ValutaEnum.Euro:
                            return new(valutaEnum, Amount * 0.45378M);
                        case ValutaEnum.Florijn:
                            return new(valutaEnum, Amount);
                        case ValutaEnum.Dukaat:
                            return new(valutaEnum, Amount * 5.1M);
                        default:
                            break;
                    }
                    break;
                case ValutaEnum.Euro:
                    switch (valutaEnum)
                    {
                        case ValutaEnum.Gulden:
                            return new(valutaEnum, Amount / 2.20371M);
                        case ValutaEnum.Euro:
                            return new(valutaEnum, Amount);
                        case ValutaEnum.Florijn:
                            return new(valutaEnum, Amount / 2.20371M);
                        case ValutaEnum.Dukaat:
                            return new(valutaEnum, (Amount * 5.1M) / 2.20371M);
                        default:
                            break;
                    }
                    break;
                case ValutaEnum.Florijn:
                    switch (valutaEnum)
                    {
                        case ValutaEnum.Gulden:
                            return new(valutaEnum, Amount);
                        case ValutaEnum.Euro:
                            return new(valutaEnum, Amount * 0.45378M);
                        case ValutaEnum.Florijn:
                            return new(valutaEnum, Amount);
                        case ValutaEnum.Dukaat:
                            return new(valutaEnum, Amount * 5.1M);
                        default:
                            break;
                    }
                    break;
                case ValutaEnum.Dukaat:
                    switch (valutaEnum)
                    {
                        case ValutaEnum.Gulden:
                            return new(valutaEnum, (Amount * 5.1M));
                        case ValutaEnum.Euro:
                            return new(valutaEnum, (Amount * 5.1M) * 0.45378M);
                        case ValutaEnum.Florijn:
                            return new(valutaEnum, (Amount * 5.1M));
                        case ValutaEnum.Dukaat:
                            return new(valutaEnum, (Amount * 5.1M) * 5.1M);
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return new(valutaEnum, Amount);
        }



        public override string ToString()
        {
            return $"{Type}: {decimal.Round(Amount, 2, MidpointRounding.AwayFromZero)}";
        }

        public static ValutaStruct operator +(ValutaStruct a, ValutaStruct b)
        {
            decimal amount = a.ConvertTo(b.Type).Amount + b.Amount;
            return new(b.Type, amount);
        }

        public static ValutaStruct operator *(ValutaStruct a, ValutaStruct b)
        {
            decimal amount = a.ConvertTo(b.Type).Amount * b.Amount;
            return new(b.Type, amount);
        }

        #region equality
        public static bool operator ==(ValutaStruct a, ValutaStruct b)
        {
            return a.Amount == b.Amount && a.Type == b.Type;
        }
        public static bool operator !=(ValutaStruct a, ValutaStruct b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            return obj != null &&
                obj.GetType() == typeof(ValutaStruct) &&
                this == (ValutaStruct)obj;
            //  return obj is Time &&
            //  this == (Time)obj;
            //  return (obj is Time that) && this == that;
        }
        public override int GetHashCode()
        {
            return (int)Amount * 356;
        }
        #endregion

        public static explicit operator ValutaStruct(decimal amount)
        {      
            return new ValutaStruct(ValutaEnum.Euro,amount );
        }
        public static explicit operator decimal(ValutaStruct valuta)
        {
            return valuta.ConvertTo(ValutaEnum.Euro).Amount;
        }

    }


}
