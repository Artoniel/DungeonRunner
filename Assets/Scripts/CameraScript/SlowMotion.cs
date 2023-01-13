using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField] float _slowMotionTimeScale;
    float _startFixedDeltaTime;
    float _startTimeScale;
    // Start is called before the first frame update
    void Start()
    {
        _startTimeScale= Time.timeScale;
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartSlowMotion();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopSlowMotion();
        }
    }
    private void StartSlowMotion()
    {
        Time.timeScale = _slowMotionTimeScale;
        Time.fixedDeltaTime = _startFixedDeltaTime * _slowMotionTimeScale;
    }
    private void StopSlowMotion()
    {
        Time.timeScale = _startTimeScale;
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
