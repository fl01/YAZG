using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private HumanBodyPart _head;
    private HumanBodyPart _body;
    private HumanBodyPart _legs;
    private HumanBodyPart _hands;
    private HUD _hud;
    private WeaponMastery _mastery = new WeaponMastery();
    private Weapon _activeWeapon = new Weapon() { Damage = 3, RateOfFire = 0.25f };

    public GameObject GM;
    public int maxHeadHp = 2;
    public int maxBodyHp = 2;
    public int maxLegsHp = 2;

    public WeaponMastery Mastery
    {
        get { return _mastery; }
    }

    public Weapon ActiveWeapon
    {
        get { return _activeWeapon; }
    }

    void Awake()
    {
        _head = new HumanBodyPart(maxHeadHp, BodyPartType.Head);
        _body = new HumanBodyPart(maxBodyHp, BodyPartType.Body);
        _legs = new HumanBodyPart(maxLegsHp, BodyPartType.Legs);
        _hands = new HumanBodyPart(maxLegsHp, BodyPartType.Hands);
        _hud = GM.GetComponent<HUD>();

        _mastery.IncreaseMastery(WeaponType.Shotgun, 0.3f);
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
    }

    public void OnBodyPartDamaged(HumanBodyPart humanBodyPart)
    {
        // character is injured
        Debug.Log(name + " character is injured");
    }

    public void TakeDamage(BodyPartType bodyType, int damage)
    {
        var bodyPart = GetHumanBodyPart(bodyType);
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

    private HumanBodyPart GetHumanBodyPart(BodyPartType type)
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
