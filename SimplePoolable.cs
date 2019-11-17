using UnityEngine;

/// <summary>
/// A simple monobehavoir that can be attached to a gameobject to make it useable by an ObjectPool in the scene.
/// </summary>
public class SimplePoolable : MonoBehaviour, Poolable
{
    /// <summary>
    /// Is this poolable object availble to be grabbed and used for the next object request?
    /// </summary>
    public virtual bool IsAvailable ()
    {
        return gameObject.activeInHierarchy;
    }

    /// <summary>
    /// The first time this object is grabbed from the object pool it is instantiated, then this is called.
    /// The shared resource of the Object Pool is provided here if you wish to use it.
    /// You can set tyhe shared resource of the object pool through the inspector.
    /// </summary>
    public virtual void OnCreation (Object shared)
    { }
}
