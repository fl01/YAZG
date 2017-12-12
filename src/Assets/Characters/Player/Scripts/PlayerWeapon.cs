using UnityEngine;

public class PlayerWeapon
{
    public int Damage { get; set; }

    public float RateOfFire { get; set; }

    public WeaponType WeaponType { get; set; }

    public Sprite Sprite { get; set; }

    public PlayerBullet Bullet { get; set; }
}
