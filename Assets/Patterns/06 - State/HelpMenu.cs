using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MenuStateBase
{
    public override void InitState(MenuController menuController)
    {
        base.InitState(menuController);

        State = MenuController.MenuState.Help;
    }
}

