using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Weapon : MonoBehaviour
{

    #region Variables
    public int Damage = 0;


    public float ShootingRate;
    private float _shootCooldown = 0;

    public Transform ShotPrefab;
    private Transform _muzzleRef;
    private Transform _boreRef;

    private float _ctime;

    #endregion

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
        if (_ctime > _shootCooldown)
        {
            InitBullet();
            _shootCooldown = _ctime + ShootingRate;

            //TODO: add audio source
            //var asrc = GetComponent<AudioSource>();
            //if (asrc != null) asrc.Play();
        }
    }

    private void InitBullet()
    {
        var bullet = Instantiate(ShotPrefab, transform.Find("Muzzle").position, transform.Find("Muzzle").rotation);
        bullet.gameObject.GetComponent<ProjectilePhysics>().Damage = Damage;

        var facingRight = GameObject.Find("MainPlayer").GetComponent<MainCharacterMovementControl>().facingRight;
        var xSpeed = bullet.GetComponent<ProjectilePhysics>().Shotspeed;
        var yDiff = (transform.Find("Muzzle").position.y - transform.Find("Bore").position.y) * xSpeed;
        //var yDiff = transform.Find("Muzzle").rotation.z * xSpeed;

        xSpeed = facingRight ? xSpeed : xSpeed * -1;

        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, (float)yDiff);
    }
}
