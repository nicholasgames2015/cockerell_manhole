using System.Collections;
using UnityEngine;

public class WeaponRecoilAnimator : ShootingBehaviour
{
    [SerializeField] private AnimationCurve weaponPushbackCurve;
    [SerializeField] private float weaponPushbackMagnitude;
    [SerializeField] private Transform weapon;
    private Vector3 baseWeaponOffset;

    private void Start()
    {
        baseWeaponOffset = weapon.localPosition;
    }

    protected override void OnShoot()
    {
        StartCoroutine(AnimateWeapon());
    }

    private IEnumerator AnimateWeapon()
    {
        float timeSinceShoot = 0.0f;
        do
        {
            var offset = -(weapon.localRotation * Vector3.forward) * weaponPushbackCurve.Evaluate(timeSinceShoot / shootingHandler.DelayPerBullet) * weaponPushbackMagnitude;
            weapon.localPosition = baseWeaponOffset + offset;
            timeSinceShoot += Time.deltaTime;
            yield return null;
        } while (timeSinceShoot / shootingHandler.DelayPerBullet < 1.0f);
        weapon.localPosition = baseWeaponOffset;
    }
}
