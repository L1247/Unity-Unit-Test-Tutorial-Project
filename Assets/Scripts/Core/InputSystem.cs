using UnityEngine;

namespace UnitTest
{
    public interface IInputSystem
    {
        float GetHorizontalValue();
    }

    public class InputSystem : IInputSystem
    {
        public float GetHorizontalValue()
        {
            var moveInput = Input.GetAxisRaw("Horizontal");
            return moveInput;
        }
    }
}