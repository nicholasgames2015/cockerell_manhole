using System;
using System.Collections;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private LayerMask layersToIgnore;
    [SerializeField] private float RPM;
    [SerializeField] private AmmoHandler ammoHandler;
    
    public event Action BulletShot;
    public event Action<RaycastHit> BulletHit;
    private float timer;

    public float DelayPerBullet => 1.0f / (RPM / 60.0f);
    public bool Shooting => Input.GetMouseButton(0) && ammoHandler.Ammo > 0;
   
    private void Update()
    {
        if (Shooting)
        {
            if (timer <= 0.0f)
            {
                Ray ray = new Ray(cam.position, cam.forward);
                if (Physics.Raycast(ray, out var res, Mathf.Infinity, ~layersToIgnore))
                {
                    BulletHit?.Invoke(res);
                }
                timer = DelayPerBullet;
                BulletShot?.Invoke();
            }
        }
        timer -= Time.deltaTime;
    }
}
