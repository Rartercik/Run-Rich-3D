using System;
using UnityEngine;

namespace Game.PlayerComponents
{
    [Serializable]
    public class PlayerMovement
    {
        [SerializeField] private float _forwardSpeed;
        
        private Rigidbody _rigidbody;
        private float _shift;
        private float _nextShift;

        public void Initialize(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void FixedUpdate()
        {
            var velocity = Vector3.forward * _forwardSpeed;
            velocity.x = _shift / Time.fixedDeltaTime;
            _rigidbody.velocity = velocity;
            _shift = _nextShift;
            _nextShift = 0;
        }

        public void MoveAside(float shift)
        {
            _nextShift += shift;
        }
    }
}