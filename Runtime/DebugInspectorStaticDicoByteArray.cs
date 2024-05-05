using UnityEngine;

public class DebugInspectorStaticDicoByteArray : DebugInspectorStaticDicoValueGeneric<byte[], CreateDefaultValue<byte[]>>
{
    [ContextMenu("Update Ref")]
    public new void UpdateReference()
    {
        base.UpdateReference();
    }
}

