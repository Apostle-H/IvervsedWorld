using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorldCommand : ICommand
{
    private static Transform level;
    private static Transform player;

    public static void SetUp(Transform _level, Transform _player)
    {
        level = _level;
        player = _player;
    }

    public void Execute()
    {
        level.RotateAround(player.position, new Vector3(0, 0, 1), -90);
    }
}
