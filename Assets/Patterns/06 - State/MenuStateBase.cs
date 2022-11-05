using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateBase : MonoBehaviour
{
    public MenuController.MenuState State { get; protected set; }

    protected MenuController menuController;

    //Injecting the MenuController so it's easier to reference it from each menu
    public virtual void InitState(MenuController menuController)
    {
        this.menuController = menuController;
    }

    //Jump back to the previous menu using a Stack,
    //as stated in the "Pushdown Automata" section of the State chapter.
    public void JumpBack()
    {
        menuController.JumpBack();
    }
}
