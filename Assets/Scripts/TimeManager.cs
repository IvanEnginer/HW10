using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _startFixedDeltaTime;

    public float TimeScale = 0.3f;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Time.timeScale = TimeScale;
        }    
        else if(Input.GetMouseButtonUp(1))
        {
            Time.timeScale = 1f;
        }

        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
