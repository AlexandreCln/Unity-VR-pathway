using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [SerializeField] GameObject _hourNeedle;
    [SerializeField] GameObject _minuteNeedle;
    [SerializeField] GameObject _secondNeedle;
    [SerializeField] float _xRotationFromUpOffset = 90f;
    [SerializeField] float _needleStartRotationY = 0f;
    [SerializeField] float _needleStartRotationZ = -90f;
    float _secondTimer = 0f;

    // Each second corresponds to 360/60 ​= 6 degrees
    readonly float clockMultiplicator = 6f;

    void Update()
    {
        _secondTimer += Time.deltaTime;
        if (_secondTimer >= 1f) {
            _secondTimer = 0f;

            DateTime currentTime = DateTime.Now;

            int seconds = currentTime.Second;
            var secondProportionalAngle = seconds * clockMultiplicator;
            var secondAngle = Mathf.Repeat(secondProportionalAngle + _xRotationFromUpOffset, 360);
            _secondNeedle.transform.rotation = Quaternion.Euler(secondAngle, 0f, _needleStartRotationZ);

            int minutes = currentTime.Minute;
            var minuteProportionalAngle = minutes * clockMultiplicator;
            var minuteAngle = Mathf.Repeat(minuteProportionalAngle + _xRotationFromUpOffset, 360);
            _minuteNeedle.transform.rotation = Quaternion.Euler(minuteAngle, 0f, _needleStartRotationZ);

            int hours = currentTime.Hour;
            var hourProportionalAngle = hours * clockMultiplicator;
            var hourAngle = Mathf.Repeat(hourProportionalAngle + _xRotationFromUpOffset, 360);
            _hourNeedle.transform.rotation = Quaternion.Euler(hourAngle, 0f, _needleStartRotationZ);
        }
    }
}
