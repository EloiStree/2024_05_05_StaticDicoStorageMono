using UnityEngine;

public class StaticDicoStorageByteArrayMono : StaticDicoStorageGenericMono<byte[], CreateDefaultValue<byte[]>> {
    
    
    [ContextMenu("Reset Guid ID")]
    private new void ResetGuidId()
    {
        base.ResetGuidId();
    }
}
