using UnityEngine;

public class SetActivity : MonoBehaviour
{
    [SerializeField]
    private DataActivity[] dataActivity;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private int currentDataActivity;

    private Transform thisTransform;
    private Vector3 beginPosition;

    void Awake()
    {
        thisTransform = transform;
        beginPosition = thisTransform.position;
        gameObject.SetActive(false);
        spriteRenderer.sprite = null;
    }

    public void Activate()
    {
        thisTransform.position = beginPosition;
        currentDataActivity = Random.Range(0, dataActivity.Length);
        spriteRenderer.sprite = dataActivity[currentDataActivity].GetSprite();
    }

    public  bool ApplyActivity(Transform currentObject)
    {
      return dataActivity[currentDataActivity].ApplyActivity(currentObject);
    }
}
