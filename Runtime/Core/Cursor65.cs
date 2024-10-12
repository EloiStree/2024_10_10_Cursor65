using System;
using UnityEngine;


namespace Eloi
{
    /// Reminder:
    /// You can tell that a piece of code was written by someone who really cared
    /// because it always seems to work right, and it's easy to understand.


    /// <summary>
    /// <br/>
    /// Documentation: <a href="https://github.com/EloiStree/2024_10_10_Cursor65">Click here for documentation</a>
    /// <br/>
    /// ![Image Representation](https://avatars.githubusercontent.com/u/20149493?s=400&u=3f3c9e84bec37d51edfbb88659b0da1f2c58518e&v=4)
    /// </summary>
    [System.Serializable]
sealed public class Cursor65 : I_Cursor65, IEquatable<Cursor65>
{

    #region VARIABLES
    #region XYZ
    [Range(short.MinValue, short.MaxValue)]
    [Tooltip("World space value left to right in millimeters from -short(32767 to short(32767)")]
    [SerializeField] short m_x;
    [Range(short.MinValue, short.MaxValue)]
    [Tooltip("World space value up and down in millimeters from -short(32767 to short(32767)")]
    [SerializeField] public short m_y;
    [Range(short.MinValue, short.MaxValue)]
    [Tooltip("World space value forward and backward in millimeters from -short(32767 to short(32767)")]
    [SerializeField] short m_z;
    #endregion


    #endregion

    #region SET GET FROM OTHER I_CUSROR65
    public void SetFrom(in I_Cursor65 cursor)
    {
        MillimeterX = cursor.MillimeterX;
        MillimeterY = cursor.MillimeterY;
        MillimeterZ = cursor.MillimeterZ;
    }
    public void GetTo(ref I_Cursor65 cursor)
    {
        cursor.MillimeterX = MillimeterX;
        cursor.MillimeterY = MillimeterY;
        cursor.MillimeterZ = MillimeterZ;
    }
    public void GetAs(out I_Cursor65 cursor)
    {
        I_Cursor65 cursor65 = new Cursor65();
        cursor65.SetFrom(this);
        cursor = cursor65;
    }



    #endregion


    #region CLAMP
    public static void ClampMM(short value, short min, short max, out short millimeter)
    {
        if (value < min)
            millimeter = min;
        else if (value > max)
            millimeter = max;
        else millimeter = value;
    }
    public static void ClampMM(short value, out short millimeter)
    {
        ClampMM(value, short.MinValue, short.MaxValue, out millimeter);
    }
    public static void ClampMM(int value, int min, int max, out short millimeter)
    {
        if (value < min)
            millimeter = (short)min;
        else if (value > max)
            millimeter = (short)max;
        else millimeter = (short)value;
    }
    public static void ClampMM(int value, out short millimeter)
    {
        ClampMM(value, short.MinValue, short.MaxValue, out millimeter);
    }

    public static void ClampFloatGiven(in float toClamp,
    in float min, in float max, out float clamped)
    {
        if (toClamp < min)
            clamped = min;
        else if (toClamp > max)
            clamped = max;
        else clamped = toClamp;
    }
    public static void ClampFloatGivenInShort(in float toClamp, out float clamped)
    {
        ClampFloatGiven(in toClamp, short.MinValue, short.MaxValue, out clamped);
    }
    public static void ClampVector3Given(in Vector3 toClamp,
        in float min, in float max, out Vector3 clamped)
    {
        ClampFloatGiven(in toClamp.x, in min, in max, out float x);
        ClampFloatGiven(in toClamp.y, in min, in max, out float y);
        ClampFloatGiven(in toClamp.z, in min, in max, out float z);
        clamped = new Vector3(x, y, z);
    }

    private void ClampAt32767mm(ref float x)
    {
        if (x > short.MaxValue)
            x = short.MaxValue;
        else if (x < short.MinValue)
            x = short.MinValue;
    }
    private void ClampAt32767mm(ref int x)
    {
        if (x > short.MaxValue)
            x = short.MaxValue;
        else if (x < short.MinValue)
            x = short.MinValue;
    }


    public static void ClampAt32Meters(ref Vector3 toClamp)
    {
        ClampVector3Given(in toClamp, ShortSpaceToolbox.MIN_RADIUS_IN_METER, ShortSpaceToolbox.MAX_RADIUS_IN_METER, out toClamp);
    }
    public static void ClampAt32767mm(
        ref short x,
        ref short y,
        ref short z)
    {
        ClampAt32767mm(ref x);
        ClampAt32767mm(ref y);
        ClampAt32767mm(ref z);
    }

    public static void ClampAt32767mm(ref short x)
    {
        if (x > short.MaxValue)
            x = short.MaxValue;
        else if (x < short.MinValue)
            x = short.MinValue;
    }

        
    public static void ClampAt32Meter767mm(ref float toClamp)
    {
        if (toClamp > ShortSpaceToolbox.MAX_RADIUS_IN_METER)
            toClamp = ShortSpaceToolbox.MAX_RADIUS_IN_METER;
        else if (toClamp < ShortSpaceToolbox.MIN_RADIUS_IN_METER)
            toClamp = ShortSpaceToolbox.MIN_RADIUS_IN_METER;
    }

    #endregion
    #region PROPERTY
    public short MillimeterX
    {
        get => GetXInMillimeter();
        set => SetXWithMillimeter(value);
    }
    public short MillimeterY
    {
        get => GetYInMillimeter();
        set => SetYWithMillimeter(value);
    }
    public short MillimeterZ
    {
        get => GetZInMillimeter();
        set => SetZWithMillimeter(value);
    }
    public float MeterX
    {
        get => GetXInMeter();
        set => SetXWithMeter(value);
    }
    public float MeterY
    {
        get => GetYInMeter();
        set => SetYWithMeter(value);
    }
    public float MeterZ
    {
        get => GetZInMeter();
        set => SetZWithMeter(value);
    }


    #endregion
    #region GET

    public void GetXInMeter(out float xInMeter) => xInMeter = m_x * ShortSpaceToolbox.MM_TO_METER;
    public void GetYInMeter(out float yInMeter) => yInMeter = m_y * ShortSpaceToolbox.MM_TO_METER;
    public void GetZInMeter(out float zInMeter) => zInMeter = m_z * ShortSpaceToolbox.MM_TO_METER;
    public void GetXInMillimeter(out short xInMM) => xInMM = m_x;
    public void GetYInMillimeter(out short yInMM) => yInMM = m_y;
    public void GetZInMillimeter(out short zInMM) => zInMM = m_z;
    public void GetPositionAsMeter(out Vector3 positionInMeter)
    {
        GetXInMeter(out float xInMeter);
        GetYInMeter(out float yInMeter);
        GetZInMeter(out float zInMeter);
        positionInMeter = new Vector3(xInMeter, yInMeter, zInMeter);
    }
    public void GetPositionAsMeterIn(ref Vector3 positionInMeter)
    {
        GetXInMeter(out positionInMeter.x);
        GetYInMeter(out positionInMeter.y);
        GetZInMeter(out positionInMeter.z);
    }

    public void GetPositionInMeter(ref float x, ref float y, ref float z)
    {
        GetXInMeter(out x);
        GetYInMeter(out y);
        GetZInMeter(out z);
    }

    public float GetXInMeter() { GetXInMeter(out float meter); return meter; }
    public float GetYInMeter() { GetYInMeter(out float meter); return meter; }
    public float GetZInMeter() { GetZInMeter(out float meter); return meter; }
    public short GetXInMillimeter() { GetXInMillimeter(out short mm); return mm; }
    public short GetYInMillimeter() { GetYInMillimeter(out short mm); return mm; }
    public short GetZInMillimeter() { GetZInMillimeter(out short mm); return mm; }
    public Vector3 GetPositionAsMeter()
    {
        GetPositionAsMeter(out Vector3 positionInMeter);
        return positionInMeter;
    }



    #endregion
    #region SET 
    #region 2D
    public void SetPositionMeterXZ(Vector2 positionInMeter)
    {
        SetXWithMeter(positionInMeter.x);
        SetZWithMeter(positionInMeter.y);
    }

    public void SetPositionMeterXZ(float xMeter, float zMeter)
    {
        SetXWithMeter(xMeter);
        SetZWithMeter(zMeter);

    }
    public void SetPositionMillimeterXZ(Vector2 positionInMM)
    {
        SetXWithMillimeter((short)positionInMM.x);
        SetZWithMillimeter((short)positionInMM.y);
    }
    public void SetPositionMillimeterXZ(int xMM, int zMM)
    {
        SetXWithMillimeter(xMM);
        SetZWithMillimeter(zMM);
    }
    #endregion
    #region 3D
    public void SetPositionMeterXYZ(Vector3 positionMeter)
    {
        SetXWithMeter(positionMeter.x);
        SetYWithMeter(positionMeter.y);
        SetZWithMeter(positionMeter.z);
    }
    public void SetPositionMeterXYZ(float xMeter, float yMeter, float zMeter)
    {
        SetXWithMeter(xMeter);
        SetYWithMeter(yMeter);
        SetZWithMeter(zMeter);
    }

    public void SetPositionMillimeterXYZ(Vector3 positionInMM)
    {
        SetXWithMillimeter((short)positionInMM.x);
        SetYWithMillimeter((short)positionInMM.y);
        SetZWithMillimeter((short)positionInMM.z);
    }
    public void SetPositionMillimeterXYZ(int xMM, int yMM, int zMM)
    {
        SetXWithMillimeter(xMM);
        SetYWithMillimeter(yMM);
        SetZWithMillimeter(zMM);
    }
    #endregion
    #region SET ONE AXIS AT TIME
    public void SetXWithMillimeter(int xMM) => ClampMM(xMM, out m_x);
    public void SetYWithMillimeter(int yMM) => ClampMM(yMM, out m_y);
    public void SetZWithMillimeter(int zMM) => ClampMM(zMM, out m_z);
    
    public void SetXWithMillimeter(short xMM) => ClampMM(xMM, out m_x);
    public void SetYWithMillimeter(short yMM) => ClampMM(yMM, out m_y);
    public void SetZWithMillimeter(short zMM) => ClampMM(zMM, out m_z);

    public void SetXWithMeter(float xMeter) { ParseMeterToClampShortInMM(xMeter, out m_x); }
    public void SetYWithMeter(float yMeter) { ParseMeterToClampShortInMM(yMeter, out m_y); }
    public void SetZWithMeter(float zMeter) { ParseMeterToClampShortInMM(zMeter, out m_z); }    

        #endregion
        #endregion

        #region PARSING

        public  static void ParseMeterToClampShortInMM(float valueInMeter, out short valueInMM)
        {
            ClampAt32Meter767mm(ref valueInMeter); 
            valueInMM = (short)(valueInMeter * ShortSpaceToolbox.METER_TO_MM);
        }

        #endregion
        #region ADD

        public void RemoveInMeter(Vector3 valueToRemoveInMeter)
    {
        valueToRemoveInMeter *= -1;
        AddInMeter(valueToRemoveInMeter);

    }

    public void AddInMeter(Vector3 valueToAddInMeter)
    {
        // Mush more readable than before.
        AddRightInMeter(valueToAddInMeter.x);
        AddUpInMeter(valueToAddInMeter.y);
        AddForwardInMeter(valueToAddInMeter.z);
    }
    public void AddInMillimeter(Vector3 valueToAddInMM)
    {
        ClampAt32767mm(ref valueToAddInMM.x);
        ClampAt32767mm(ref valueToAddInMM.y);
        ClampAt32767mm(ref valueToAddInMM.z);
        AddRightInMillimeter((short)valueToAddInMM.x);
        AddUpInMillimeter((short)valueToAddInMM.y);
        AddForwardInMillimeter((short)valueToAddInMM.z);
    }


    public void AddRightInMeter(float valueToAddInMeter)
    {
        GetXInMeter(out float xInMeter);
        xInMeter += valueToAddInMeter;
        ClampAt32Meter767mm(ref xInMeter);
        SetXWithMeter(xInMeter);
    }
    public void AddUpInMeter(float valueToAddInMeter)
    {
        GetYInMeter(out float yInMeter);
        yInMeter += valueToAddInMeter;
        ClampAt32Meter767mm(ref yInMeter);
        SetYWithMeter(yInMeter);
    }
    public void AddForwardInMeter(float valueToAddInMeter)
    {
        GetZInMeter(out float zInMeter);
        zInMeter += valueToAddInMeter;
        ClampAt32Meter767mm(ref zInMeter);
        SetZWithMeter(zInMeter);
    }

    public void AddRightInMillimeter(short valueToAddInMM)
    {
        GetXInMillimeter(out short xInMM);
        int x = xInMM + valueToAddInMM;
        ClampAt32767mm(ref x);
        SetXWithMillimeter((short)x);
    }
    public void AddUpInMillimeter(short valueToAddInMM)
    {
        GetYInMillimeter(out short yInMM);
        int y = yInMM + valueToAddInMM;
        ClampAt32767mm(ref y);
        SetYWithMillimeter((short)y);
    }
    public void AddForwardInMillimeter(short valueToAddInMM)
    {
        GetZInMillimeter(out short zInMM);
        int z = zInMM + valueToAddInMM;
        ClampAt32767mm(ref z);
        SetZWithMillimeter((short)z);
    }

    public void AddLeftInMeter(float valueToAddInMeter)
    {
        AddRightInMeter(-valueToAddInMeter);
    }
    public void AddDownInMeter(float valueToAddInMeter)
    {
        AddUpInMeter(-valueToAddInMeter);
    }
    public void AddBackwardInMeter(float valueToAddInMeter)
    {
        AddForwardInMeter(-valueToAddInMeter);
    }
    public void AddLeftInMillimeter(short valueToAddInMM)
    {
        AddRightInMillimeter((short)-valueToAddInMM);
    }
    public void AddDownInMillimeter(short valueToAddInMM)
    {
        AddUpInMillimeter((short)-valueToAddInMM);
    }
    public void AddBackwardInMillimeter(short valueToAddInMM)
    {
        AddForwardInMillimeter((short)-valueToAddInMM);
    }
    #endregion


    #region TO STRING
    public override string ToString()
    {
        return $"(mm X:{m_x} Y:{m_y} Z:{m_z})";
    }
    #endregion

    #region CONSTRUCTOR
    public Cursor65()
    {
        m_x = 0;
        m_y = 0;
        m_z = 0;
    }
    public Cursor65(short x, short y, short z)
    {
        m_x = x;
        m_y = y;
        m_z = z;
    }
    public Cursor65(Vector3 positionInMeter)
    {
        SetPositionMeterXYZ(positionInMeter);
    }
    public Cursor65(float xMeter, float yMeter, float zMeter)
    {
        SetPositionMeterXYZ(xMeter, yMeter, zMeter);
    }
    public Cursor65(Vector2 positionInMeter)
    {
        SetPositionMeterXZ(positionInMeter);
    }
    public Cursor65(float xMeter, float zMeter)
    {
        SetPositionMeterXZ(xMeter, zMeter);
    }
    
    #endregion

    #region OPERATOR
    public static Cursor65 operator +(Cursor65 a, Cursor65 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMillimeterXYZ(a.GetXInMillimeter() + b.GetXInMillimeter(),
            a.GetYInMillimeter() + b.GetYInMillimeter(),
            a.GetZInMillimeter() + b.GetZInMillimeter());
        return result;
    }
    public static Cursor65 operator -(Cursor65 a, Cursor65 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMillimeterXYZ(a.GetXInMillimeter() - b.GetXInMillimeter(),
            a.GetYInMillimeter() - b.GetYInMillimeter(),
            a.GetZInMillimeter() - b.GetZInMillimeter());
        return result;
    }
    public static Cursor65 operator *(Cursor65 a, Cursor65 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMillimeterXYZ(a.GetXInMillimeter() * b.GetXInMillimeter(),
            a.GetYInMillimeter() * b.GetYInMillimeter(),
            a.GetZInMillimeter() * b.GetZInMillimeter());
        return result;
    }
    public static Cursor65 operator /(Cursor65 a, Cursor65 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMillimeterXYZ(a.GetXInMillimeter() / b.GetXInMillimeter(),
            a.GetYInMillimeter() / b.GetYInMillimeter(),
            a.GetZInMillimeter() / b.GetZInMillimeter());
        return result;
    }
    public static Cursor65 operator +(Cursor65 a, Vector3 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(a.GetXInMeter() + b.x,
            a.GetYInMeter() + b.y,
            a.GetZInMeter() + b.z);
        return result;
    }
    public static Cursor65 operator -(Cursor65 a, Vector3 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(a.GetXInMeter() - b.x,
            a.GetYInMeter() - b.y,
            a.GetZInMeter() - b.z);
        return result;
    }
    public static Cursor65 operator *(Cursor65 a, Vector3 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(a.GetXInMeter() * b.x,
            a.GetYInMeter() * b.y,
            a.GetZInMeter() * b.z);
        return result;
    }
    public static Cursor65 operator /(Cursor65 a, Vector3 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(a.GetXInMeter() / b.x,
            a.GetYInMeter() / b.y,
            a.GetZInMeter() / b.z);
        return result;
    }
    
    public static Cursor65 operator +(Cursor65 a, float b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(a.GetXInMeter() + b,
            a.GetYInMeter() + b,
            a.GetZInMeter() + b);
        return result;
    }
    public static Cursor65 operator -(Cursor65 a, float b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(a.GetXInMeter() - b,
            a.GetYInMeter() - b,
            a.GetZInMeter() - b);
        return result;
    }
    public static Cursor65 operator *(Cursor65 a, float b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(
            a.GetXInMeter() * b,
            a.GetYInMeter() * b,
            a.GetZInMeter() * b);
        return result;
    }
    public static Cursor65 operator /(Cursor65 a, float b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(
            a.GetXInMeter() / b,
            a.GetYInMeter() / b,
            a.GetZInMeter() / b);
        return result;
    }

    public static Cursor65 operator %(Cursor65 a, Cursor65 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMillimeterXYZ(
            a.GetXInMillimeter() % b.GetXInMillimeter(),
            a.GetYInMillimeter() % b.GetYInMillimeter(),
            a.GetZInMillimeter() % b.GetZInMillimeter());
        return result;
    }
    public static Cursor65 operator %(Cursor65 a, Vector3 b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(
            a.GetXInMeter() % b.x,
            a.GetYInMeter() % b.y,
            a.GetZInMeter() % b.z);
        return result;
    }

    public static Cursor65 operator %(Cursor65 a, float b)
    {
        Cursor65 result = new Cursor65();
        result.SetPositionMeterXYZ(
            a.GetXInMeter() % b,
            a.GetYInMeter() % b,
            a.GetZInMeter() % b);
        return result;
    }

    public static bool operator ==(Cursor65 a, Cursor65 b)
    {
        try { return a.Equals(b); }
        catch { return false; }
        
    }
    public static bool operator !=(Cursor65 a, Cursor65 b)
    {
        try { return !a.Equals(b); }
        catch { return false; }

    }

    // MAKE NO SENSE TO ADD THIS BUT FOR THE LEARNING PURPOSE
    //public static bool operator >(Cursor65 a, Cursor65 b)
    //{
    //    return a.GetXInMillimeter() > b.GetXInMillimeter() &&
    //        a.GetYInMillimeter() > b.GetYInMillimeter() &&
    //        a.GetZInMillimeter() > b.GetZInMillimeter();
    //}
    //public static bool operator <(Cursor65 a, Cursor65 b)
    //{
    //    return a.GetXInMillimeter() < b.GetXInMillimeter() &&
    //        a.GetYInMillimeter() < b.GetYInMillimeter() &&
    //        a.GetZInMillimeter() < b.GetZInMillimeter();
    //}
    //public static bool operator >=(Cursor65 a, Cursor65 b)
    //{
    //    return a.GetXInMillimeter() >= b.GetXInMillimeter() &&
    //        a.GetYInMillimeter() >= b.GetYInMillimeter() &&
    //        a.GetZInMillimeter() >= b.GetZInMillimeter();
    //}

    //public static bool operator <=(Cursor65 a, Cursor65 b)
    //{
    //    return a.GetXInMillimeter() <= b.GetXInMillimeter() &&
    //        a.GetYInMillimeter() <= b.GetYInMillimeter() &&
    //        a.GetZInMillimeter() <= b.GetZInMillimeter();
    //}


    /// <summary>
    ///  This operator - is for the unary minus. It means that it will return the negative value of the cursor.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Cursor65 operator -(Cursor65 a)
    {
        return new Cursor65(-a.GetXInMeter(), -a.GetYInMillimeter(), -a.GetZInMillimeter());
    }

    /// <summary>
    ///  This operator + is for the unary plus. It means that it will return the same value of the cursor.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Cursor65 operator +(Cursor65 a)
    {
        return new Cursor65(a.GetXInMeter(), a.GetYInMillimeter(), a.GetZInMillimeter());
    }


    /// <summary>
    ///  this operator ++ is for the prefix increment. It means that it will increment the value of the cursor by 1 meter.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Cursor65 operator ++(Cursor65 a)
    {
        return new Cursor65(a.GetXInMeter() + 1, a.GetYInMeter() + 1, a.GetZInMeter() + 1);
    }

    /// <summary>
    ///  this operator -- is for the prefix decrement. It means that it will decrement the value of the cursor by 1 meter.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Cursor65 operator --(Cursor65 a)
    {
        return new Cursor65(a.GetXInMeter() - 1, a.GetYInMeter() - 1, a.GetZInMeter() - 1);
    }



    // Indexer for accessing coordinates
    public short this[int index]
    {
        get
        {
            return index switch
            {
                0 => m_x,
                1 => m_y,
                2 => m_z,
                _ => throw new IndexOutOfRangeException("Index must be 0, 1, or 2.")
            };
        }
        set
        {
            switch (index)
            {
                case 0:
                    m_x = value;
                    break;
                case 1:
                    m_y = value;
                    break;
                case 2:
                    m_z = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Index must be 0, 1, or 2.");
            }
        }
    }

    // Logical true operator
    public static bool operator true(Cursor65 cursor)
    {
        return cursor.m_x != 0 || cursor.m_y != 0 || cursor.m_z != 0;
    }

    // Logical false operator
    public static bool operator false(Cursor65 cursor)
    {
        return cursor.m_x == 0 && cursor.m_y == 0 && cursor.m_z == 0;
    }
    // Implicit conversion to Vector2 (ignoring z)
    public static implicit operator Vector2(Cursor65 cursor)
    {
        return new Vector2(cursor.m_x, cursor.m_z);
    }

    // Implicit conversion to Vector3
    public static implicit operator Vector3(Cursor65 cursor)
    {
        return new Vector3(cursor.m_x, cursor.m_y, cursor.m_z);
    }

    #endregion

    #region UNSTORE

    public void GetMagnitudeInMeter(out float magnitudeInMeter)
    {
        GetPositionAsMeter(out Vector3 positionInMeter);
        magnitudeInMeter = positionInMeter.magnitude;
    }
    public void GetMagnitudeInMillimeter(out float magnitudeInMM)
    {
        GetPositionAsMeter(out Vector3 positionInMeter);
        magnitudeInMM = positionInMeter.magnitude * 1000;
    }

    public void GetDistanceInMeter(in Cursor65 cursor, out float distanceInMeter)
    {
        GetPositionAsMeter(out Vector3 positionInMeter);
        cursor.GetPositionAsMeter(out Vector3 cursorPositionInMeter);
        distanceInMeter = Vector3.Distance(positionInMeter, cursorPositionInMeter);
    }
    public void GetDistanceInMillimeter(in Cursor65 cursor, out float distanceInMM)
    {
        GetPositionAsMeter(out Vector3 positionInMeter);
        cursor.GetPositionAsMeter(out Vector3 cursorPositionInMeter);
        distanceInMM = Vector3.Distance(positionInMeter, cursorPositionInMeter) * 1000;
    }




    #endregion


    #region COMPARE

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        Cursor65 cursor = (Cursor65)obj;
        return GetXInMillimeter() == cursor.GetXInMillimeter() &&
            GetYInMillimeter() == cursor.GetYInMillimeter() &&
            GetZInMillimeter() == cursor.GetZInMillimeter();
    }
    public override int GetHashCode()
    {
        return (m_x << 16) ^ (m_y << 8) ^ m_z;
        //Source: https://chatgpt.com/share/6708541c-dda4-800e-94b0-c5564a15d3a9
        //More : https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
    }

    /// <summary>
    /// IEquatable Interface
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Cursor65 other)
    {
        if(other==null)
            return false;

        return GetXInMillimeter() == other.GetXInMillimeter() &&
            GetYInMillimeter() == other.GetYInMillimeter() &&
            GetZInMillimeter() == other.GetZInMillimeter();
    }

    #endregion

    #region OTHER NICE FUNCTION
    public void ResetToZero()
    {
        m_x = 0;
        m_y = 0;
        m_z = 0;
    }
    public Cursor65 Clone()
    {
        return new Cursor65(GetXInMillimeter(), GetYInMillimeter(), GetZInMillimeter());
    }


    #endregion

    #region CORNER AND SPACE
    public static void GetFrontTopLeftCorner(out Cursor65 corner)=>
        corner = new Cursor65(short.MinValue, short.MaxValue, short.MaxValue);
    public static void GetFrontTopRightCorner(out Cursor65 corner) =>
        corner = new Cursor65(short.MaxValue, short.MaxValue, short.MaxValue);
    public static void GetFrontBottomLeftCorner(out Cursor65 corner) => 
        corner = new Cursor65(short.MinValue, short.MinValue, short.MaxValue);
    public static void GetFrontBottomRightCorner(out Cursor65 corner) =>
        corner = new Cursor65(short.MaxValue, short.MinValue, short.MaxValue);
    
    public static void GetBackTopLeftCorner(out Cursor65 corner) =>
        corner = new Cursor65(short.MinValue, short.MaxValue, short.MinValue);
    public static void GetBackTopRightCorner(out Cursor65 corner) =>
        corner = new Cursor65(short.MaxValue, short.MaxValue, short.MinValue);
    public static void GetBackBottomLeftCorner(out Cursor65 corner) =>
        corner = new Cursor65(short.MinValue, short.MinValue, short.MinValue);
    public static void GetBackBottomRightCorner(out Cursor65 corner) =>
        corner = new Cursor65(short.MaxValue, short.MinValue, short.MinValue);

    public static void GetFront(out Cursor65 front) =>
        front = new Cursor65(0, 0, short.MaxValue);
    public static void GetBack(out Cursor65 back) =>
        back = new Cursor65(0, 0, short.MinValue);
    public static void GetTop(out Cursor65 top) =>
        top = new Cursor65(0, short.MaxValue, 0);
    public static void GetBottom(out Cursor65 bottom) =>
        bottom = new Cursor65(0, short.MinValue, 0);
    public static void GetLeft(out Cursor65 left) =>
        left = new Cursor65(short.MinValue, 0, 0);
    public static void GetRight(out Cursor65 right) =>
        right = new Cursor65(short.MaxValue, 0, 0);

    public static void GetCenter(out Cursor65 center) =>
        center = new Cursor65(0, 0, 0);

    public static void GetFrontTop(out Cursor65 frontTop) =>
        frontTop = new Cursor65(0, short.MaxValue, short.MaxValue);
    public static void GetFrontBottom(out Cursor65 frontBottom) =>
        frontBottom = new Cursor65(0, short.MinValue, short.MaxValue);

    public static void GetBackTop(out Cursor65 backTop) =>
        backTop = new Cursor65(0, short.MaxValue, short.MinValue);
    public static void GetBackBottom(out Cursor65 backBottom) =>
        backBottom = new Cursor65(0, short.MinValue, short.MinValue);

    public static void GetLeftTop(out Cursor65 leftTop) =>
        leftTop = new Cursor65(short.MinValue, short.MaxValue, 0);
    public static void GetLeftBottom(out Cursor65 leftBottom) =>
        leftBottom = new Cursor65(short.MinValue, short.MinValue, 0);

    public static void GetRightTop(out Cursor65 rightTop) =>
        rightTop = new Cursor65(short.MaxValue, short.MaxValue, 0);
    public static void GetRightBottom(out Cursor65 rightBottom) =>
        rightBottom = new Cursor65(short.MaxValue, short.MinValue, 0);
    #endregion


    #region SET WITH ALL PRIMITIVE

    public void SetAsMillimeter(short x, short y, short z) => SetPositionMillimeterXYZ(x, y, z);
    public void SetAsMillimeter(int x, int y, int z) => SetPositionMillimeterXYZ(x, y, z);
    public void SetAsMillimeter(bool x, bool y, bool z) =>
        SetPositionMillimeterXYZ(x ? short.MaxValue : short.MinValue, y ? short.MaxValue : short.MinValue, z ? short.MaxValue : short.MinValue);
    public void SetAsMillimeter(float x, float y, float z) => SetPositionMillimeterXYZ((int)x, (int)y, (int)z);
    public void SetAsMillimeter(double x, double y, double z) => SetPositionMillimeterXYZ((int)x, (int)y, (int)z);
    public void SetAsMillimeter(Vector3 positionInMM) => SetPositionMillimeterXYZ((int)positionInMM.x, (int)positionInMM.y, (int)positionInMM.z);
    public void SetAsMillimeter(Vector2 positionInMM) => SetPositionMillimeterXZ((int)positionInMM.x, (int)positionInMM.y);
    public void SetAsMillimeter(ushort x, ushort y, ushort z) => SetPositionMillimeterXYZ(x, y, z);

    // Remaining primitives
    public void SetAsMillimeter(byte x, byte y, byte z) => SetPositionMillimeterXYZ(x, y, z);
    public void SetAsMillimeter(sbyte x, sbyte y, sbyte z) => SetPositionMillimeterXYZ(x, y, z);
    public void SetAsMillimeter(long x, long y, long z) => SetPositionMillimeterXYZ((int)x, (int)y, (int)z);
    public void SetAsMillimeter(ulong x, ulong y, ulong z) => SetPositionMillimeterXYZ((int)x, (int)y, (int)z);
    public void SetAsMillimeter(decimal x, decimal y, decimal z) => SetPositionMillimeterXYZ((int)x, (int)y, (int)z);

    #endregion



    #region RANDOMIZE
    public void Randomize()
    {
        m_x = (short)UnityEngine.Random.Range(short.MinValue, short.MaxValue);
        m_y = (short)UnityEngine.Random.Range(short.MinValue, short.MaxValue);
        m_z = (short)UnityEngine.Random.Range(short.MinValue, short.MaxValue);
    }
    public void RandomizeX() => m_x = (short)UnityEngine.Random.Range(short.MinValue, short.MaxValue);
    public void RandomizeY() => m_y = (short)UnityEngine.Random.Range(short.MinValue, short.MaxValue);
    public void RandomizeZ() => m_z = (short)UnityEngine.Random.Range(short.MinValue, short.MaxValue);

    public void RandomizeLateralXY()
    {
        RandomizeX();
        RandomizeY();
    }
    public void RandomizeHorizontalXZ()
    {
        RandomizeX();
        RandomizeZ();
    }
    public void RandomizeTransversalYZ()
    {
        RandomizeY();
        RandomizeZ();
    }
        #endregion



        #region DESTRUCTOR
        ~Cursor65(){
        
            //Just for the learning purpose
        }
        #endregion

}
}