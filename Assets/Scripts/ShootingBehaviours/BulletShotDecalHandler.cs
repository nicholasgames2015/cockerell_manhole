using System.Collections.Generic;
using UnityEngine;

public class BulletShotDecalHandler : ShootingBehaviour
{
    [SerializeField] private GameObject decalPrefab;
    [SerializeField] private int maxDecals;
    private Queue<GameObject> spawnedDecals = new Queue<GameObject>();

    protected override void OnBulletHit(RaycastHit hit)
    {
        var offset = Random.Range(0.03f, 0.05f);
        spawnedDecals.Enqueue(PoolingManager.Instance.GetFromPool(decalPrefab, hit.point + hit.normal * offset, Quaternion.LookRotation(-hit.normal), hit.transform));

        Debug.Log("Hit somethin");

        if (spawnedDecals.Count > maxDecals)
        {
           PoolingManager.Instance.ReturnToPool(spawnedDecals.Dequeue());
        }
    }
}
