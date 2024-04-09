using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class GhostScript : MonoBehaviour
{
    private Animator Anim;

    // Cache hash values
    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
    private static readonly int SurprisedState = Animator.StringToHash("Base Layer.surprised");
    private static readonly int AttackState = Animator.StringToHash("Base Layer.attack_shift");
    // dissolve
    [SerializeField] private SkinnedMeshRenderer[] MeshR;
    private float Dissolve_value = 1;

    // moving speed
    [SerializeField] private float Speed = 1;
    [SerializeField] private Transform player;
    [SerializeField] float stoppingDistance = 2f;
    [SerializeField] float teleportDistance = 5f;

    //lifetime
    [SerializeField] float timeAlive = 10f;
    [SerializeField] float timeRespwan = 20f;
    public float timer;
    public bool isAlive;
    public bool isDisolving;

    //Audio
    public AudioSource ghostSound;
    public AudioSource hitSound;


    //---------------------------------------------------------------------
    // character status
    //---------------------------------------------------------------------
    private const int Moving = 0;
    private const int Surprised = 1;
    private const int Attack = 2;
    private Dictionary<int, bool> PlayerStatus = new Dictionary<int, bool>
    {
        {Moving, true },
        {Surprised, false },
        {Attack, false },
    };

    void Start()
    {
        Anim = this.GetComponent<Animator>();
        timer = timeAlive;
        isAlive = true;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(isAlive)
        {
            GhostAlive();
        }
        else if(isDisolving)
        {
            PlayerDissolve();
        }
  
        if(timer <= 0)
        {
            if (isAlive)
            {
                
                KillGhost();
            }
            else
            {
                RespawnGhost();
            }
            
        }


    }

    private void GhostAlive()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPosition);

        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance < stoppingDistance && PlayerStatus[Moving] == true)
        {
            PlayerStatus[Moving] = false;
            PlayerStatus[Attack] = true;
            Anim.CrossFade(AttackState, 0.1f, 0, 0);
        }

        if (PlayerStatus[Moving])
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else if (PlayerStatus[Attack])
        {
            hitSound.Play();
            KillGhost();
        }
    }

    private void RespawnGhost()
    {
        Vector2 randomDirection2D = Random.insideUnitCircle.normalized * teleportDistance;
        Vector3 randomDirection = new Vector3(randomDirection2D.x, 0, randomDirection2D.y);
        Vector3 teleportPosition = new Vector3(player.position.x + randomDirection.x, transform.position.y, player.position.z + randomDirection.z);

        transform.position = teleportPosition;
        Dissolve_value = 1;

        for (int i = 0; i < MeshR.Length; i++)
        {
            MeshR[i].material.SetFloat("_Dissolve", Dissolve_value);
        }

        isAlive = true;
        timer = timeAlive;
        ghostSound.mute = false;
    }

    private void KillGhost()
    {
        PlayerDissolve();
        isAlive = false;
        isDisolving = true;
        timer = timeRespwan;
        ghostSound.mute = true;
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
            PlayerStatus[Moving] = true;
            PlayerStatus[Attack] = false;

            isDisolving = false;
        }

    }

}