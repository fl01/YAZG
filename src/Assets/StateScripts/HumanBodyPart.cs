public class HumanBodyPart
{
    private int _currentHp;
    private int _maxHp;

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

    public HumanBodyPart(int maxHp, string name)
    {
        _maxHp = _currentHp = maxHp;
    }

    public void TakeDamage(int damage = 1)
    {
        _currentHp -= damage;
    }
}
