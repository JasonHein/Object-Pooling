# Basics

A simple object pooling script that grabs or creates a copy of the original gameobject when GetObject() is called.

The original gameobject is set through the inspector.

Components must inherit from the Poolable interface to be used in an object pool.

The shared resource object provided through the insepctor is sent to the Poolable scripts OnCreation function.

This allows your pooled objects to reference a single copy of some data that will be the same for all pooled objects.
