using UnityEngine;

public class ItemPickupControl : MonoBehaviour
{
    private PlayerState _player;

    void Awake()
    {
        _player = GetComponent<PlayerState>();
    }

    public bool PickupItem(GameObject item)
    {
        Debug.Log("PickupItem request from " + item.gameObject.tag);
        if (string.Equals(item.gameObject.tag, "WeaponPickup", System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Item has been picked up");

            var weaponStats = item.GetComponent<WeaponStats>();
            var bulletStats = item.GetComponent<BulletStats>();

            var playerWeapon = new PlayerWeapon()
            {
                Damage = weaponStats.damage,
                RateOfFire = weaponStats.rateOfFire,
                WeaponType = weaponStats.weaponType,
                Sprite = weaponStats.sprite,
                FireSound = weaponStats.fireSound,
                Bullet = new PlayerBullet()
                {
                    Damage = bulletStats.damage,
                    Shotspeed = bulletStats.shotspeed,
                    Prefab = bulletStats.prefab
                }
            };

            _player.PickUpWeapon(playerWeapon);
            return true;
        }

        Debug.LogWarning("Item cannot be picked up");
        return false;
    }
}
