using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VelocityInZone
{
    public HeroTypes ZoneType;
    public Vector3 Speed;
}
public class Hero : MonoBehaviour
{
    public HeroTypes HeroType;

    public List<VelocityInZone> VelocityInZones;

    public Vector3 GetSpeedByZone(HeroTypes zoneType)
    {
        foreach (var zone in VelocityInZones)
        {
            if (zone.ZoneType == zoneType)
                return zone.Speed;
        }

        return Vector3.zero;
    }
}
