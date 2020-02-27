## Report

a. Braking mechanism for agents



b. Implementing agent avoid obstacles without carving



> https://docs.unity3d.com/Manual/class-NavMeshObstacle.html

c. Carving and non-carving option:

* carving enabled:  the obstacle carves a hole in the NavMesh when stationary. 
* non-carving: Default behavior similar to a collider. The agent will just steer to prevent collision with the obstacles. For example, if an agent went from south, and directed to an environments with north, east and west all surrounded by stationary obstacles, without carving turned on it can get stuck. 

When and why should turn on: When a moving obstacle becomes stationary, carving should be turned on s.t. agent can recalculate navigation path  from another path.

Issue with all obstacles carving: Need more resource of calculation. Carving is usually a optimized choice for agent to get avoid of  obstacle changed states from moving to stationary. 

Issue of non-carving: Agent got stuck when moving obstacles become stationary. 

