using UnityEngine;
using System.Collections;

namespace EazyCamera.Legacy
{
    public class EzMotor : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed = 5f;
        [SerializeField] private float _runSpeed = 15f;
        [SerializeField] private float _acceleration = 10f;
        [SerializeField] private float _rotateSpeed = 5f;
        [SerializeField] private float _jumpForce = 5f; // Add jump force
        private float _currentSpeed = 5f;
        private float _speedDelta = 0f;
        private bool _isGrounded = true; // Check if the character is grounded

        private Vector3 _moveVector = new Vector3();
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _speedDelta = _runSpeed - _walkSpeed;
            if (_speedDelta == 0)
            {
                _speedDelta = .01f;
            }
        }

        public void MovePlayer(float moveX, float moveZ, bool isRunning)
        {
            // Update the move Deltas
            _moveVector.x = moveX;
            _moveVector.z = moveZ;
            _moveVector.Normalize();

            // gradually move toward the desired speed
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, (isRunning ? _runSpeed : _walkSpeed), _acceleration * Time.deltaTime);

            // Scale the vector by the move speed
            _moveVector *= _currentSpeed;

            if (moveX != 0 || moveZ != 0)
            {
                float step = _rotateSpeed * Time.deltaTime;
                Quaternion targetRotation = Quaternion.LookRotation(_moveVector, Vector3.up);
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, step);
            }
        }

        public void Jump()
        {
            if (_isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false; // Set to false until the character lands again
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true; // Character has landed
            }
        }

        public float GetNormalizedSpeed()
        {
            return _moveVector.magnitude / _runSpeed;
        }
    }
}
