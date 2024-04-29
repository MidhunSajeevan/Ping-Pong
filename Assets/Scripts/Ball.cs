using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _speed;


    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        LounchBall();
    }

   
    private void LounchBall()
    {
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;

        _rigidbody.velocity = new Vector3( Time.deltaTime * _speed * x,Time.deltaTime * _speed * y);
    }
}
