using UnityEngine;
public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    float timer;
    bool startTime;
    public int attack;
    Touch touch; 
    private Rigidbody rb;
    float screenHeight;
    float screenHeightDown;
    float screenWidthLeft;
    float screenWidth;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
        if (startTime)
        {
            Timer();
        }
    }

    void Attack()
    {
        /*screenHeight = Screen.height / 1.3f;
        screenHeightDown = Screen.height / 13f;
        screenWidth = Screen.width / 2f;
        screenWidthLeft = Screen.width / 9;
        if (Input.touchCount > 0 && Time.timeScale == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.position.y < screenHeight && touch.position.y > screenHeightDown && touch.position.x < screenWidth && touch.position.x > screenWidthLeft)
            {
                Debug.Log(Screen.width);
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 7));
                Attacking();
            }
        }*/
    }
    public void Attacking()
    {
        if (timer >= 1.5)
        {
            attack = 1;
            anim.SetInteger("Attack", attack);
            timer = 0;
        }
        else
        {
            startTime = true;
            attack++;
            anim.SetInteger("Attack", attack);
        }

        if (attack >= 2)
        {
            attack = 0;
            timer = 0;
            startTime = false;
        }
      
        if (timer >= 2)
        {
            startTime = false;
            attack = 0;
            anim.SetInteger("Attack", attack);
            timer = 0;
        }
    }
    void Timer()
    {
        timer += Time.deltaTime;
    }
    void Shake()
    {

    }
}