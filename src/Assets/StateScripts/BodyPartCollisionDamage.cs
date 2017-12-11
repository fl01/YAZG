using System;
using UnityEngine;

public class BodyPartCollisionDamage : MonoBehaviour
{
    private PlayerState _player;

    public BodyPartType bodyType;

    void Awake()
    {
        _player = GetComponentInParent<PlayerState>();
        if (_player == null)
        {
            Debug.LogWarning("Player state is missing");
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var damageComponent = collision.gameObject.GetComponent<BodyPartDamage>();
        if (damageComponent != null)
        {
            var status = _player.TakeDamage(bodyType, damageComponent.damage);
            // TODO : remove this shit, it is used just to see body part status as a text
            var statusText = GetComponent<TextMesh>();
            switch (bodyType)
            {
                case BodyPartType.Head:
                    statusText.text = bodyType.ToString() + ":" + status + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    break;
                case BodyPartType.Body:
                    statusText.text = bodyType.ToString() + ":" + status + "__________________";
                    break;
                case BodyPartType.Legs:
                    statusText.text = Environment.NewLine + Environment.NewLine + "__________________" + bodyType.ToString() + ":" + status;
                    break;
            }
        }
    }
}
