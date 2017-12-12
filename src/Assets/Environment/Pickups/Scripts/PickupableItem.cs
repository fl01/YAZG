using System;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{

    public string descriptionText;
    public bool canPickup = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision))
        {
            var control = collision.gameObject.GetComponentInParent<ItemPickupControl>();
            if (control.PickupItem(gameObject))
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayer(collision))
        {
            canPickup = false;
        }
    }

    private bool IsPlayer(Collider2D collision)
    {
        Debug.Log("Pickup collision with " + collision.gameObject.tag);
        return string.Equals(collision.gameObject.tag, "Player", StringComparison.OrdinalIgnoreCase);
    }
}
