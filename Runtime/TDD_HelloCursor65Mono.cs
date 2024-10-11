using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_HelloCursor65Mono : MonoBehaviour
{

    public BaseCursor65Mono m_cursorToAffect;

    public Vector3 m_valueToTest;

    [ContextMenu("Add Vector3")]
    public void AddVector3ToCursor()
    {
        m_cursorToAffect.Cursor.AddInMeter(m_valueToTest);
        m_cursorToAffect.RefreshIfPossible();
    }
    [ContextMenu("Remove Vector3")]
    public void RemoveVector3ToCursor()
    {
        m_cursorToAffect.Cursor.RemoveInMeter(m_valueToTest);
        m_cursorToAffect.RefreshIfPossible();
    }
}
