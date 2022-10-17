using Chars.StateMachine;

internal class RedState : State<Lakitu.States>
{
    private Lakitu testCharacter;
    private StateMachine<Lakitu.States> stateMachine;

    public RedState(Lakitu testCharacter, StateMachine<Lakitu.States> stateMachine)
    {
        this.testCharacter = testCharacter;
        this.stateMachine = stateMachine;
    }

    public override void EnterState()
    {
        testCharacter.SpriteRenderer.sprite = testCharacter.Sprites[0];
    }

}