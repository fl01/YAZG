using UnityEngine;
using UnityStandardAssets._2D;

public class WeaponFireControl : MonoBehaviour
{
    private float _shootCooldown = 0;
    private float _ctime;
    private PlayerState _player;
    private AudioManager _playerAudioManager;

    void Awake()
    {
        _player = GetComponentInParent<PlayerState>();
        _playerAudioManager = GetComponentInParent<AudioManager>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _ctime = Time.time;
    }

    public void Shoot()
    {
        if (_player.ActiveWeapon == null)
        {
            Debug.Log("Cannot shoot without a weapon");
            return;
        }

        Debug.Log("");

        if (_ctime > _shootCooldown)
        {
            ShootBullet();
            _shootCooldown = _ctime + _player.ActiveWeapon.RateOfFire;
            _playerAudioManager.Play(_player.ActiveWeapon.FireSound);
        }
    }

    private void ShootBullet()
    {
        var muzzle = transform.Find("Weapon").Find("Muzzle");
        var bore = transform.Find("Weapon").Find("Bore");

        var bullet = Instantiate(_player.ActiveWeapon.Bullet.Prefab, muzzle.position, muzzle.rotation);

        var facingRight = _player.GetComponent<MainCharacterMovementControl>().facingRight;
        if (!facingRight)
        {
            // rotate bullet towards left
            bullet.localScale *= -1;
        }

        var speed = _player.ActiveWeapon.Bullet.Shotspeed;
        bullet.GetComponent<Rigidbody2D>().AddForce((muzzle.position - bore.position) * speed);
    }
}
