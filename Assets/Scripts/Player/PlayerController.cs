using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 30;
    [SerializeField]
    private PanelInfoController prefabPanelInfo;
    [SerializeField]
    private SetActivity activity;

    private RectTransform gamePanel;
    private PanelInfoController panelInfoController;
    private PanelInfoView panelInfoView;

    private int currentHealth;
    private int currentShield;
    private int currentStepPoison;
    private int currentDamagePoison;
    private int currentStepShield;
    public event Action Death;

    void Start()
    {
        panelInfoController = Instantiate(prefabPanelInfo);
        panelInfoController.transform.SetParent(gamePanel);
        panelInfoController.SetTarget(transform);

        panelInfoView = panelInfoController.GetComponent<PanelInfoView>();
        currentHealth = maxHealth;
        ChangeHealth(currentHealth);
        ChangePoison();
        ChangeShield();
    }

    private void OnDisable()
    {
        Death = null;
    }

    public void SetGamePanel(RectTransform gamePanel)
    {
        this.gamePanel = gamePanel;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetCurrentShield()
    {
        return currentShield;
    }

    public void ChangeHealth(int health)
    {
        currentHealth = health;
        if (currentHealth <= 0) Death?.Invoke();
        panelInfoView.ChangeHealth(currentHealth);
    }

    public void ChangeShield(int shield = 0)
    {
        currentShield = shield;
        if (panelInfoView)
        {
            panelInfoView.SetImageShield(shield > 0);
            panelInfoView.ChangeShield(currentShield);
        }
    }

    public void SetStepShield(int step)
    {
        currentStepShield = step;
    }

    public void ChangePoison(int damage = 0, int steps = 0)
    {
        currentDamagePoison = damage;
        currentStepPoison = steps;
        if (panelInfoView)
        {
            panelInfoView.SetImagePoison(steps > 0);
            panelInfoView.ChangePoison(steps);
        }
    }

    public void SetActivity()
    {
        activity.gameObject.SetActive(true);
        activity.Activate();
    }

    public void CheckStepPoison()
    {
        currentStepPoison--;
        if (currentStepPoison == 1)
        {
            ChangeHealth(currentHealth - currentDamagePoison);
        }
        else if (currentStepPoison <= 0)
        {
            ChangePoison();
        }
    }

    public void CheckStepShield()
    {
        currentStepShield--;
        if (currentStepShield <= 0)
        {
            ChangeShield();
        }
    }
}
