using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] bool _IsPlayerOne;
    [SerializeField] private float _speed;
 
    private Rigidbody2D _rigidbody;
    private float _movement;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        if (_IsPlayerOne)
            _movement = Input.GetAxisRaw("Vertical");
        else
            _movement = Input.GetAxisRaw("ArrowVertical");

        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Time.deltaTime * _movement *_speed);
    }
}
