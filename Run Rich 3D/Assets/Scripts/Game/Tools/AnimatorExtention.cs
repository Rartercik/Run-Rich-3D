using UnityEngine;

namespace Game.Tools
{
    public static class AnimatorExtention
    {
        public static bool IsPlaying(this Animator animator, AnimationClip animation)
        {
            var currentState = animator.GetCurrentAnimatorStateInfo(0);

            return currentState.IsName(animation.name);
        }
    }
}