using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi.ShortCursor { 
public class TDD_Cursor3D_Properties : MonoBehaviour
{

        public Cursor65Mono m_toAffect;

        public float m_wait = 1;
        public void Start()
        {
            StartCoroutine(UseExample());
        }
        public IEnumerator UseExample() { 
        
            Cursor65 c = m_toAffect.Cursor;

            c.MeterX = 45;
            yield return new WaitForSeconds(m_wait);
            c.MeterY = 45;
            yield return new WaitForSeconds(m_wait);
            c.MeterZ = 45;
            yield return new WaitForSeconds(m_wait);
            c.MeterX = -45;
            yield return new WaitForSeconds(m_wait);
            c.MeterY = -45;
            yield return new WaitForSeconds(m_wait);
            c.MeterZ = -45;

        }
}
}
