using UnityEngine;


namespace Eloi
{
    public abstract class A_ICursor65Mono : MonoBehaviour, I_Cursor65
{
    public abstract short MillimeterX { get; set; }
    public abstract short MillimeterY { get; set; }
    public abstract short MillimeterZ { get; set; }
    public abstract float MeterX { get; set; }
    public abstract float MeterY { get; set; }
    public abstract float MeterZ { get; set; }

    public abstract void GetAs(out I_Cursor65 cursor);
    public abstract void GetTo(ref I_Cursor65 cursor);
    public abstract void SetFrom(in I_Cursor65 cursor);

    [ContextMenu("Refresh If Possible")]
    public void RefreshIfPossible()
    {
        ImplementationOfRefresh();
    }
    protected abstract void ImplementationOfRefresh();
}
}