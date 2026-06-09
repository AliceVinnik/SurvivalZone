using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Animator animator;

    public void Set(Animator animator)
    {
        this.animator = animator;
    }

    public void PlayWalk()
    {
        if (animator == null) return;

        animator.SetBool("attack", false);
        animator.SetBool("dead", false);
    }

    public void PlayAttack()
    {
        if (animator == null) return;

        animator.SetBool("attack", true);
        animator.SetBool("dead", false);
    }

    public void PlayDead()
    {
        if (animator == null) return;

        animator.SetBool("attack", false);
        animator.SetBool("dead", true);
    }

    public float GetAnimationTime(string stateName)
    {
        if (animator == null) return 0f;
        var ac = animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
        if (ac == null) return 0f;

        foreach (var layer in ac.layers)
            foreach (var state in layer.stateMachine.states)
                if (state.state.name.ToLower() == stateName.ToLower())
                {
                    var clip = state.state.motion as AnimationClip;
                    if (clip != null)
                        return clip.length;
                }
        return 0f;
    }
}
