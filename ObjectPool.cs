using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for component's that can be used by ObjectPool.
/// For a game object to be poolable, it must have a component on it that inherits from this Interface.
/// See the SimplePoolable class for an example.
/// </summary>
public interface Poolable
{
    /// <summary>
    /// Is this poolable object availble to be grabbed and used for the next object request?
    /// </summary>
    bool IsAvailable();

    /// <summary>
    /// The first time this object is grabbed from the object pool it is instantiated, then this is called.
    /// The shared resource of the Object Pool is provided here if you wish to use it.
    /// You can set tyhe shared resource of the object pool through the inspector.
    /// </summary>
    void OnCreation(Object sharedResource);
}

/// <summary>
/// A simple object pooling script that grabs or creates a copy of the original gameobject when GetObject() is called.
/// The original gameobject is set through the inspector.
/// Components must inherit from the Poolable interface to be used in an object pool.
/// The shared resource object provided through the insepctor is sent to the Poolable scripts OnCreation function.
/// This allows your pooled objects to reference a single copy of some data that will be the same for all pooled objects.
/// </summary>
public class ObjectPool : MonoBehaviour {

    // List of pooled objects
    List<Poolable> _Pool;
    [SerializeField] Object _SharedResource;
    [SerializeField] GameObject _Original;
    [SerializeField] int _MaxSize = -1;

    /// <summary>
    /// Create the object pool list.
    /// </summary>
    private void Awake()
    {
        _Pool = new List<Poolable>();
    }

    /// <summary>
    /// Gets a copy of the original gameobject. If none are available, one is added to the pool and returned.
    /// When you are done with the pooled object, its IsAvailable() function should return true to be available to the pool again.
    /// A maximum pool size can been set through the inspector (defaults to infinite).
    /// If the pool has reached that limit and no copies are avaible, the object returned is null.
    /// </summary>
    public Poolable GetObject()
    {
        // Grab the first available object
        for (int i = 0; i < _Pool.Count; ++i)
        {
            if (_Pool[i].IsAvailable())
            {
                return _Pool[i];
            }
        }

        // If there are no available objects, make one.
        if (_Pool.Count != _MaxSize)
        {
            GameObject obj = Instantiate(_Original, transform);
            Poolable script = obj.GetComponent<Poolable>();
            _Pool.Add(script);
            script.OnCreation(_SharedResource);
            return script;
        }

        // The max pool size has been reached and no objects are available. Return null.
        return null;
    }
}
