namespace Eloi
{
    /// <summary>
    /// Allows to transport a cursor struct value through code by reference.
    /// </summary>
    public class ReferenceStructCursor65 : I_Cursor65
{
    public STRUCT_CURSOR65 m_cursorValue;

    public short MillimeterX
    {
        set { ShortSpaceToolbox.SetInValueInMillimeterClamped(ref m_cursorValue.m_x, value); }
        get { return m_cursorValue.m_x; }
    }
    public short MillimeterY
    {
        set { ShortSpaceToolbox.SetInValueInMillimeterClamped(ref m_cursorValue.m_y, value); }
        get { return m_cursorValue.m_y; }
    }
    public short MillimeterZ
    {
        set { ShortSpaceToolbox.SetInValueInMillimeterClamped(ref m_cursorValue.m_z, value); }
        get { return m_cursorValue.m_z; }
    }

    public float MeterX
    {
        set { ShortSpaceToolbox.SetInValueInMeterClamped(ref m_cursorValue.m_x, value); }
        get { return ShortSpaceToolbox.GetInMeterFromShortMillimeter(m_cursorValue.m_x); }
    }
    public float MeterY
    {
        set { ShortSpaceToolbox.SetInValueInMeterClamped(ref m_cursorValue.m_y, value); }
        get { return ShortSpaceToolbox.GetInMeterFromShortMillimeter(m_cursorValue.m_y); }
    }
    public float MeterZ
    {
        set { ShortSpaceToolbox.SetInValueInMeterClamped(ref m_cursorValue.m_z, value); }
        get { return ShortSpaceToolbox.GetInMeterFromShortMillimeter(m_cursorValue.m_z); }
    }

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
        I_Cursor65 cursor65 = new ReferenceStructCursor65();
        cursor65.SetFrom(this);
        cursor = cursor65;
    }


 
}
}