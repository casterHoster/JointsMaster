using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _catapultStick;
    [SerializeField] private CatapultShoot _catapultShoot;

    private Vector3 _catapultStickInitialPosition;
    private int _limitProjectiles = 1;
    private int _projectilesCount = 0;

    private void Awake()
    {
        _catapultStickInitialPosition = _catapultStick.transform.position;
    }

    private void Start()
    {
        _catapultShoot.Shooted += DecreaseCount;
        Instantiate(_projectile);
        _projectilesCount++;
    }

    private void Update()
    {
        if (_catapultStick.transform.position == _catapultStickInitialPosition && _projectilesCount < _limitProjectiles)
        {
            Instantiate(_projectile);
            _projectilesCount++;
        }
    }

    private void DecreaseCount()
    {
        if (_projectilesCount > 0)
        {
            _projectilesCount--;
        }
    }
}
