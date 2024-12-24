using System;
using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
[RequireComponent (typeof(Rigidbody))]
public class CatapultShoot : MonoBehaviour
{
    [SerializeField] private float _forceLaunch;
    [SerializeField] private float _forceReturn;

    public event Action Shooted;

    private SpringJoint _springJoint;
    private Rigidbody _rigidbody;
    private Vector3 _connectedAnchorLaunch = new Vector3(-3, 3.5f, 13);
    private Vector3 _connectedAnchorReturn = new Vector3(-3, 1, 4);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _springJoint = GetComponent<SpringJoint>();
    }

    private void Start()
    {
        _springJoint.autoConfigureConnectedAnchor = false;
        _springJoint.connectedAnchor = _connectedAnchorReturn;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            _springJoint.connectedAnchor = _connectedAnchorLaunch;
            _rigidbody.AddForce(transform.up * _forceLaunch);
            Shooted?.Invoke();

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _springJoint.connectedAnchor = _connectedAnchorReturn;
            _rigidbody.AddForce(-transform.forward * _forceReturn);
        }
    }
}
