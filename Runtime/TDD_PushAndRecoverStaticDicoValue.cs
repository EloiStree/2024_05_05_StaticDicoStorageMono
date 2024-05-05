using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TDD_PushAndRecoverStaticDicoValue<T,G> : MonoBehaviour where G:struct, I_StaticDicoCreateDefault<T>
{
    public StaticDicoStorageGenericMono<T, G> m_staticHolder;

    public bool m_existAtStart;
    public T m_containerToCopy;
    public bool m_found;
    public T m_containerToSet;
    public bool m_existAtEnd;
    public StaticDicoStorageGeneric<T, G>.RefClass m_containerRefToSet;



    public void Test() {

        m_existAtStart = m_staticHolder.IsCreated();
        m_staticHolder.SetValue(m_containerToCopy);
        m_staticHolder.GetValue(out m_found, out m_containerToSet);
        m_staticHolder.GetValue(out m_found, out m_containerRefToSet);

        m_existAtEnd = m_staticHolder.IsCreated();
    }

}
