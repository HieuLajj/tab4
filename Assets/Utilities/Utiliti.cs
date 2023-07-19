using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utiliti
{
   public static string SetCoinsText(int value)
    {
        if (value >= 1000000000)
        {
            return "Max";
        }
        else if (value >= 1000000)
        {
            return string.Format("{0}.{1}M", (value / 1000000), GetFirstDigitFromNumber(value % 1000000));
        }
        else if (value >= 1000)
        {
            return string.Format("{0}.{1}K", (value / 1000), GetFirstDigitFromNumber(value % 1000));
        }
        else
        {
            return value.ToString();
        }
    }
    static int GetFirstDigitFromNumber(int value)
    {
        return int.Parse(value.ToString()[0].ToString());
    }
}
