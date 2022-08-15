using UnityEngine.InputSystem;

public class IdleToJumpTransition : Transition
{
    private PlayerImputSystem _playerImputSystem;

    public IdleToJumpTransition(State nextState,PlayerImputSystem playerImputSystem) : base(nextState)
    {
        _playerImputSystem = playerImputSystem;
        _playerImputSystem.AddJumpListener(OnJump);
    }

    private void OnJump(InputAction.CallbackContext contex)
    {
        MoveNextState();
    }
}
