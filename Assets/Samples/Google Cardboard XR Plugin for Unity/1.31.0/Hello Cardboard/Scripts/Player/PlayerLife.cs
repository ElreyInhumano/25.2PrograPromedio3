using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    [SerializeField] public static int life;
    public Func<int, int, int> lifeF;
    void Start()
    {
        lifeF = RestLife;
        life = 20;
    }

    void Update()
    {
        if(life <= 0)
        {
            Defeat();
        }
    }
    private void Defeat()
    {
        SceneManager.LoadScene("DefeatMenu");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            life = lifeF(life,1);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            life = lifeF(life,3);
        }
    }
    private int RestLife(int life, int rest)
    {
        return life - rest;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life = lifeF(life,1);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            life = lifeF(life, 3);
        }
    }
}
