# Object-Pooling
A simple unity object pooling singleton.

# Basics

To make a gameobject poolable, it must have a script on it that inherits from the interface Poolable.

The ObjectPool script is a singleton and must be on an object in the scene.


# Creating an Object Pool

To create an object pool, call the following function ObjectPool.instance.CreatePool (string path, int amount)

This loads a gameobject from the resources folder and creates X duplicates of it in a pool, then returns an integer index value to you. In order to get objects from your pool, you must give the GetObject (int index) this index. So be sure to save it somewhere.

If you call CreatePool and a pool for that gameobject already exists, the pool size will become equal to the largest pool that's been requested. If the pool exists and no more objects are requred, it does nothing.


# Getting Objects from the Pool

To get an object from the pool call ObjectPool.instance.GetObject(int index) providing the index you were returned when you made the pool.

When you grab from the pool, a referencfe to the Poolable script on an available object is returned.



# Inheriting from the Poolable interface

To make a gameobject poolable, it must have a script on it that inherits from the interface Poolable.

The inheriting script must impliment IsAvailable() which returns a boolean value for if this gameobject is in use.

When the pooled script is grabbed by the GetObject function, make sure IsAvailable() returns false until you are done using it.
