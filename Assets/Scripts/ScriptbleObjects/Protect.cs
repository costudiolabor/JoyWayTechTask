using UnityEngine;

[CreateAssetMenu(fileName = "New Protect", menuName = "Protect", order = 3)]

public class Protect : DataActivity
{
    public override bool ApplyActivity(Transform currentObject)
    {
        bool result = false;
        if (currentObject.TryGetComponent<Protection>(out Protection protection))
        {
            protection.Protect(GetCount(), GetSteps());
            result = true;
        }
        return result;
    }
}
