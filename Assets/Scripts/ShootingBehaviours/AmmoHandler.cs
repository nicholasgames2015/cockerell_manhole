using UnityEngine;
using System;
public class AmmoHandler : ShootingBehaviour
{
    [SerializeField] private int magzineAmmo;
    [SerializeField] private int totalAmmo;
    [SerializeField] private KeyCode reloadKey = KeyCode.R;
    public event Action<int> CurrentAmmoUpdated;
    public event Action<int> TotalAmmoUpdated;
    public int Ammo { get; private set; }

    private void Start()
    {
        Ammo = magzineAmmo;
        CurrentAmmoUpdated?.Invoke(Ammo);
        TotalAmmoUpdated?.Invoke(totalAmmo);
    }

    private void Update()
    {
        if (Input.GetKeyDown(reloadKey))
        {
            var needed = magzineAmmo - Ammo;
            var diff = totalAmmo >= needed ? needed : totalAmmo;
            Ammo += diff;
            totalAmmo -= diff;
            CurrentAmmoUpdated?.Invoke(Ammo);
            TotalAmmoUpdated?.Invoke(totalAmmo);
        }
    }

    protected override void OnShoot()
    {
        Ammo--;
        CurrentAmmoUpdated?.Invoke(Ammo);
    }
}
