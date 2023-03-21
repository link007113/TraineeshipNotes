namespace Dag06.ValutaExercise.Library
{
    public enum ValutaEnum
    {
        Gulden,
        Euro,
        Florijn,
        Dukaat,
    }
    public static class ValutaExtensions
    {
        public static string Code(this ValutaEnum valuta) => valuta switch
        {
            ValutaEnum.Dukaat => "HD",
            ValutaEnum.Gulden => "Hfl",
            ValutaEnum.Florijn => "fl",
            ValutaEnum.Euro => "EUR"
        };

        public static ValutaEnum ToValuta(this string str) => str switch
        {
            "HD" => ValutaEnum.Dukaat,
            "Hfl" => ValutaEnum.Gulden,
            "fl" => ValutaEnum.Florijn,
            "EUR" => ValutaEnum.Euro,
            _ => throw new InvalidValutaException("This Valuta doesn't exists")
        };        

    }

}