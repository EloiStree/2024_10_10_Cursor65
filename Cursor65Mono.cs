using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor65Mono : MonoBehaviour
{
    public Transform m_whatToMove;
    public Cursor65 m_cursorValue;

    [Header("Just for learning")]
    public ushort m_radius = (ushort) short.MaxValue;
    public ushort m_diameter = ushort.MaxValue;

    public void Reset()
    {
        m_whatToMove= transform; 
    }


    public void Update()
    {
        Refresh();
    }

    [ContextMenu("Refresh")]
    public void Refresh() {
        if (m_whatToMove == null)
            return;

        m_whatToMove.position =
            new Vector3(m_cursorValue.m_x / 1000f,
            m_cursorValue.m_y / 1000f,
            m_cursorValue.m_z / 1000f);

    }
}

[System.Serializable]
public class Cursor65
{
    [Range(short.MinValue, short.MaxValue)]
    public short m_x;
    [Range(short.MinValue, short.MaxValue)]
    public short m_y;
    [Range(short.MinValue, short.MaxValue)]
    public short m_z;

    public const float METER_TO_MM = 1000f;
    public const float MM_TO_METER = 1f/1000f;
    public const float MAX_RADIUS_IN_METER =
        short.MaxValue * MM_TO_METER;


    public static float ClampFloatGiven(in float toClamp,
        in float min, in float max) {
        return Mathf.Clamp(toClamp, min, max);
    }
    public static Vector3 ClampVector3Given(in Vector3 toClamp,
        in float min, in float max) {
        return new Vector3(
            ClampFloatGiven(in toClamp.x,in min, in max),
            ClampFloatGiven(in toClamp.y, in min, in max),
            ClampFloatGiven(in toClamp.z, in min, in max));
    }


    public static Vector3 ClampAt32Meters(in Vector3 toClamp){
        return ClampVector3Given(in toClamp,
            -MAX_RADIUS_IN_METER,
            MAX_RADIUS_IN_METER);
        ///-MAX_RADIUS_IN_METER=-32767
        ///MAX_RADIUS_IN_METER =32767
    }
    public const float MAX_RADIUS_IN_MM = short.MaxValue;
    public static void ClampAt32767mm(
        ref short x,
        ref short y,
        ref short z) { 
        x = (short)ClampFloatGiven( x, -MAX_RADIUS_IN_MM,
            MAX_RADIUS_IN_MM);
        y = (short)ClampFloatGiven( y, -MAX_RADIUS_IN_MM,
            MAX_RADIUS_IN_MM);
        z = (short)ClampFloatGiven( z, -MAX_RADIUS_IN_MM,
            MAX_RADIUS_IN_MM);
    
    }


    public void Add(Vector3 valueToAddInMeter) {

        float x = m_x * MM_TO_METER + valueToAddInMeter.x ;
        float y = m_y * MM_TO_METER + valueToAddInMeter.y ;
        float z = m_z * MM_TO_METER + valueToAddInMeter.z;
       m_x=(short)(
            ClampFloatGiven(x,
            -MAX_RADIUS_IN_METER,
            MAX_RADIUS_IN_METER)
            * METER_TO_MM);
       m_y=(short)( ClampFloatGiven(y, -MAX_RADIUS_IN_METER, MAX_RADIUS_IN_METER)* METER_TO_MM);
       m_z=(short)( ClampFloatGiven(z, -MAX_RADIUS_IN_METER, MAX_RADIUS_IN_METER)* METER_TO_MM);
    }

}
