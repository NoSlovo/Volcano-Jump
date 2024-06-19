using _Volcano_Jump._Scripts.GameStateMachine.GamePlay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifeTineScope : LifetimeScope
{
    [SerializeField] private GameLevel _game;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_game);
    }
}