using UnityEngine;

public class PushBoxesOnHit : ShootingBehaviour
{
    [SerializeField] private LayerMask hittableLayers;
    [SerializeField] private float hitForce;
    protected override void OnBulletHit(RaycastHit hit)
    {
        if(((1 << hit.transform.gameObject.layer) & hittableLayers) != 0)
        {
            hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(Camera.main.transform.forward * hitForce, hit.point, ForceMode.Impulse);
        }
    }
}
