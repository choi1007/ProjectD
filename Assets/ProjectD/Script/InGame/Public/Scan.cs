using UnityEngine;

public class Scan 
{
    private float ScanFrequency;
    private float ScanInterval { get { return 1.0f / ScanFrequency; } }
    private float ScanTimer;

    public void InitScan(float _frequency)
    {
        ScanFrequency = _frequency;
    }

    public bool ScanCheck()
    {
        ScanTimer -= Time.deltaTime;
        if(ScanTimer < 0)
        {
            ScanTimer += ScanInterval;
            return true;
        }
        return false;
    }
}
