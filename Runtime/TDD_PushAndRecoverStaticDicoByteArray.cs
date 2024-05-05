using UnityEngine;



public class TDD_PushAndRecoverStaticDicoByteArray : TDD_PushAndRecoverStaticDicoValue<byte[], CreateDefaultValue<byte[]>>
{

    public void Awake()
    {
        TestCode();
    }
    [ContextMenu("Test Code")]
    public  void TestCode() {

        base.Test();
    }
}
