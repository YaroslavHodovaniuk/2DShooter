using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private float Duration;
    [SerializeField] private Color _targetColor;

    private SpriteRenderer _target;
    private float _runningTime;
    private Color _startColor;
    void Awake()
    {
        _target = GetComponent<SpriteRenderer>();
        _startColor = _target.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (_runningTime <= Duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / Duration;

            
            _target.color = Color.Lerp(_startColor, _targetColor, normalizeRunningTime);


        }
    }
}
