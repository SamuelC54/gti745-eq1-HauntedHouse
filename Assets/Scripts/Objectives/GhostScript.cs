using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostScript : MonoBehaviour
{
    private Animator Anim;
    private CharacterController Ctrl;
    private Vector3 MoveDirection = Vector3.zero;

    // Cache hash values
    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
    private static readonly int SurprisedState = Animator.StringToHash("Base Layer.surprised");
    private static readonly int AttackState = Animator.StringToHash("Base Layer.attack_shift");
    private static readonly int DissolveState = Animator.StringToHash("Base Layer.dissolve");
    private static readonly int AttackTag = Animator.StringToHash("Attack");
    
    // dissolve
    [SerializeField] private SkinnedMeshRenderer[] MeshR;
    private float Dissolve_value = 1;
    private bool isDissolved = false;

    void Start()
    {
        Anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        if(isDissolved && Dissolve_value > 0)
        {
            PlayerDissolve();
        }
    }

    public enum GhostAnimations
    {
        SURPRISE,
        ACTION,
        ASCEND
    }

    public void TriggerAnimation(GhostAnimations anim)
    { 
        switch(anim)
        {
            case GhostAnimations.SURPRISE:
                Anim.CrossFade(SurprisedState, 0.1f, 0, 0);
                break;
            case GhostAnimations.ACTION:
                Anim.CrossFade(AttackState, 0.1f, 0, 0);
                break;
            case GhostAnimations.ASCEND:
                PlayerDissolve();
                Anim.CrossFade(DissolveState, 0.1f, 0, 0);
                isDissolved = true;
                break;
            default:
                Anim.CrossFade(IdleState, 0.1f, 0, 0);
                break;
        }
    }

    private void PlayerDissolve()
    {
        Dissolve_value -= Time.deltaTime;
        for (int i = 0; i < MeshR.Length; i++)
        {
            MeshR[i].material.SetFloat("_Dissolve", Dissolve_value);
        }
        if (Dissolve_value <= 0)
        {
            Debug.Log("Ghost Acended");

        }
    }

}
