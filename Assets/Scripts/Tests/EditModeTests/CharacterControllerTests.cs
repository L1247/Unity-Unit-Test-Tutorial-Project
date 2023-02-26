#region

using NSubstitute;
using NUnit.Framework;
using UnitTest;
using UnityEngine;
using CharacterController = UnitTest.CharacterController;

#endregion

public class CharacterControllerTests
{
#region Test Methods

    [Test(Description = "測試取得元件在Unity內")]
    [Category("Tests")]
    public void _01_Test_GetComponent()
    {
        // arrange
        var gameObject = new GameObject().AddComponent<CharacterController>();
        // act
        var characterController = gameObject.GetComponent<CharacterController>();
        // assert
        Assert.IsNotNull(characterController , "characterController is no exists.");
    }

    [Test]
    [Category("jsadhkjash")]
    public void _02_Test_NewGameObject()
    {
        // arrange
        var gameObjectName = "MyCharacter";
        // act
        var gameObject = new GameObject(gameObjectName);
        // assert
        Assert.AreEqual("MyCharacter" , gameObject.name);
    }

    [Test(Description = "按下左右方向鍵控制角色移動")]
    [Category("CharacterController")]
    public void _03_Character_Move_By_Press_Horizontal_Arrow_Key()
    {
        // arrange
        var characterController = new GameObject().AddComponent<CharacterController>();
        characterController.Init();
        characterController.SetMoveSpeed(10);
        var inputSystem = Substitute.For<IInputSystem>();
        inputSystem.GetHorizontalValue().Returns(1);
        characterController.SetInputSystem(inputSystem);
        var rigidbody2D = characterController.GetComponent<Rigidbody2D>();

        // act
        characterController.Update();

        // assert
        Assert.AreEqual(new Vector2(10 , 0) , rigidbody2D.velocity);
    }

    [Test(Description = "按下左右方向鍵控制角色移動")]
    [Category("CharacterController")]
    public void _04_Character_Move_By_Press_Horizontal_Arrow_Key_Interaction()
    {
        // arrange
        var inputSystem         = Substitute.For<IInputSystem>();
        var unityServices       = Substitute.For<IUnityService>();
        var characterController = new GameObject().AddComponent<CharacterController>();
        characterController.Init();
        characterController.SetMoveSpeed(10);
        inputSystem.GetHorizontalValue().Returns(1);
        characterController.SetInputSystem(inputSystem);
        characterController.SetUnityServices(unityServices);

        // act
        characterController.Update();

        // assert
        unityServices.Received(1).MovePositionByRigidbody(new Vector2(10 , 0));
    }

#endregion
}