using System.Collections.Generic;

public class WeaponMastery
{
    private Dictionary<WeaponType, float> _masteries = new Dictionary<WeaponType, float>() { };

    public float this[WeaponType type]
    {
        get
        {
            float currentValue;
            _masteries.TryGetValue(type, out currentValue);
            return currentValue;
        }
    }

    public void IncreaseMastery(WeaponType type, float coeff)
    {
        float currentValue;
        if (_masteries.TryGetValue(type, out currentValue))
        {
            _masteries[type] += coeff;
        }
        else
        {
            _masteries[type] = coeff;
        }
    }
}
