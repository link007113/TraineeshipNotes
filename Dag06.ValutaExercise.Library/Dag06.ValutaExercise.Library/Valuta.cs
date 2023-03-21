namespace Dag06.ValutaExercise.Library
{
    public enum Valuta
    {
        Gulden,
        Euro,
        Florijn,
        Dukaat,
    }
    public static class ValutaExtensions
    {
        public static string Code(this Valuta valuta) => valuta switch
        {
            Valuta.Dukaat => "HD",
            Valuta.Gulden => "Hfl",
            Valuta.Florijn => "fl",
            Valuta.Euro => "EUR"
        };

        public static Valuta ToValuta(this string str) => str switch
        {
            "HD" => Valuta.Dukaat,
            "Hfl" => Valuta.Gulden,
            "fl" => Valuta.Florijn,
            "EUR" => Valuta.Euro,
            _ => throw new InvalidValutaException("This Valuta doesn't exists")
        };        
    }
}