using UnityEngine;

public abstract class ShootingBehaviour : MonoBehaviour
{
    [SerializeField] protected ShootingHandler shootingHandler;

    protected virtual void Reset()
    {
        shootingHandler = GetComponent<ShootingHandler>();
    }

    protected virtual void OnEnable()
    {
        shootingHandler.BulletShot += OnShoot;
        shootingHandler.BulletHit += OnBulletHit;
    }

    protected virtual void OnDisable()
    {
        shootingHandler.BulletShot -= OnShoot;
        shootingHandler.BulletHit -= OnBulletHit;
    }

    protected virtual void OnShoot() { }
    protected virtual void OnBulletHit(RaycastHit hit) { }
}
