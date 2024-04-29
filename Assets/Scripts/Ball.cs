using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _speed;
    Vector3 _position;
   
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _position = transform.position;
        
        _rigidbody = GetComponent<Rigidbody2D>();
        LounchBall();
    }

   
    private void LounchBall()
    {
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;

        _rigidbody.velocity = new Vector3( _speed * x, _speed * y);
    }

    public void RestBall()
    {

        transform.position = _position;
        _rigidbody.velocity = Vector2.zero;
        LounchBall();
    }
}
