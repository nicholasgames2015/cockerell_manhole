using UnityEngine;

public class PlayerAudio : ShootingBehaviour
{
    [SerializeField] private AudioSource shootSoundEffect;

    protected override void OnShoot()
    {
        shootSoundEffect.Play();
    }
}
