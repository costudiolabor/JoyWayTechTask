using UnityEngine;

public class Poisoning : BaseAction
{
    private int temp;

    public void Poison(int damage, int steps)
    {
        temp = playerController.GetCurrentShield() - damage;
        playerController.ChangePoison(damage, steps);

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
