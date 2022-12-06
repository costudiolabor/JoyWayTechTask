using UnityEngine;

public class Healing : BaseAction
{
    private int temp;

    public void Heal(int health)
    {
        temp = playerController.GetCurrentHealth() + health;
        playerController.ChangeHealth(temp);
        playerController.ChangePoison();
    }
}
