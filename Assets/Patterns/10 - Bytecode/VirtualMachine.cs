using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMachine
{
    private BytecodeGameController _gameController;

    private Stack<int> _stackMachine = new Stack<int>();

    private const int MAX_STACK = 128;

    public VirtualMachine(BytecodeGameController gameController)
    {
        _gameController = gameController;
    }

    public void Interpret(int[] bytecode)
    {
        _stackMachine.Clear();

        for(int i = 0; i < bytecode.Length; i++)
        {
            Instruction instruction = (Instruction)bytecode[i];

            switch (instruction)
            {
                case Instruction.INST_SET_HEALTH:
                {
                    //Be aware with the order here
                    //Since we push "amount" after "wizard" onto the stack, we need to pop "amount" first
                    int amount = _stackMachine.Pop();
                    int wizard = _stackMachine.Pop();

                    _gameController.SetHealth(wizard, amount);

                    break;
                }
                case Instruction.INST_LITERAL:
                {
                    Push(bytecode[++i]);

                    break;
                }
                case Instruction.INST_GET_HEALTH:
                {
                    int wizard = _stackMachine.Pop();

                    Push(_gameController.GetHealth(wizard));

                    break;
                }
                case Instruction.INST_ADD:
                {
                    int a = _stackMachine.Pop();
                    int b = _stackMachine.Pop();

                    Push(a + b);

                    break;
                }
            }
        }
    }

    //A dedicated Push method to be aware of (and do something about) a possible stack overflow
    private void Push(int number)
    {
        if(_stackMachine.Count + 1 > MAX_STACK)
        {
            Debug.LogError("Stack overflow!");
        }

        _stackMachine.Push(number);
    }
}
