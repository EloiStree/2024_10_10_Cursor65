using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_HelloCursor65Mono : MonoBehaviour
{

    public Cursor65Mono m_cursorToAffect;

    public Vector3 m_valueToTest;

    [ContextMenu("Add Vector3")]
    public void AddVector3ToCursor() {
        m_cursorToAffect.m_cursorValue.Add(m_valueToTest);
        m_cursorToAffect.Refresh();
    }
   
}
