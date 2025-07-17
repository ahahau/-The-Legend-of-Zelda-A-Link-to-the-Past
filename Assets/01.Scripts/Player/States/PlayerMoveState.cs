using UnityEngine;

namespace _01.Scripts.Player.States
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(Entity.Entity entity, int animationHash) : base(entity, animationHash)
        {
        }
    }
}