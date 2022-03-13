using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageCommand : ICommand
{
    private static CommandInvoker commandInvoker;
    private static HealthManager healthManager;
    
    public static void SetUp(CommandInvoker _commandInvoker, HealthManager _healthManager)
    {
        commandInvoker = _commandInvoker;
        healthManager = _healthManager;
    }

    public void Execute()
    {
        commandInvoker.TakeDamage();
        healthManager.TakeDamage();
    }
}
