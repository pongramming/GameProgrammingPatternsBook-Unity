using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MenuStateBase
{
    public override void InitState(MenuController menuController)
    {
        base.InitState(menuController);

        State = MenuController.MenuState.Game;
    }

    public void JumpToMain()
    {
        menuController.SetActiveState(MenuController.MenuState.Main);
    }
}
