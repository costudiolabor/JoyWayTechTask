using UnityEngine;

[CreateAssetMenu(fileName = "New Poison", menuName = "Poison", order = 2)]

public class Poison : DataActivity
{
    public override bool ApplyActivity(Transform currentObject)
    {
        bool result = false;
        if (currentObject.TryGetComponent<Poisoning>(out Poisoning poisoning))
        {
            poisoning.Poison(GetCount(), GetSteps());
            result = true;
        }
        return result;
    }
}
