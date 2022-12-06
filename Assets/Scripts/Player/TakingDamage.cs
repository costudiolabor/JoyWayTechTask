using UnityEngine;

public class TakingDamage : BaseAction
{
    private int temp;

    public void TakeDamage(int damage)
    {
        temp = playerController.GetCurrentShield() - damage;
        if (temp >= 0)
        {
            playerController.ChangeShield(temp);
            return;
        }

        playerController.ChangeShield();
        temp += playerController.GetCurrentHealth();
        playerController.ChangeHealth(temp);
    }
}
