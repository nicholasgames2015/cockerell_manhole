using System.Collections;
using UnityEngine;

public class RecoilOnShoot : ShootingBehaviour
{
    [SerializeField] private Vector2 minRecoil;
    [SerializeField] private Vector2 maxRecoil;
    [SerializeField] private float constantDeRecoilSpeed;
    private Quaternion lastRecoilDelta;
    private void Update()
    {
        if (!shootingHandler.Shooting)
        {
            lastRecoilDelta = Quaternion.identity;
        }
        if (!Mathf.Approximately(Quaternion.Angle(lastRecoilDelta, Quaternion.identity), 0.0f))
        {
            var newRot = Quaternion.RotateTowards(transform.localRotation, Quaternion.Inverse(lastRecoilDelta) * transform.localRotation, constantDeRecoilSpeed * Time.deltaTime);
            lastRecoilDelta = (Quaternion.Inverse(transform.localRotation) * newRot) * lastRecoilDelta;
            transform.localRotation = newRot;
        }
    }

    protected override void OnShoot()
    {
        var deltaX = Random.Range(minRecoil.x, maxRecoil.x);
        var deltaY = Random.Range(maxRecoil.y, maxRecoil.y);
        var initial = transform.localRotation;
        transform.localRotation = Quaternion.Euler(Vector3.left * deltaY) * transform.localRotation;
        transform.localRotation = Quaternion.Euler(Vector3.up * deltaX) * transform.localRotation;
        lastRecoilDelta = (Quaternion.Inverse(initial) * transform.localRotation) * lastRecoilDelta;
    }
}
