/*AliceVinnik*/

using UnityEngine;

static class RandomBool
{
    public static bool Get() => Random.Range(0, 2) == 0;
}

static class RandomInt
{
    public static int Get(int from, int to) => Random.Range(from, to + 1);
    public static int Get(int value) => Get(0, value + 1);
}

static class RandomFloat
{
    public static float Get(float from, float to) => Random.Range(from, to);
    public static float Get(float value) => Get(0, value);
}