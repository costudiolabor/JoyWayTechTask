using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack", order = 0)]

public class Attack : DataActivity
{
    public override bool ApplyActivity(Transform currentObject)
    {
        bool result = false;

        if (currentObject.TryGetComponent<TakingDamage>(out TakingDamage takeDamage))
        {
            takeDamage.TakeDamage(GetCount());
            result = true;
        }
        return result;
    }
}
