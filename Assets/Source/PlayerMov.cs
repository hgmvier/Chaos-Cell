using UnityEngine;


public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _speed = 20f;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();

        if (_rb2d.velocity.x >= _speed)
        {
            _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);
        }
        else if (_rb2d.velocity.x <= -_speed)
        {
            _rb2d.velocity = new Vector2(-_speed, _rb2d.velocity.y);
        }

        if (_rb2d.velocity.y >= _speed)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, _speed);
        }
        else if (_rb2d.velocity.y <= -_speed)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, -_speed);
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
            _rb2d.velocity += Vector2.up * _speed;
        else if (Input.GetKeyUp(KeyCode.W))
            _rb2d.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
            _rb2d.velocity += Vector2.left * _speed;
        else if (Input.GetKeyUp(KeyCode.A))
            _rb2d.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.S))
            _rb2d.velocity += Vector2.down * _speed;
        else if (Input.GetKeyUp(KeyCode.S))
            _rb2d.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
            _rb2d.velocity += Vector2.right * _speed;
        else if (Input.GetKeyUp(KeyCode.D))
            _rb2d.velocity = Vector2.zero;
    }

    
}
