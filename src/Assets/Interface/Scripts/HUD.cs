using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class HUD : MonoBehaviour
{
    // TODO : move to separate script / ext. method
    private static Dictionary<BodyPartStatus, string> _statusColors = new Dictionary<BodyPartStatus, string>()
    {
        { BodyPartStatus.Normal, "Green" },
        { BodyPartStatus.Injured, "Orange" },
        { BodyPartStatus.Destroyed, "Red" },
    };

    public SpriteRenderer headStatus;
    public SpriteRenderer handsStatus;
    public SpriteRenderer bodyStatus;
    public SpriteRenderer legsStatus;
    public Sprite HeadGreen;
    public Sprite HeadOrange;
    public Sprite HeadRed;
    public Sprite BodyGreen;
    public Sprite BodyOrange;
    public Sprite BodyRed;
    public Sprite LegsGreen;
    public Sprite LegsOrange;
    public Sprite LegsRed;
    public Sprite HandsGreen;
    public Sprite HandsOrange;
    public Sprite HandsRed;

    private Sprite[] _sprites;

    void Awake()
    {
        _sprites = new[]
        {
            HeadGreen, HeadOrange, HeadRed,
            BodyGreen, BodyOrange, BodyRed,
            LegsGreen, LegsOrange, LegsRed,
            HandsGreen, HandsOrange, HandsRed
        };
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateBodyPartStatus(BodyPartType bodyPart, BodyPartStatus status)
    {
        string spriteName = bodyPart.ToString() + "_" + _statusColors[status];
        Debug.Log(spriteName);
        SpriteRenderer spriteRender = GetBodyPartRenderer(bodyPart);
        spriteRender.sprite = _sprites.FirstOrDefault(s => s.name == spriteName);
    }

    private SpriteRenderer GetBodyPartRenderer(BodyPartType type)
    {
        switch (type)
        {
            case BodyPartType.Body:
                return bodyStatus;
            case BodyPartType.Hands:
                return handsStatus;
            case BodyPartType.Head:
                return headStatus;
            case BodyPartType.Legs:
                return legsStatus;
            default:
                throw new InvalidOperationException("Unknown body type " + type);
        }
    }
}
