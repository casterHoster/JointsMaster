using System;
using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
[RequireComponent (typeof(Rigidbody))]
public class CatapultShoot : MonoBehaviour
{
    [SerializeField] private float _forceLaunch;
    [SerializeField] private float _forceReturn;

    private SpringJoint _springJoint;
    private Rigidbody _rigidbody;
    private Vector3 _connectedAnchorLaunch = new Vector3(-3, 3.5f, 13);
    private Vector3 _connectedAnchorReturn = new Vector3(-3, 1, 4);
    private KeyCode _rightArrowKey = KeyCode.RightArrow;
    private KeyCode _leftArrowKey = KeyCode.LeftArrow;

    public event Action Shooted;

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
        if (Input.GetKey(_rightArrowKey)) 
        {
            _springJoint.connectedAnchor = _connectedAnchorLaunch;
            _rigidbody.AddForce(transform.up * _forceLaunch);
            Shooted?.Invoke();

        }

        if (Input.GetKey(_leftArrowKey))
        {
            _springJoint.connectedAnchor = _connectedAnchorReturn;
            _rigidbody.AddForce(-transform.forward * _forceReturn);
        }
    }
}
