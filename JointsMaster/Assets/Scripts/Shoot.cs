using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
public class Shoot : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnMouseDown()
    {
        _rigidbody.AddForce(transform.up * _force);
    }
}
