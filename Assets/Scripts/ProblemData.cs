using System;
using System.Collections.Generic;

[Serializable]
public class ProblemData
{
    public Problem type;
    public Dictionary<int, bool> levels;
    public Dictionary<int, int> levelsSpawnCount;

    public ProblemData(Problem type)
    {
        this.type = type;
        this.levels = new Dictionary<int, bool>();
        this.levelsSpawnCount = new Dictionary<int, int>();
    }
}
