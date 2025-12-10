using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator anim, anim2, anim3, anim4, anim5;
    [SerializeField] public bool attackB1, attackB2, attackB3, attackB4, attackB5;
    int attack;
    public void Attack1()
    {
        if (attackB1)
        {
            attack++;
            if (attack >= 2)
            {
                attack = 0;
            }
            if (attack == 1)
            {
                bool attacking = true;
                anim.SetBool("Attacking", attacking);
            }
            else
            {
                bool attacking = false;
                anim.SetBool("Attacking", attacking);
            }
        }
        
    }

    int attack2;
    public void Attack2()
    {
        if (attackB2)
        {
            attack2++;
            if (attack2 >= 2)
            {
                attack2 = 0;
            }
            if (attack2 == 1)
            {
                bool attacking = true;
                anim2.SetBool("Golpe", attacking);
            }
            else
            {
                bool attacking = false;
                anim2.SetBool("Golpe", attacking);
            }
        }
    }

    int attack3;
    public void Attack3()
    {
        if (attackB3)
        {
            attack3++;
            if (attack3 >= 2)
            {
                attack3 = 0;
            }
            if (attack3 == 1)
            {
                bool attacking = true;
                anim3.SetBool("Golpe", attacking);
            }
            else
            {
                bool attacking = false;
                anim3.SetBool("Golpe", attacking);
            }
        }
    }
    int attack4;
    public void Attack4()
    {
        if (attackB4)
        {
            attack4++;
            if (attack4 >= 2)
            {
                attack4 = 0;
            }
            if (attack4 == 1)
            {
                bool attacking = true;
                anim4.SetBool("Golpe", attacking);
            }
            else
            {
                bool attacking = false;
                anim4.SetBool("Golpe", attacking);
            }
        }
    }
    int attack5;
    public void Attack5()
    {
        if (attackB5)
        {
            attack5++;
            if (attack5 >= 2)
            {
                attack5 = 0;
            }
            if (attack5 == 1)
            {
                bool attacking = true;
                anim5.SetBool("Golpe", attacking);
            }
            else
            {
                bool attacking = false;
                anim5.SetBool("Golpe", attacking);
            }
        }
    }
}
