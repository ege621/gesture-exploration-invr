using UnityEngine;

public class GestureAnimPlayer : MonoBehaviour
{
    private Animation anim;

    public AnimationClip openClip;
    public AnimationClip closeClip;

    private void Awake()
    {
        anim = GetComponent<Animation>();    
    }

    public void PlayOpenClip()
    {
        anim.Play(openClip.name);
    }

    public void PlayCloseClip()
    {
        anim.Play(closeClip.name);
    }   
}
