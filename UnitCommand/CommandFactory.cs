using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandFactory {
    private static CommandFactory instance;
    private CommandFactory() {

    }

    public static CommandFactory GetInstance() {
        if (instance == null) {
            instance = new CommandFactory();
        }

        return instance;
    }

    public Command CreateCommand(PlayerOrders playerOrder) {
        return playerOrder switch
        {
            PlayerOrders.Attack => new AttackCmd(),
            PlayerOrders.Guard => new GuardCmd(),
            PlayerOrders.Move => new MoveCmd(),
            PlayerOrders.Patrol => new PatrolCmd(),
            PlayerOrders.Retreat => new RetreatCmd(),
            _ => null,
        };
    }
}