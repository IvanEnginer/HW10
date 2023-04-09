using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed = 3f;
    public float TimeToReachSpeed = 1f;

    private Transform _playerTranform;

    private void Start()
    {
        _playerTranform = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTranform.position - transform.position).normalized;

        Vector3 forse = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity) / TimeToReachSpeed;

        Rigidbody.AddForce(forse);
    }
}
