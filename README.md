## Report

## Response to 5. 

- [ ] Braking mechanism for agents** 4.)

b. Implementing agent avoid obstacles without carving

![image-20200226212438643](C:\Users\kdrob\AppData\Roaming\Typora\typora-user-images\image-20200226212438643.png)

* Current solution: **Dynamic baking** a NavMesh: https://github.com/Unity-Technologies/NavMeshComponents
* Note that using 2019.1, to use the extension, we should switch to corresponding branch of specific version
* Ref from https://answers.unity.com/questions/248171/how-to-bake-nav-mesh-dynamically.html
* Before we found this extension, we can only create a static NavMesh and tick the 'carve' so that agent can go through moving-> stationary obstacles.

> https://docs.unity3d.com/Manual/class-NavMeshObstacle.html

c. Carving and non-carving option:

* carving enabled:  the obstacle carves a hole in the NavMesh when stationary (default). 
* non-carving: The agent will just steer to prevent collision with the obstacles. For example, if an agent went from south, and directed to an environments with north, east and west all surrounded by stationary obstacles, without carving turned on it can get stuck. 

When and why should turn on: When we have a moving obstacle which might becomes stationary and make agents got stuck, carving should be turned on. So that agent can carve through the obstacle.

Issue with all obstacles carving: It is not an elegant behavior. Dynamically recalculate Navmesh should be better solution. (In 2018, Unity got such [extension](https://github.com/Unity-Technologies/NavMeshComponents)) Carving is usually a optimized choice for agent to get avoid of  obstacle changed states from moving to stationary. 

Issue of non-carving: Agent got stuck when moving obstacles become stationary. 

