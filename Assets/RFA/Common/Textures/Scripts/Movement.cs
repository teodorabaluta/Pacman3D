using UnityEngine;

namespace Retro.ThirdPersonCharacter
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        private Animator _animator;
        private PlayerInput _playerInput;
        private CharacterController _characterController;

        public float rotationSpeed = 5f; // Viteza de rotație a personajului.
        public float MaxSpeed = 5f; // Viteza maximă a personajului.

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _playerInput = GetComponent<PlayerInput>();
   
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var x = _playerInput.MovementInput.x;
            var y = _playerInput.MovementInput.y;
            Debug.Log("x: " + x + " y: " + y);

            // Rotim personajul doar dacă mișcarea este la stânga sau la dreapta.
            if (Mathf.Abs(x) > 0.1f || Mathf.Abs(y) > 0.1f)
            {
                // Calculăm unghiul de rotație bazat pe direcția de mișcare.
                float targetAngle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;

                // Rotim treptat personajul către unghiul dorit.
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);

                // Setăm unghiul de rotație.
                transform.rotation = Quaternion.Euler(0, angle, 0);

                // Aplicăm mișcarea.
                Vector3 movement = transform.forward * Mathf.Clamp01(Mathf.Abs(y) + Mathf.Abs(x)) * MaxSpeed;
                _characterController.Move(movement * Time.deltaTime);
            }

            // Actualizăm parametrii animatorului.
            _animator.SetFloat("InputX", x);
            _animator.SetFloat("InputY", y);
        }

    }
}
