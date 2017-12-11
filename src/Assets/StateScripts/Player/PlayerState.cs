using System;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private HumanBodyPart _head;
    private HumanBodyPart _body;
    private HumanBodyPart _legs;
    private HumanBodyPart _hands;
    private HUD _hud;
    public GameObject GM;

    public int maxHeadHp = 2;
    public int maxBodyHp = 2;
    public int maxLegsHp = 2;

    void Awake()
    {
        _head = new HumanBodyPart(maxHeadHp, "head");
        _body = new HumanBodyPart(maxBodyHp, "body");
        _legs = new HumanBodyPart(maxLegsHp, "legs");
        _hands = new HumanBodyPart(maxLegsHp, "hands");
        _hud = GM.GetComponent<HUD>();
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

        _hud.UpdateBodyPartStatus(bodyType, bodyPart.Status);
    }

    private HumanBodyPart GetHumanBodyPart(BodyPartType type)
    {
        switch (type)
        {
            case BodyPartType.Head:
                return _head;
            case BodyPartType.Body:
                return _body;
            case BodyPartType.Legs:
                return _legs;
            case BodyPartType.Hands:
                return _hands;
            default:
                Debug.LogWarning("Unknown body type");
                return null;
        }
    }
}
