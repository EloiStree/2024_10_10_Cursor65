using UnityEngine;


namespace Eloi
{
    /// <summary>
    /// Private a start class that have a Cursor in short to be used in Unity3D children.
    /// </summary>
    public class BaseCursor65Mono : A_ICursor65Mono {

    [Tooltip("Represent a point in space in short square value in millimeter with short")]
    [SerializeField]
    Cursor65 m_cursorValue= new Cursor65();
    public override short MillimeterX { get => m_cursorValue.MillimeterX; set => m_cursorValue.MillimeterX = value; }
    public override short MillimeterY { get => m_cursorValue.MillimeterY; set => m_cursorValue.MillimeterY = value; }
    public override short MillimeterZ { get => m_cursorValue.MillimeterZ; set => m_cursorValue.MillimeterZ = value; }
    public override float MeterX { get => m_cursorValue.MeterX; set => m_cursorValue.MeterX = value; }
    public override float MeterY { get => m_cursorValue.MeterY; set => m_cursorValue.MeterY = value; }
    public override float MeterZ { get => m_cursorValue.MeterZ; set => m_cursorValue.MeterZ = value; }
    public override void GetTo(ref I_Cursor65 cursor) => m_cursorValue.GetTo(ref cursor);
    public override void GetAs(out I_Cursor65 cursor) => m_cursorValue.GetAs(out cursor);
    public override void SetFrom(in I_Cursor65 cursor) => m_cursorValue.SetFrom(in cursor);
    
    protected override void ImplementationOfRefresh()
    {
        // Need To Be Overrided by the child
    }


    public Cursor65 GetCursor()
    {
        return this.m_cursorValue;
    }

    public Cursor65 Cursor
    {
        get => m_cursorValue;
    }

}
}