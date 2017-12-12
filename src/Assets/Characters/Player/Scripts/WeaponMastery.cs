using System.Collections.Generic;

public class WeaponMastery
{
    private Dictionary<WeaponType, Mastery> _masteries = new Dictionary<WeaponType, Mastery>() { };

    public Mastery this[WeaponType type]
    {
        get
        {
            Mastery currentValue;
            _masteries.TryGetValue(type, out currentValue);
            return currentValue;
        }
    }

    public void IncreaseMastery(WeaponType type, float coeff)
    {
        Mastery currentValue;
        if (_masteries.TryGetValue(type, out currentValue))
        {
            currentValue.Coefficient += coeff;
        }
        else
        {
            _masteries[type] = new Mastery() { Coefficient = coeff };
        }
    }
}

public class Mastery
{
    public float Coefficient = 0;
}

