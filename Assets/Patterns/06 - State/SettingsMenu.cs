using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MenuStateBase
{
    public override void InitState(MenuController menuController)
    {
        base.InitState(menuController);

        State = MenuController.MenuState.Settings;
    }
}
