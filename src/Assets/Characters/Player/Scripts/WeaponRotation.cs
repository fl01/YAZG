using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class WeaponRotation : MonoBehaviour
{
    public int maxRotation = 55;
    public int rotationSpeed = 1;
    public int rotationSpeedWithoutWeapon = 2;

    private MainCharacterMovementControl _mainCharacterMovement;
    private PlayerWeapon _weapon;
    private PlayerState _player;

    void Awake()
    {
        _mainCharacterMovement = GetComponentInParent<MainCharacterMovementControl>();
        _player = GetComponentInParent<PlayerState>();
        if (_mainCharacterMovement == null)

        {
            Debug.LogError("Character movement is missing");
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePos - transform.position;
            difference.Normalize();

            if (!_mainCharacterMovement.facingRight)
            {
                difference *= -1;
            }

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            if (rotationZ <= -maxRotation) // down
            {
                rotationZ = -maxRotation;
            }
            else if (rotationZ >= maxRotation) // up
            {
                rotationZ = maxRotation;
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, rotationZ), rotationSpeed * GetRotationSpeed());
        }
    }

    private float GetRotationSpeed()
    {
        if (_player.ActiveWeapon == null)
        {
            return rotationSpeedWithoutWeapon;
        }

        Mastery mastery = _player.GetActiveWeaponMastery();
        if (mastery == null)
        {
            return rotationSpeedWithoutWeapon;
        }

        return mastery.Coefficient;
    }
}
