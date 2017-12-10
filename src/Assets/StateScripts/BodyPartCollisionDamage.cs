using UnityEngine;

public class BodyPartCollisionDamage : MonoBehaviour
{
    private PlayerState _player;

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
            _player.Head.TakeDamage(damageComponent.damage);
            switch (_player.Head.Status)
            {
                case BodyPartStatus.Destroyed:
                    _player.OnBodyPartDestroyed(_player.Head);
                    break;
                case BodyPartStatus.Injured:
                    _player.OnBodyPartDamaged(_player.Head);
                    break;
                case BodyPartStatus.Normal:
                default:
                    Debug.LogWarning("DamageObject dealt no damage!!!");
                    break;
            }
        }
    }
}
