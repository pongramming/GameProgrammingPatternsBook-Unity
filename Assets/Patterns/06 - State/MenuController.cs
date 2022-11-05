using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public enum MenuState
    {
        Game,
        Main,
        Settings,
        Help
    }

    [SerializeField] private MenuStateBase[] allMenus;

    //A dictionary to link a state enum with it's correspondent object
    private Dictionary<MenuState, MenuStateBase> menuDictionary = new Dictionary<MenuState, MenuStateBase>();

    private MenuStateBase activeState;

    //A Stack used to jump back one state, as sugested in the "Pushdown Automata" section of the State chapter.
    //With this, we don't have to hard-code in each state what happens when we jump back one step
    private Stack<MenuState> stateHistory = new Stack<MenuState>();

    private void Start()
    {
        foreach(MenuStateBase menu in allMenus)
        {
            if (menu == null) 
                continue;

            menu.InitState(this);

            menuDictionary.Add(menu.State, menu);
        }

        //Deactivate all menus
        foreach(MenuState state in menuDictionary.Keys)
        {
            menuDictionary[state].gameObject.SetActive(false);
        }

        SetActiveState(MenuState.Game);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activeState.JumpBack();
        }
    }

    public void JumpBack()
    {
        //If we have just one item in the stack then, it means we are at the state we set at start, so we have to jump forward
        if (stateHistory.Count <= 1)
        {
            SetActiveState(MenuState.Main);
        }
        else
        {
            stateHistory.Pop();

            SetActiveState(stateHistory.Peek(), isJumpingBack: true);
        }
    }

    public void SetActiveState(MenuState newState, bool isJumpingBack = false)
    {
        if (activeState != null)
        {
            activeState.gameObject.SetActive(false);
        }

        activeState = menuDictionary[newState];

        activeState.gameObject.SetActive(true);

        //If we are jumping back we shouldn't add to history because then we will get doubles
        if (!isJumpingBack)
        {
            stateHistory.Push(newState);
        }
    }
}
