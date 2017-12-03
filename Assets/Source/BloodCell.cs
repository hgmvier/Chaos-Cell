using UnityEngine;


public class BloodCell : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rb2d;
    private float _speed;
    private Vector2 _travelVec;
    private float _minSpeed = 14f;
    private float _maxSpeed = 21f;
    private BloodCellSpawner _spawner;
    private GameTracker _tracker;
    private SFXManager _sfx;



    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _spawner = FindObjectOfType<BloodCellSpawner>();
        _tracker = FindObjectOfType<GameTracker>();
        _sfx = FindObjectOfType<SFXManager>();
        GenerateTravelVector();
    }

    private Vector2 GenerateDirection()
    {
        //Generate X
        float x = Random.Range(-1f, 1f);

        //Generate Y
        float y = Random.Range(-1f, 1f);

        return new Vector2(x, y);
    }

    private float GenerateSpeed()
    {
        //Generate a random speed for blood cell
        float spd = Random.Range(_minSpeed, _maxSpeed);

        return spd;
    }

    private void GenerateTravelVector()
    {
        _speed = GenerateSpeed();
        _direction = GenerateDirection();
        _travelVec = new Vector2(_direction.x * _speed, _direction.y * _speed);
    }

    private void TravelInDirection()
    {
        _rb2d.velocity = _travelVec;
    }

    private void Update()
    {
        TravelInDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            if (collision.gameObject.CompareTag("Boundary"))
            {
                //Regenerate travel vector
                GenerateTravelVector();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            //Keep regenrating travel vector until
            //cell is not stuck
            GenerateTravelVector();
        }

        if (collision.gameObject.CompareTag("BloodCell"))
        {
            GenerateTravelVector();
        }
    }

    private void OnDestroy()
    {
        _spawner.SpawnCount--;
        _tracker.BloodCellsKilled++;
        _sfx.PlayBloodCellClip();
    }
}
