#region

using UnityEngine;
using UnityEngine.Assertions;

#endregion

namespace UnitTest
{
    public class CharacterController : MonoBehaviour
    {
    #region Private Variables

        private Rigidbody2D   rb; // 角色剛體
        private IInputSystem  inputSystem;
        private IUnityService unityService;

        [SerializeField]
        private float moveSpeed = 5f; // 角色移動速度

    #endregion

    #region Unity events

        private void Start()
        {
            Init();
        }

        public void Update()
        {
            HandleMovement();
        }

    #endregion

    #region Public Methods

        public void Init()
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null) rb = gameObject.AddComponent<Rigidbody2D>();
            Assert.IsNotNull(rb , "rb is null");
            inputSystem  = new InputSystem();
            unityService = new UnityService(rb);
        }

        public void SetInputSystem(IInputSystem inputSystem)
        {
            this.inputSystem = inputSystem;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
        }

        public void SetUnityServices(IUnityService unityService)
        {
            this.unityService = unityService;
        }

    #endregion

    #region Private Methods

        private void HandleMovement()
        {
            var movement = new Vector2(inputSystem.GetHorizontalValue() * moveSpeed , rb.velocity.y);
            unityService.MovePositionByRigidbody(movement);
        }

    #endregion
    }
}