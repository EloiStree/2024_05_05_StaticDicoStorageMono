using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


public struct CreateDefaultValue<T> : I_StaticDicoCreateDefault<T>
{
    public static T m_defaultValue;
    public void GetDefaultValue(out T defaultValue)
    {
        defaultValue = m_defaultValue;
    }

    public void GetDefaultValueWhenNotFoundValue(out T defaultValue)
    {
        defaultValue = m_defaultValue;
    }
}




public class StaticDicoStorageGenericMono<T,G> : MonoBehaviour where G :struct, I_StaticDicoCreateDefault<T>
{


    public string m_guidId;
    private void Reset()
    {
        ResetGuidId();
    }

    private void Awake()
    {
        CreatEmptyIfNotExisting();
    }

    //[ContextMenu("Reset GUID")]
    public void ResetGuidId()
    {
        m_guidId = StaticDicoStorageGeneric<T,G>.CreateGUID();
    }

    public void SetValue(T value) {
        StaticDicoStorageGeneric<T, G>.SetOrCreate(m_guidId, value);
    }
    public void GetValue(out bool found, out T value)
    {
        StaticDicoStorageGeneric<T, G>.Get(m_guidId, out found, out value);
    }
    public void GetValue(out bool found, out StaticDicoStorageGeneric<T, G>.RefClass value)
    {
        StaticDicoStorageGeneric<T, G>.Get(m_guidId, out found, out value);
    }

    public bool IsCreated()
    {
        return StaticDicoStorageGeneric<T, G>.IsContainsKey(m_guidId);
    }

    public void CreatEmptyIfNotExisting()
    {
        StaticDicoStorageGeneric<T, G>.CreatEmptyIfNotExisting(m_guidId);
    }
}


public interface I_StaticDicoCreateDefault<T> {

    public void GetDefaultValue(out T defaultValue);
    public void GetDefaultValueWhenNotFoundValue(out T defaultValue);
}

public class StaticDicoStorageGeneric<T, G> where G : struct, I_StaticDicoCreateDefault<T>
{

    public static G m_createDefault = new G();
    [System.Serializable]
    public class RefClass {
        public T m_value;
    }
    public static T m_defaultWhenNotFound;
    static StaticDicoStorageGeneric()
    {
       m_createDefault.GetDefaultValue(out m_defaultWhenNotFound);
    }

    public static Dictionary<string, RefClass> m_dico = new Dictionary<string, RefClass>();


    public static string CreateGUID() { return Guid.NewGuid().ToString(); }


    public static bool IsContainsKey(string guid) { return m_dico.ContainsKey(guid); }

    public static void SetOrCreateDefault(string guidId)
    {
        m_createDefault.GetDefaultValue(out T value);
        SetOrCreateAndGetRef(guidId, value, out _);
    }
    public static void SetOrCreateDefault(string guidId, out RefClass reference)
    {
        m_createDefault.GetDefaultValue(out T value);
        SetOrCreateAndGetRef(guidId, value, out reference);
    }
    public static void SetOrCreate(string guidId, T value)
    {
        SetOrCreateAndGetRef(guidId, value, out _);
    }
    public static void SetOrCreateAndGetRef(string guidId, T value, out RefClass reference)
    {

        bool found = m_dico.ContainsKey(guidId);
        if (found)
        {
            reference = m_dico[guidId];
            reference.m_value = value;
        }
        else
        {
            reference = new RefClass();
            reference.m_value = value;
            m_dico.Add(guidId, reference);
        }
    }

    public static void Get(string guidId, out bool found, out T element)
    {
        found = m_dico.ContainsKey(guidId);
        if (found)
        {
            element = m_dico[guidId].m_value;
        }
        else
        {
            element = m_defaultWhenNotFound;
        }
    }

    public static void Get(string guidId, out bool found, out RefClass element)
    {
        found = m_dico.ContainsKey(guidId);
        if (found)
        {
            element = m_dico[guidId];
        }
        else
        {
            element = null;
        }
    }

    public static void CreatEmptyIfNotExisting(string guidId)
    {
        if (!IsContainsKey(guidId))
            SetOrCreateDefault(guidId);
    }
}
