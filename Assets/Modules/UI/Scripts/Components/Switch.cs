/*AliceVinnik*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Switch : MonoBehaviour
{
    [Header("Settings")]
    public string value = "";
    public float speed = 400f;

    public UnityEvent valueChanged;

    private const string ANIM_FADE_ON = "SwitchPin_AnimationFadeOn";
    private const string ANIM_FADE_OFF = "SwitchPin_AnimationFadeOff";

    public enum Mode { On, Off }
    public Mode CurrentMode => _mode;
    public bool IsOn => _mode == Mode.On;

    private Mode _mode = Mode.On;
    private bool _isInitialising = true;

    private TextMeshProUGUI _text;
    private RectTransform _pinRect;
    private Image _pinImage;
    private Animation _pinAnimation;

    [Header("Color")]
    public Color colorActive = Color.green;
    public Color colorInactive = Color.red;
    public float colorDuration = 0.3f;
    public ColorTransitionMode colorMode = ColorTransitionMode.Smooth;
    private ColorTransitionState _colorTransition;

    private float _pinOnX;
    private float _targetX;

    private void Start()
    {
        CacheComponents();
        LoadState();
    }

    private void FixedUpdate()
    {
        SlidePin();
        TickColor();
    }

    private void CacheComponents()
    {
        _text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        _pinRect = transform.Find("Button/Pin").GetComponent<RectTransform>();
        _pinAnimation = transform.Find("Button/Pin").GetComponent<Animation>();
        _pinImage = transform.Find("Button/Pin").GetComponent<Image>();
        _pinOnX = _pinRect.localPosition.x;
    }

    private void LoadState()
    {
        var loaded = Save.GetBool(value, defaultValue: true) ? Mode.On : Mode.Off;
        SetMode(loaded, instant: true);
    }

    private void SaveState()
    {
        Save.SetBool(value, _mode == Mode.On);
    }

    public void ChangeState()
    {
        SetMode(_mode == Mode.On ? Mode.Off : Mode.On);
        SoundManager.Instance?.Play("switch");
    }

    public void SetMode(Mode newMode, bool instant = false)
    {
        var stateChanged = _mode != newMode || _isInitialising;
        if (!stateChanged) return;

        _mode = newMode;
        _targetX = newMode == Mode.On ? _pinOnX : -_pinOnX;

        if (instant) SnapPin();
        SaveState();
        StartColorTransition(newMode, instant);

        if (!_isInitialising)
            valueChanged?.Invoke();

        _isInitialising = false;
    }

    private void SlidePin()
    {
        if (_pinRect == null) return;

        var current = _pinRect.localPosition;
        var target = new Vector3(_targetX, 0f, 0f);

        if (current == target) return;

        _pinRect.localPosition = Vector3.MoveTowards(current, target, Time.deltaTime * speed);
    }

    private void SnapPin()
    {
        if (_pinRect == null) return;
        _pinRect.localPosition = new Vector3(_targetX, 0f, 0f);
    }

    #region Color

    private void StartColorTransition(Mode newMode, bool instant)
    {
        if (_pinImage == null) return;

        var from = _pinImage.color;
        var to = newMode == Mode.On ? colorActive : colorInactive;

        if (instant)
        {
            _pinImage.color = to;
            _colorTransition = null;
            return;
        }

        _colorTransition = ColorTransition.CreateTransition(from, to, colorDuration, colorMode);
    }

    private void TickColor()
    {
        if (_colorTransition == null || _pinImage == null) return;

        _pinImage.color = _colorTransition.Tick(Time.deltaTime);

        if (_colorTransition.IsComplete)
            _colorTransition = null;
    }

    #endregion
}