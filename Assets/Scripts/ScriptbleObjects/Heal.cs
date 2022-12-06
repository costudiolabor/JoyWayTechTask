using UnityEngine;

[CreateAssetMenu(fileName = "New Heal", menuName = "Heal", order = 1)]

public class Heal : DataActivity
{
    public override bool ApplyActivity(Transform currentObject)
    {
        bool result = false;
        if (currentObject.TryGetComponent<Healing>(out Healing healing))
        {
            healing.Heal(GetCount());
            result = true;
        }
        return result;
    }
}
