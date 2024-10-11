namespace Eloi
{
    /// <summary>
    /// Represent the bare minimum of a cursor in 3D space. (Be set and get in MM or Meter value)
    /// </summary>
    public interface I_CursorProperties
{
    public short MillimeterX { get; set; }
    public short MillimeterY { get; set; }
    public short MillimeterZ { get; set; }
    public float MeterX { get; set; }
    public float MeterY { get; set; }
    public float MeterZ { get; set; }
    
}
}