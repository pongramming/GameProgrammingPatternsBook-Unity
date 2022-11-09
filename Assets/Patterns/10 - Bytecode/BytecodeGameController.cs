using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BytecodeGameController : MonoBehaviour
{
    private void Start()
    {
        TestBytecodePattern();
    }

    public void TestBytecodePattern()
    {
        int[] bytecode = new int[]
        {
            (int)Instruction.INST_LITERAL, 0, //Instruction and number representing the wizard
            (int)Instruction.INST_LITERAL, 20, //Instruction and number representing the amount
            (int)Instruction.INST_SET_HEALTH
        };

        VirtualMachine vm = new VirtualMachine(this);

        vm.Interpret(bytecode);
    }

    public void SetHealth(int wizard, int amount)
    {
        Debug.Log($"Setting wizard {wizard}'s health to {amount}");
    }

    public void SetWisdom(int wizard, int amount)
    {
        Debug.Log($"Setting wizard {wizard}'s wisdom to {amount}");
    }

    public void SetAgility(int wizard, int amount)
    {
        Debug.Log($"Setting wizard {wizard}'s agility to {amount}");
    }

    public void PlaySound(int sound)
    {
        Debug.Log($"Playing (hypothetical) sound {sound}");
    }

    public void SpawnParticle(int particle)
    {
        Debug.Log($"Spawning (hypothetical) particle {particle}");
    }

    public int GetHealth(int wizard)
    {
        return 200;
    }
}
