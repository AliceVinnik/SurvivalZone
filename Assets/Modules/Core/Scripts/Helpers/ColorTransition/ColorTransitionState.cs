/*AliceVinnik*/

using UnityEngine;

public class ColorTransitionState
{
    public Color Current { get; private set; }
    public bool IsComplete => _elapsed >= _duration;
    public float Progress => _duration > 0f ? Mathf.Clamp01(_elapsed / _duration) : 1f;

    private readonly Color _from;
    private readonly Color _to;
    private readonly float _duration;
    private readonly ColorTransitionMode _mode;
    private float _elapsed;

    public ColorTransitionState(Color from, Color to, float duration, ColorTransitionMode mode)
    {
        _from = from;
        _to = to;
        _duration = Mathf.Max(0f, duration);
        _mode = mode;
        Current = from;
    }

    public Color Tick(float deltaTime)
    {
        if (IsComplete) return _to;

        _elapsed += deltaTime;
        var t = Progress;

        Current = _mode switch
        {
            ColorTransitionMode.Linear => ColorTransition.Lerp(_from, _to, t),
            ColorTransitionMode.Smooth => ColorTransition.LerpSmooth(_from, _to, t),
            ColorTransitionMode.HSV => ColorTransition.LerpHSV(_from, _to, t),
            ColorTransitionMode.EaseIn => ColorTransition.LerpEaseIn(_from, _to, t),
            ColorTransitionMode.EaseOut => ColorTransition.LerpEaseOut(_from, _to, t),
            ColorTransitionMode.Spring => ColorTransition.LerpSpring(_from, _to, t),
            _ => ColorTransition.LerpSmooth(_from, _to, t),
        };

        return Current;
    }

    public void Reset() => _elapsed = 0f;
    public void Seek(float normalizedTime) => _elapsed = Mathf.Clamp01(normalizedTime) * _duration;
}