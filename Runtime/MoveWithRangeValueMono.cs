using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi { 
public class MoveWithRangeValueMono : MonoBehaviour
{
    public Cursor65Mono m_cursorToAffect;
    [Range(-1,1)]
    public float m_leftToRight;
    [Range(-1, 1)]
    public float m_downToUp;
    [Range(-1, 1)]
    public float m_backToForwrad;
    public float m_time=1;
    IEnumerator Start()
    {
        while (true) {

            m_cursorToAffect.Cursor.AddInMeter(new Vector3(
                m_leftToRight,
                m_downToUp,
                m_backToForwrad));
            yield return new WaitForSeconds(m_time);
            yield return new WaitForEndOfFrame();
        }
    }

}

}