using UnityEngine;

public class DebugInspectorStaticDicoValueGeneric<T, G> : MonoBehaviour where G : struct, I_StaticDicoCreateDefault<T>
{
    public StaticDicoStorageGenericMono<T, G> m_staticHolder;
    public StaticDicoStorageGeneric<T, G>.RefClass reference;
    public bool m_containerFound;



    public void UpdateReference() {
       m_staticHolder.GetValue(out  m_containerFound, out reference);
    }
    public void Start()
    {
        m_staticHolder.CreatEmptyIfNotExisting();
        UpdateReference();
    }
}
