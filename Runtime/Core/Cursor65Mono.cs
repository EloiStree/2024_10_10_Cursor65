using UnityEngine;


namespace Eloi
{

[HelpURL("https://github.com/EloiStree/2024_10_10_Cursor65")]
/// <summary>
/// This class is a cursor that can be used to represent a position in 3D space clamp in a short space.
/// <\summary>
public class Cursor65Mono : BaseCursor65Mono
{

    public Transform m_whatToMove;
    public bool m_useLocalPosition = true;

    public void Reset()
    {
        m_whatToMove= transform; 
    }

    private void OnEnable()
    {
        RefreshIfPossible();
    }

    public void Update()
    {
        RefreshIfPossible();
    }

 
    protected override void ImplementationOfRefresh()
    {
        if (m_whatToMove == null)
            return;

        if (m_useLocalPosition)
        {
            m_whatToMove.localPosition = GetCursor().GetPositionAsMeter();
        }
        else
        {
            m_whatToMove.position =GetCursor(). GetPositionAsMeter();
        }
        
    }

}



}

