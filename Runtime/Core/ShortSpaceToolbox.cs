namespace Eloi
{
    public static class ShortSpaceToolbox {


    #region CONST
    public static readonly short MAX_RADIUS_IN_MM = short.MaxValue;
    public static readonly short MIN_RADIUS_IN_MM = short.MinValue;
    public static readonly float MAX_RADIUS_IN_METER = short.MaxValue / 1000f;
    public static readonly float MIN_RADIUS_IN_METER = short.MinValue / 1000f;
    public static readonly short RADIUS_IN_MM = short.MaxValue;
    public static readonly float RADIUS_IN_METER = short.MaxValue / 1000f;
    public static readonly ushort DIAMETER_IN_MM = ushort.MaxValue;
    public static readonly float DIAMETER_IN_METER = ushort.MaxValue / 1000f;
    public static readonly float MM_TO_METER = 1f / 1000f;
    public static readonly float METER_TO_MM =  1000f;
    public static readonly double METER_TO_MM_DOUBLE =  1000.0;
    public static readonly decimal METER_TO_MM_DECIMAL =  1000.0m;
    #endregion


    public static void ClampIn32767(ref int value)
    {
        if (value > short.MaxValue)
            value = short.MaxValue;
        else if (value < short.MinValue)
            value = short.MinValue;
    }
    public static void ClampIn32767(ref short value)
    {
        if (value > short.MaxValue)
            value = short.MaxValue;
        else if (value < short.MinValue)
            value = short.MinValue;
    }
    
    public static void ClampIn32Meter767mm(ref float value)
    {
        if (value > MAX_RADIUS_IN_METER)
            value = MAX_RADIUS_IN_METER;
        else if (value < MIN_RADIUS_IN_METER)
            value = MIN_RADIUS_IN_METER;
    }
    public static void SetInValueInMillimeterClamped(ref short value, short newValueInMillimeter)
    {
        ClampIn32767(ref newValueInMillimeter);
        value = newValueInMillimeter;
    }
    public static void SetInValueInMeterClamped(ref short value, float newValueInMeter)
    {
        ClampIn32Meter767mm(ref newValueInMeter);
        value = (short)(newValueInMeter * 1000);
    }

    public static float GetInMeterFromShortMillimeter(in short valueInMillimeter)
    {
        return valueInMillimeter / 1000f;
    }
}
}