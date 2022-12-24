namespace UrlShortener.Source.Utils;

public static class IdCreator
{
    private const string AlphaNo = "abcdefghijklmnopqrstuvwxyz";
    private const string Alpha = "abcdefghijklmnopqrstuvwxyz-_&@";
    private const int NumOfChar = 6;
    public static string IdGen(bool useSpecial)
    {
        var fin = string.Empty;
        var rand = new Random();

        if (!useSpecial)
        {
            for (var i = 0; i < NumOfChar; i++)
                fin += AlphaNo[rand.Next(0, AlphaNo.Length)];

            return fin;
        }
        
        for (var i = 0; i < NumOfChar; i++)
            fin += Alpha[rand.Next(0, Alpha.Length)];
        
        return fin;
    }
}