using System.Collections;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public Animator animator;
    public AnimationClip clip;

    //Sec = segundos - Value = Se pode ou não se movimentar
    public void CallAnimation(float sec, bool value)
    {
        gameManager.SetMoving(value);

        if(sec == 0)
        {
            animator.SetBool(clip.ToString(), true);
        }
        else
        {
            CallAnimationInSeconds(sec);
        }
    }

    IEnumerator CallAnimationInSeconds(float value)
    {
        yield return new WaitForSeconds(value);
        animator.SetBool(clip.ToString(), true);
        yield return new WaitForSeconds(2f);
        animator.SetBool(clip.ToString(), false);
    }
}
