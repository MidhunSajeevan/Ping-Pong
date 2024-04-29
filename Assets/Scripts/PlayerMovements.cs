using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] bool _IsPlayerOne;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private float _movement;

    private Vector3 _StartPostition;
    private int _Player1Life = 100;
    public int _Player2Life = 100;
    public int Player1Life{ set => _Player1Life = value; get =>_Player1Life;}
    public int Player2Life { set => _Player2Life = value; get => _Player2Life; }

    private void Start()
    {
        _StartPostition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
    }
  
    void Update()
    {

        if (_IsPlayerOne)
            _movement = Input.GetAxisRaw("Vertical");
        else
            _movement = Input.GetAxisRaw("ArrowVertical");

        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,_movement *_speed);
    }

    public void ResetPlayer()
    {
        transform.position = _StartPostition;
        _rigidbody.velocity = Vector2.zero;
    }
}
