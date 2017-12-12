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
            _player.TakeDamage(bodyType, damageComponent.damage);
        }
    }
}
