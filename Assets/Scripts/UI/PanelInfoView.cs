using UnityEngine;
using UnityEngine.UI;


public class PanelInfoView : MonoBehaviour
{
    [SerializeField]
    private GameObject imageHealth;
    [SerializeField]
    private Text countHealth;
    [SerializeField]
    private GameObject imageShield;
    [SerializeField]
    private Text countShield;
    [SerializeField]
    private GameObject imagePoison;
    [SerializeField]
    private Text countPoison;

    public void ChangeHealth(int health)
    {
        countHealth.text = health.ToString();
    }

    public void SetImageShield(bool isActive)
    {
        imageShield.SetActive(isActive);
    }

    public void ChangeShield(int shield)
    {
        countShield.text = shield.ToString();
    }

    public void SetImagePoison(bool isActive)
    {
        imagePoison.SetActive(isActive);
    }
    
    public void ChangePoison(int poison)
    {
        countPoison.text = poison.ToString();
    }
}
