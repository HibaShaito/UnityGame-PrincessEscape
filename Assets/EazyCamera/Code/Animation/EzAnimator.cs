using UnityEngine;
using System.Collections;

namespace EazyCamera.Legacy
{
    public class EzAnimator : MonoBehaviour
    {
        [SerializeField] private EzMotor _controlledCharacter = null;
        private Animator _animator = null;

        private int _speedHash = -1;
        private int _jumpHash = -1;

        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
            _speedHash = Animator.StringToHash("Speed");
            _jumpHash = Animator.StringToHash("Jump");
        }

        private void Start()
        {
            if (_controlledCharacter == null)
            {
                _controlledCharacter = this.transform.root.GetComponentInChildren<EzMotor>();
            }
        }

        private void Update()
        {
            _animator.SetFloat(_speedHash, _controlledCharacter.GetNormalizedSpeed());

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger(_jumpHash);
            }
        }
    }
}
