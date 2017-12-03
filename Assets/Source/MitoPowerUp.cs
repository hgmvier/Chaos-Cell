using UnityEngine;


public class MitoPowerUp : MonoBehaviour
{ 
    private float _powerModifier = 40f;
    private float _powerDuration = 10f;
    private PowerUpSpawner _spawner;
    private PlayerMov _player;
    private SFXManager _sfx;


    private void Awake()
    {
        _player = FindObjectOfType<PlayerMov>();
        _spawner = FindObjectOfType<PowerUpSpawner>();
        _sfx = FindObjectOfType<SFXManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.Speed = _powerModifier;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        _spawner.SpawnCount--;
        _spawner.DurationTimer = _powerDuration;
        _spawner.PowerUpInEffect = true;
        _sfx.PlayPowerUpClip();
    }

}
