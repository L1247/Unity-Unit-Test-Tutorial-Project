#region

using UnityEngine;

#endregion

namespace UnitTest
{
    public interface IUnityService
    {
    #region Public Methods

        void MovePositionByRigidbody(Vector2 movement);

    #endregion
    }

    public class UnityService : IUnityService
    {
    #region Private Variables

        private readonly Rigidbody2D rb;

    #endregion

    #region Constructor

        public UnityService(Rigidbody2D rb)
        {
            this.rb = rb;
        }

    #endregion

    #region Public Methods

        public void MovePositionByRigidbody(Vector2 movement)
        {
            rb.velocity = new Vector2(movement.x , movement.y);
        }

    #endregion
    }
}