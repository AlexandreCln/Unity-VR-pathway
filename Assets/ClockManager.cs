using System;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    #region Needle progress
    [SerializeField] GameObject _hourNeedle;
    [SerializeField] GameObject _minuteNeedle;
    [SerializeField] GameObject _secondNeedle;

    float _secondTimer = 0f;
    float _minuteTimer = 0f;
    float _hourTimer = 0f;

    readonly float _needleStartRotationY = 0f;
    readonly float _xRotationFromUpOffset = 90f;
    readonly float _needleStartRotationZ = -90f;
    readonly float secondsAndMinutesMultiplier = 6f; // Represents the angle multiplier for seconds and minutes (360/60 ​= 6 degrees)
    readonly float hourMultiplier = 30f; // Represents the angle multiplier for hours (360/12 ​= 30 degrees)
    #endregion

    void Awake()
    {
        UpdateNeedle(_secondNeedle, DateTime.Now.Second, secondsAndMinutesMultiplier);
        UpdateNeedle(_minuteNeedle, DateTime.Now.Minute, secondsAndMinutesMultiplier);
        UpdateNeedle(_hourNeedle, DateTime.Now.Hour, hourMultiplier);
    }

    void Update()
    {
        _ProgressNeedles();
    }

    void _ProgressNeedles()
    {
        _secondTimer += Time.deltaTime;
        _minuteTimer += Time.deltaTime;
        _hourTimer += Time.deltaTime;

        if (_secondTimer >= 1f)
        {
            _secondTimer = 0f;
            UpdateNeedle(_secondNeedle, DateTime.Now.Second, secondsAndMinutesMultiplier);
        }
        if (_minuteTimer >= 60f)
        {
            _minuteTimer = 0f;
            UpdateNeedle(_minuteNeedle, DateTime.Now.Minute, secondsAndMinutesMultiplier);
        }
        if (_hourTimer >= 3600f)
        {
            _hourTimer = 0f;
            UpdateNeedle(_hourNeedle, DateTime.Now.Hour, hourMultiplier);
        }
    }

    void UpdateNeedle(GameObject needle, int timeComponent, float multiplier)
    {
        float proportionalAngle = timeComponent * multiplier;
        float angle = Mathf.Repeat(proportionalAngle + _xRotationFromUpOffset, 360);
        needle.transform.localRotation = Quaternion.Euler(angle, _needleStartRotationY, _needleStartRotationZ);
    }
}
