/*AliceVinnik*/

using System.Collections.Generic;
using UnityEngine;

public class CustomPlayerPrefs : PlayerPrefs
{
    private static string idArrayLenght = "_customPP_arrays_length_";
    private static string idArrayObjectID = "_customPP_arrays_objectID_";

    #region Boolean

    public static void SetBool(string key, bool value)
    {
        SetInt(key, value == true ? 1 : 0);
    }

    public static bool GetBool(string key)
    {
        return GetInt(key) == 1 ? true : false;
    }

    public static bool GetBool(string key, bool defaultValue)
    {
        return GetInt(key, defaultValue ? 1 : 0) == 1 ? true : false;
    }

    public static void SetBoolArray(string key, bool[] values)
    {
        SetInt(key + idArrayLenght, values.Length);
        for (var index = 0; index < values.Length; index++)
            SetInt(key + idArrayObjectID + index, values[index] == true ? 1 : 0);
    }

    public static bool[] GetBoolArray(string key)
    {
        var length = GetInt(key + idArrayLenght, 0);
        var values = new bool[length];
        for (var index = 0; index < length; index++)
            values[index] = GetInt(key + idArrayObjectID + index) == 1 ? true : false;
        return values;
    }

    #endregion

    #region Float

    public static void SetFloatArray(string key, float[] values)
    {
        SetInt(key + idArrayLenght, values.Length);
        for (var index = 0; index < values.Length; index++)
            SetFloat(key + idArrayObjectID + index, values[index]);
    }

    public static void SetFloatList(string key, List<float> values)
    {
        SetInt(key + idArrayLenght, values.Count);
        for (var index = 0; index < values.Count; index++)
            SetFloat(key + idArrayObjectID + index, values[index]);
    }

    public static float[] GetFloatArray(string key)
    {
        var length = GetInt(key + idArrayLenght, 0);
        var values = new float[length];
        for (var index = 0; index < length; index++)
            values[index] = GetFloat(key + idArrayObjectID + index);
        return values;
    }

    public static List<float> GetFloatList(string key)
    {
        var length = GetInt(key + idArrayLenght, 0);
        var values = new List<float>(length);
        for (var index = 0; index < length; index++)
            values.Add(GetFloat(key + idArrayObjectID + index));
        return values;
    }

    #endregion

    #region Int

    public static void SetIntArray(string key, int[] values)
    {
        SetInt(key + idArrayLenght, values.Length);
        for (var index = 0; index < values.Length; index++)
            SetInt(key + idArrayObjectID + index, values[index]);
    }

    public static void SetIntList(string key, List<int> values)
    {
        SetInt(key + idArrayLenght, values.Count);
        for (var index = 0; index < values.Count; index++)
            SetInt(key + idArrayObjectID + index, values[index]);
    }

    public static int[] GetIntArray(string key)
    {
        var length = GetInt(key + idArrayLenght, 0);
        var values = new int[length];
        for (var index = 0; index < length; index++)
            values[index] = GetInt(key + idArrayObjectID + index);
        return values;
    }

    public static List<int> GetIntList(string key)
    {
        var length = GetInt(key + idArrayLenght, 0);
        var values = new List<int>(length);
        for (var index = 0; index < length; index++)
            values.Add(GetInt(key + idArrayObjectID + index));
        return values;
    }

    #endregion

    #region String

    public static void SetStringArray(string key, string[] values)
    {
        SetInt(key + idArrayLenght, values.Length);
        for (var index = 0; index < values.Length; index++)
            SetString(key + idArrayObjectID + index, values[index]);
    }

    public static void SetStringList(string key, List<string> values)
    {
        SetInt(key + idArrayLenght, values.Count);
        for (var index = 0; index < values.Count; index++)
            SetString(key + idArrayObjectID + index, values[index]);
    }

    public static string[] GetStringArray(string key)
    {
        var length = GetInt(key + idArrayLenght, 0);
        var values = new string[length];
        for (var index = 0; index < length; index++)
            values[index] = GetString(key + idArrayObjectID + index);
        return values;
    }

    public static List<string> GetStringList(string key)
    {
        var length = GetInt(key + idArrayLenght, 0);
        var values = new List<string>(length);
        for (var index = 0; index < length; index++)
            values.Add(GetString(key + idArrayObjectID + index));
        return values;
    }

    #endregion
}