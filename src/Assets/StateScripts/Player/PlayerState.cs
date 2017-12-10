using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private HumanBodyPart _head;
    public int maxHeadHp = 2;

    public HumanBodyPart Head
    {
        get { return _head; }
    }

    void Awake()
    {
        _head = new HumanBodyPart(maxHeadHp, "head");
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
}
