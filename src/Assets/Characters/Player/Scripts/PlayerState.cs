using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private HumanBodyPart _head;
    private HumanBodyPart _body;
    private HumanBodyPart _legs;
    private HumanBodyPart _hands;
    private GameObject _weaponGameObject;
    private HUD _hud;
    private WeaponMastery _mastery = new WeaponMastery();

    private PlayerWeapon _activeWeapon = null;
    private List<PlayerWeapon> _weapons = new List<PlayerWeapon>();

    private AudioSource _audioSource;
    private AudioManager _audioManager;

    public GameObject GM;
    public int maxHeadHp = 2;
    public int maxBodyHp = 2;
    public int maxLegsHp = 2;
    public int maxHandsHp = 2;

    public PlayerWeapon ActiveWeapon
    {
        get { return _activeWeapon; }
    }

    public Mastery GetActiveWeaponMastery()
    {
        return _mastery[_activeWeapon.WeaponType];
    }

    void Awake()
    {
        _head = new HumanBodyPart(maxHeadHp, BodyPartType.Head);
        _body = new HumanBodyPart(maxBodyHp, BodyPartType.Body);
        _legs = new HumanBodyPart(maxLegsHp, BodyPartType.Legs);
        _hands = new HumanBodyPart(maxHandsHp, BodyPartType.Hands);
        _weaponGameObject = transform.Find("Hands").Find("Weapon").gameObject;

        _hud = GM.GetComponent<HUD>();

        _audioSource = GetComponent<AudioSource>();
        _audioManager = GetComponent<AudioManager>();

        _mastery.IncreaseMastery(WeaponType.Shotgun, 0.3f);
    }

    public void PickUpWeapon(PlayerWeapon playerWeapon)
    {
        AddWeaponToCollection(playerWeapon);
        UpdateActiveWeaponSprite();
    }

    private void UpdateActiveWeaponSprite()
    {
        _weaponGameObject.GetComponent<SpriteRenderer>().sprite = _activeWeapon.Sprite;
    }

    private void AddWeaponToCollection(PlayerWeapon playerWeapon)
    {
        _weapons.Add(playerWeapon);
        _activeWeapon = _weapons[_weapons.Count - 1];
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBodyPartDestroyed(HumanBodyPart humanBodyPart)
    {
        // character is dead
        Debug.Log(name + " character is dead");
        _audioManager.PlayDeathSound(_audioSource);
    }

    public void OnBodyPartDamaged(HumanBodyPart humanBodyPart)
    {
        // character is injured
        Debug.Log(name + " character is injured");
        _audioManager.PlayHitSound(_audioSource);
    }

    public void TakeDamage(BodyPartType bodyType, int damage)
    {
        var bodyPart = GetHumanBodyPartToTakeDamage(bodyType);
        bodyPart.TakeDamage(damage);
        switch (bodyPart.Status)
        {
            case BodyPartStatus.Destroyed:
                OnBodyPartDestroyed(bodyPart);
                break;
            case BodyPartStatus.Injured:
                OnBodyPartDamaged(bodyPart);
                break;
            case BodyPartStatus.Normal:
            default:
                Debug.LogWarning("DamageObject dealt no damage!!!");
                break;
        }

        _hud.UpdateBodyPartStatus(bodyPart.PartType, bodyPart.Status);
    }

    private HumanBodyPart GetHumanBodyPartToTakeDamage(BodyPartType type)
    {
        switch (type)
        {
            case BodyPartType.Head:
                return _head;
            // hands & body is a special case. hands could be damaged only if player is aiming right now
            case BodyPartType.Body:
            case BodyPartType.Hands:
                bool isAiming = Input.GetMouseButton(1);
                return isAiming ? _hands : _body;
            case BodyPartType.Legs:
                return _legs;
            default:
                Debug.LogWarning("Unknown body type");
                return null;
        }
    }
}
