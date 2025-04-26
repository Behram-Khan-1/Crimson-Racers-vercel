using System.Collections.Generic;
[System.Serializable]
public class RaceAPIResponse
{
    public string status;
    public RaceResult result;
}

[System.Serializable]
public class RaceResult
{
    public string _id;
    public string rid;
    public List<int> hids;
    public string race_name;
    public int rgate;
    public string start_time;
    public string status;
    public string end_time;
    public List<Racer> racers;
}

[System.Serializable]
public class Racer
{
    public int hid;
    public int pos;
    public float time;
    public string name;
}
