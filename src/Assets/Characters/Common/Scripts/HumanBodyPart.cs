public class HumanBodyPart
{
    private int _currentHp;
    private int _maxHp;
    public BodyPartType PartType { get; private set; }

    public string Name { get; set; }

    public BodyPartStatus Status
    {
        get
        {
            if (_currentHp >= _maxHp)
            {
                return BodyPartStatus.Normal;
            }
            else if (_currentHp <= 0)
            {
                return BodyPartStatus.Destroyed;
            }
            else
            {
                return BodyPartStatus.Injured;
            }
        }
    }

    public HumanBodyPart(int maxHp, BodyPartType type)
    {
        _maxHp = _currentHp = maxHp;
        PartType = type;
    }

    public void TakeDamage(int damage = 1)
    {
        _currentHp -= damage;
    }
}
