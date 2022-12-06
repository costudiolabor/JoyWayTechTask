using UnityEngine;

public class DataActivity : ScriptableObject
{
    [SerializeField]
    private Sprite spriteActivity;
    [SerializeField]
    private string nameActivity;
    [SerializeField]
    private int count;
    [SerializeField]
    private int steps;


    public Sprite GetSprite()
    {
        return spriteActivity;
    }

    public int GetCount()
    {
        return count;
    }

    public int GetSteps()
    {
        return steps;
    }

    public virtual bool ApplyActivity(Transform currentObject)
    {
        return false;
    }

}


