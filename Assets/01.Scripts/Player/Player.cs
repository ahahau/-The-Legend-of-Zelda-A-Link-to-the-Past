using _01.Scripts.FSM;
using GondrLib.Dependencies;
using UnityEngine;

namespace _01.Scripts.Player
{
    public class Player : Entity.Entity
    {
        [field:SerializeField] public PlayerInputSO PlayerInput { get; private set; }

        [SerializeField] private StateDataSO[] stateDataList;
        
        private EntityStateMachine _stateMachine;
        
        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new EntityStateMachine(this, stateDataList);
            OnHitEvent.AddListener(HandleHitEvent);
            OnDeathEvent.AddListener(HandleDeadEvent);
        }

        private void OnDestroy()
        {
            OnHitEvent.RemoveListener(HandleHitEvent);
            OnDeathEvent.RemoveListener(HandleDeadEvent);
        }

        private void HandleDeadEvent()
        {
            if (IsDead) return;
            IsDead = true;
            ChangeState("DEAD", true);
        }

        private void HandleHitEvent()
        {
            const string hit = "HIT";
                ChangeState(hit, true);
        }

        private void Start()
        {
            const string idle = "IDLE";
            _stateMachine.ChangeState(idle);
        }

        private void Update()
        {
            _stateMachine.UpdateStateMachine();
        }

        public void ChangeState(string newStateName, bool force = false) 
            => _stateMachine.ChangeState(newStateName, force);
    }
}