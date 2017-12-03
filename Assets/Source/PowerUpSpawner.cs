using UnityEngine;


public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;

    //time between power up spawns
    private float _spawnInterval = 20f;

    //countdown to next spawn
    private float _countTimer = 2f;

    //Max amount of powerUps in game at a time
    private int _maxSpawnCount = 1;

    //current count of powerUps in game
    private int _spawnCount;

    //Currently under effect of power up
    private bool _inEffect = false;

    public bool PowerUpInEffect
    {
        get { return _inEffect; }
        set { _inEffect = value; }
    }

    public int SpawnCount
    {
        get { return _spawnCount; }
        set { _spawnCount = value; }
    }

    private float _durationTimer = 10f;

    public float DurationTimer
    {
        get { return _durationTimer; }
        set { _durationTimer = value; }
    }

    private PlayerMov _player;


    private void Awake()
    {
        _player = FindObjectOfType<PlayerMov>();
    }

    //Count down the duration
    private void DurationDown()
    {
        if (_inEffect)
        {
            if (_durationTimer < 1f)
            {
                _player.Speed = 20f;
                _inEffect = false;
                Debug.Log("Duration is over");
            }

            Debug.Log(_durationTimer);
            _durationTimer -= Time.deltaTime;
        }
    }

    private void Update()
    {
        if (_countTimer <= 0f)
        {
            if (_spawnCount >= _maxSpawnCount)
                return;


            SpawnPowerUp();
            _spawnCount++;
            _countTimer = _spawnInterval;
        }

        _countTimer -= Time.deltaTime;

        DurationDown();
    }

    private void SpawnPowerUp()
    {
        float x = Random.Range(-50, 50);
        float y = Random.Range(-20, 20);

        Instantiate(powerUpPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
