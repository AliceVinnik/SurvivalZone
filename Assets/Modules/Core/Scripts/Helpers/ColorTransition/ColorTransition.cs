/*AliceVinnik*/

using UnityEngine;

public enum ColorTransitionMode
{
    Linear, Smooth, HSV, EaseIn, EaseOut, Spring
}

public static class ColorTransition
{
    public static Color Lerp(Color from, Color to, float t)
    {
        return Color.Lerp(from, to, Mathf.Clamp01(t));
    }

    public static Color LerpSmooth(Color from, Color to, float t)
    {
        var eased = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(t));
        return Color.Lerp(from, to, eased);
    }

    public static Color LerpHSV(Color from, Color to, float t)
    {
        Color.RGBToHSV(from, out float hA, out float sA, out float vA);
        Color.RGBToHSV(to, out float hB, out float sB, out float vB);

        var h = Mathf.LerpAngle(hA * 360f, hB * 360f, Mathf.Clamp01(t)) / 360f;
        var s = Mathf.Lerp(sA, sB, t);
        var v = Mathf.Lerp(vA, vB, t);

        return Color.HSVToRGB(h, s, v);
    }

    public static ColorTransitionState CreateTransition(Color from, Color to, float duration, ColorTransitionMode mode = ColorTransitionMode.Smooth)
    {
        return new ColorTransitionState(from, to, duration, mode);
    }

    public static Color LerpEaseIn(Color from, Color to, float t)
    {
        var eased = Mathf.Pow(Mathf.Clamp01(t), 2f);
        return Color.Lerp(from, to, eased);
    }

    public static Color LerpEaseOut(Color from, Color to, float t)
    {
        var eased = 1f - Mathf.Pow(1f - Mathf.Clamp01(t), 2f);
        return Color.Lerp(from, to, eased);
    }

    public static Color LerpSpring(Color from, Color to, float t)
    {
        t = Mathf.Clamp01(t);
        var eased = Mathf.Sin(t * Mathf.PI * (0.2f + 2.5f * t * t * t))
                    * Mathf.Pow(1f - t, 2.2f) + t;
        return Color.Lerp(from, to, eased);
    }
}