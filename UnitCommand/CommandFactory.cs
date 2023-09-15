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

    public Command CreateCommand(PlayerOrders playerOrder, Vector2Int target, double radius) {
        return playerOrder switch
        {
            PlayerOrders.Attack => new AttackCmd(target, radius),
            PlayerOrders.Guard => new GuardCmd(target, radius),
            PlayerOrders.Move => new MoveCmd(target, radius),
            PlayerOrders.Patrol => new PatrolCmd(target, radius),
            PlayerOrders.Retreat => new RetreatCmd(target, radius),
            _ => null,
        };
    }
}