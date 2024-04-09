using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
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

        // moving speed
        [SerializeField] private float Speed = 1;
        [SerializeField] private Transform player;
        [SerializeField] float stoppingDistance = 2f;
        [SerializeField] float teleportDistance = 5f;

        // respawn
        public bool alive = true;
        [SerializeField] float respawnTime = 15f;
        [SerializeField] float aliveTime = 5f;
        public float timer;

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
            {Attack, false }

        };

        void Start()
        {
            Anim = this.GetComponent<Animator>();
            timer = aliveTime;
        }

        private void PlayerDissolve()
        {
            Dissolve_value -= Time.deltaTime;

            if (Dissolve_value <= 0)
            {
                PlayerStatus[Moving] = true;
                PlayerStatus[Attack] = false;

                Vector2 randomDirection2D = Random.insideUnitCircle.normalized * teleportDistance;
                Vector3 randomDirection = new Vector3(randomDirection2D.x, 0, randomDirection2D.y);
                Vector3 teleportPosition = new Vector3(player.position.x + randomDirection.x, transform.position.y, player.position.z + randomDirection.z);

                transform.position = teleportPosition;

                Dissolve_value = 1;
            }

            for (int i = 0; i < MeshR.Length; i++)
            {
                MeshR[i].material.SetFloat("_Dissolve", Dissolve_value);
            }
        }

        void Update()
        {
            timer -= Time.deltaTime;

            if (alive)
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
                    PlayerDissolve();
                    alive = !alive;
                    timer = respawnTime;
                }
            }
            else
            { }

            if (timer <= 0)
            {
                if (alive)
                {
                    PlayerDissolve();
                    timer = respawnTime;
                }
                else
                {
                    timer = aliveTime;
                }
                
                alive = !alive;
            }
        }
            
    }
}