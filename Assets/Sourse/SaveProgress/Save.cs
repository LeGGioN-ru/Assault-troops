using System;

[Serializable]
public class Save 
{
    public int Level;
    public bool IsShowTrainingFirstLevel = false;

    public Save(int level, bool showTrainigFirstLevel)
    {
        Level = level;
        IsShowTrainingFirstLevel = showTrainigFirstLevel;
    }
}