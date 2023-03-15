using UnityEngine;
using System;

public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;

    [SerializeField]
    private float _gameDuration = 60f;

    public static Action OnTimerEnded;

    public float Timer => _timer;
    public bool GameRunning => _running;

    private float _timer = 0f;
    private bool _running = true;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        _timer = _gameDuration;
    }

    void Update()
    {
        if (_running)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                _timer = 0f;
                _running = false;
                OnTimerEnded?.Invoke();
            }
        }
    }
}