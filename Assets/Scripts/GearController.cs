using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{

    //Eneny control speed
    [SerializeField] private float movSpeed = 0f;
    [SerializeField] private float rotSpeed = 0f;
    [SerializeField] private Animator animator;

    internal bool isDestroyed = false;

    //Enemy go-to posistion
    private Vector3 targetPos = Vector3.zero;

    void Start()
    {
        //Setting initial go-to position
        targetPos = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-4.5f, 4.5f));

        Invoke("FadeOut", Random.Range(6, 8));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed)
        {
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                //Setting new postion if enemy reaches the set position
                targetPos = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-4.5f, 4.5f));
            }
            else
            {
                //Moving enemy to the set position
                transform.position = Vector2.MoveTowards(transform.position, targetPos, movSpeed * Time.deltaTime);
            }

            //Gear Rotation effect
            transform.Rotate(Vector3.forward * rotSpeed);
        }
        //else
        //    Destroy(gameObject);
    }

    public void FadeOut()
    {
        animator.SetTrigger("GearFadeOut");
        destroyGear();
    }

    public void destroyGear()
    {
        Destroy(gameObject, 1f);
        GearSpawner.count--;
    }
}
