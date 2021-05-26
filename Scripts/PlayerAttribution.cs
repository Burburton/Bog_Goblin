using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttribution : MonoBehaviour
{
    private float health;
    private float fullHealth;
    public Slider lifebar;
    public Image bar;

    public Animator animator;
    private bool alive;
    public bool withCard = false;
    public bool dropCard;

    public GameObject card;

    public AudioSource deathSource;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        fullHealth = 100f;
        bar.gameObject.SetActive(true);
        alive = true;
        dropCard = true;
        //withCard = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        lifebarDisplay();
    }

    public void isAttacked(float damage)
    {
        if (health > damage)
            health -= damage;
        else health = 0f;
    }

    void lifebarDisplay()
    {
        lifebar.value = health / fullHealth;
        if (health <= 0)
        {
            if (transform.tag == "Enemy")
            {
                if (withCard && dropCard)
                {
                    GameObject studentCard = GameObject.Instantiate(card);
                    studentCard.transform.position = transform.position + new Vector3(0, 1, 0);
                    dropCard = false;
                }
            }

            bar.gameObject.SetActive(false);
            animator.SetBool("Die", true);
            alive = false;
            
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2.0f && animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            {
                if (gameObject.tag == "Enemy")
                {
                    if (gameObject)
                        Destroy(gameObject);
                }
                
            } 
        }
    }

    public bool isAlive()
    {
        return alive;
    }

    public void setCarryCard()
    {
        withCard = true;
    }
}
