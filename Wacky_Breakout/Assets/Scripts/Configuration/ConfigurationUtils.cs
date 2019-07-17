using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtils
{
    private static ConfigurationData configData;

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configData.BallImpulseForce; }
    }

    public static float BallLifeTime
    {
        get { return configData.BallLifeTime; }
    }

    public static float BallMovingDelay
    {
        get { return configData.BallMovingDelay; }
    }

    public static float NewBallMaxTimeSpawn
    {
        get { return configData.NewBallMaxTimeSpawn; }
    }

    public static float NewBallMinTimeSpawn
    {
        get { return configData.NewBallMinTimeSpawn; }
    }

    public static float StandartBlockPoint
    {
        get { return configData.StandartBlockPoint; }
    }

    public static float BonusBlockPoint
    {
        get { return configData.BonusBlockPoint; }
    }

    public static float PickUpBlockPoint
    {
        get { return configData.PickUpBlockPoint; }
    }

    public static int StandartBlockProbability
    {
        get { return configData.StandartBlockProbability; }
    }

    public static int BonusBlockProbability
    {
        get { return configData.BonusBlockProbability; }
    }

    public static int FreezeBlockProbability
    {
        get { return configData.FreezeBlockProbability; }
    }

    public static int SpeedupBlockProbability
    {
        get { return configData.SpeedupBlockProbability; }
    }

    public static float BallsPerGame
    {
        get { return configData.BallsPerGame; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configData = new ConfigurationData();
    }
}
