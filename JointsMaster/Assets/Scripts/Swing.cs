using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Swing : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody> ();
    }

    public void OnMouseDown()
    {
        _rigidbody.AddForce(transform.forward * _force);
    }

}
