using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigurationData : MonoBehaviour
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float ballLifeTime = 10;
    static float ballMovingDelay = 1;
    static float newBallMaxTimeSpawn = 10;
    static float newBallMinTimeSpawn = 5;
    static float standartBlockPoint = 5;
    static float bonusBlockPoint = 15;
    static float pickUpBlockPoint = 10;
    static int standartBlockProbability = 50;
    static int bonusBlockProbability = 40;
    static int freezeBlockProbability = 15;
    static int speedupBlockProbability = 15;
    static float ballsPerGame = 30;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }
    }

    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    public float BallMovingDelay
    {
        get { return ballMovingDelay; }
    }

    public float NewBallMaxTimeSpawn
    {
        get { return newBallMaxTimeSpawn; }
    }

    public float NewBallMinTimeSpawn
    {
        get { return newBallMinTimeSpawn; }
    }

    public float StandartBlockPoint
    {
        get { return standartBlockPoint; }
    }

    public float BonusBlockPoint
    {
        get { return bonusBlockPoint; }
    }

    public float PickUpBlockPoint
    {
        get { return pickUpBlockPoint; }
    }

    public int StandartBlockProbability
    {
        get { return standartBlockProbability; }
    }

    public int BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }

    public int FreezeBlockProbability
    {
        get { return freezeBlockProbability; }
    }

    public int SpeedupBlockProbability
    {
        get { return speedupBlockProbability; }
    }

    public float BallsPerGame
    {
        get { return ballsPerGame; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>

    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = int.Parse(values[1]);
        ballLifeTime = int.Parse(values[2]);
        ballMovingDelay = int.Parse(values[3]);
        newBallMaxTimeSpawn = int.Parse(values[4]);
        newBallMinTimeSpawn = int.Parse(values[5]);
        standartBlockPoint = int.Parse(values[6]);
        bonusBlockPoint = int.Parse(values[7]);
        pickUpBlockPoint = int.Parse(values[8]);
        standartBlockProbability = int.Parse(values[9]);
        bonusBlockProbability = int.Parse(values[10]);
        freezeBlockProbability = int.Parse(values[11]);
        speedupBlockProbability = int.Parse(values[12]);
        ballsPerGame = int.Parse(values[13]);
    }

    #endregion
}
