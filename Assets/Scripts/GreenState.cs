using Chars.StateMachine;

internal class GreenState : State<Lakitu.States>
{
    private Lakitu testCharacter;
    private StateMachine<Lakitu.States> stateMachine;

    public GreenState(Lakitu testCharacter, StateMachine<Lakitu.States> stateMachine)
    {
        this.testCharacter = testCharacter;
        this.stateMachine = stateMachine;
    }

    public override void EnterState()
    {
        testCharacter.SpriteRenderer.sprite = testCharacter.Sprites[2];
    }
}