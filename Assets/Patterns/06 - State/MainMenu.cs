using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MenuStateBase
{
    public override void InitState(MenuController menuController)
    {
        base.InitState(menuController);

        State = MenuController.MenuState.Main;
    }

    public void JumpToSettings()
    {
        menuController.SetActiveState(MenuController.MenuState.Settings);
    }

    public void JumpToHelp()
    {
        menuController.SetActiveState(MenuController.MenuState.Help);
    }
}
