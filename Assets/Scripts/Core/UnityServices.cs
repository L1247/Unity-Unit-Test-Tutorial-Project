using UnityEngine;

namespace UnitTest
{
    public interface IUnityServices
    {
        void MovePositionByRigidbody(Vector2 movement);
    }

    public class UnityServices : IUnityServices
    {
        private readonly Rigidbody2D rb;

        public UnityServices(Rigidbody2D rb)
        {
            this.rb = rb;
        }

        public void MovePositionByRigidbody(Vector2 movement)
        {
            rb.velocity = new Vector2(movement.x , movement.y);
        }
    }
}