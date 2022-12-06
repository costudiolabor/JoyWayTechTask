using UnityEngine;

public class Protection : BaseAction
{
    public void Protect(int shield, int steps)
    {
        playerController.ChangeShield(shield);
        playerController.SetStepShield(steps);
    }
}
