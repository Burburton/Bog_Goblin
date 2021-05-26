using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    GameObject player;
    GameObject enemys;
    public Animator animator;
    public PlayerAttribution playerAttribution;
    public LayerMask layer;
    public GameObject bullet;

    public AudioSource swordSwing;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemys = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Start is called before the first frame update
    void Start()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        
        for (int i = 0; i < clips.Length; i++)
        {
            if (string.Equals(clips[i].name, "attack_02"))
            {
                
                AnimationEvent events = new AnimationEvent();

                events.functionName = "attackEnemy";
                events.time = 0.5f;
                
                clips[i].AddEvent(events);

                break;
            }
        }
        //animator.Rebind();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void attackEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f, layer);
        foreach(Collider collider in colliders)
        {
            if (player != null && collider != null)
            {
                if (Tools.getDistance(player, collider.gameObject) < 1f)
                {
                    if (Tools.checkDirection(player, collider.gameObject))
                    {
                        if (collider.tag == "Enemy")
                        {
                            collider.gameObject.GetComponent<PlayerAttribution>().isAttacked(50f);
                            swordSwing.Play();
                        }
                    }
                }
            }
        }
    }

    void rangedAttack()
    {
        GameObject magicBullet = GameObject.Instantiate(bullet);
        magicBullet.transform.position = transform.position + transform.right * 0.5f + transform.forward * 1 + transform.up * 0.5f;
        magicBullet.transform.rotation = transform.rotation;

        swordSwing.Play();
    }


}
