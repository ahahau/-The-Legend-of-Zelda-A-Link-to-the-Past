using _01.Scripts.FSM;
using UnityEngine;

namespace _01.Scripts.Player
{
    public abstract class PlayerState : EntityState
    {
        protected Player _player;
        protected readonly float _inputThreshold = 0.1f;
        
        protected PlayerState(Entity.Entity entity, int animationHash) : base(entity, animationHash)
        {
            _player = entity as Player;
            Debug.Assert(_player != null, $"Player state using only in player");
        }
    }
}