using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSheep : MonoBehaviour
{
    private Animator sheepAnimator;

    public float timer;
    
    private const float MaxTime = 20f;

    public bool is_inside_animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
        sheepAnimator = this.GetComponent<Animator>();
        RestartAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > MaxTime && ! is_inside_animator)
        {
            StartCoroutine(ChangeAnimation());
        }
    }



    IEnumerator ChangeAnimation()
    {
        is_inside_animator = true;
        sheepAnimator.SetTrigger("walk");
        yield return new WaitForSeconds(20f);
        sheepAnimator.SetTrigger("exit");
        yield return new WaitForEndOfFrame();
        RestartAnimation();



    }



    private void RestartAnimation()
    {
        timer = 0f;
        is_inside_animator = false;
        sheepAnimator.SetTrigger("idle");
    }
}
