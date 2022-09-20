using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public Animator animator;
    //private AnimatorClipInfo[] clipInfo;
    public AnimationClip clip;
    public enum AnimationType
    {
        Awake,
        Trigger
    }

    public AnimationType type;

    public void CallAnimation()
    {

    }
}
