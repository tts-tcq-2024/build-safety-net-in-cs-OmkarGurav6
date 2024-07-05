using System;
using System.Text;

public class Soundex
{
    private static readonly Dictionary<char, char> SoundexCodeMap = new Dictionary<char, char>
    {
        { 'B', '1' }, { 'F', '1' }, { 'P', '1' }, { 'V', '1' },
        { 'C', '2' }, { 'G', '2' }, { 'J', '2' }, { 'K', '2' },
        { 'Q', '2' }, { 'S', '2' }, { 'X', '2' }, { 'Z', '2' },
        { 'D', '3' }, { 'T', '3' },
        { 'L', '4' },
        { 'M', '5' }, { 'N', '5' },
        { 'R', '6' }
    };

    private static void SoundexCodeAppend(StringBuilder soundex, char value)
    {
        soundex.Append(char.ToUpper(value));
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return SoundexCodeMap.ContainsKey(c) ? SoundexCodeMap[c] : '0';
    }

    private static bool CheckForValidCode(char code, char prevCode)
    {
        return code != '0' && code != prevCode;
    }
    
    private static void AppendValidCode(StringBuilder soundex, char c, ref char prevCode)
    {
        char code = GetSoundexCode(c);
        if (CheckForValidCode(code, prevCode))
        {
            soundex.Append(code);
            prevCode = code;
        }
    }
    
    private static void GetSoundexCodeProcess(StringBuilder soundex, string name)
    {
        char prevCode = GetSoundexCode(name[0]);

        foreach (var c in name.Skip(1))
        {
            if (soundex.Length >= 4) break;

            AppendValidCode(soundex, c, ref prevCode);
        }
    }

    private static void checkingsoundex(StringBuilder soundex)
    {
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
    }  
    
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        StringBuilder soundex = new StringBuilder();
        SoundexCodeAppend(soundex, name[0]);
        GetSoundexCodeProcess(soundex, name);

        checkingsoundex(soundex);

        return soundex.ToString();
    }
}
