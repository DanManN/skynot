- [x] Crowd simulator
	- [x] Enviorment
	- [x] NavMesh (carve)
	- [x] Agent prefab
	- [x] Mouse movement
	- [x] Agent Selection
- [x] Crowd collision
- [ ] Moving obstacles: Yanshi working on ...
- [ ] Text Response
	- [ ] Describe your braking mechanism for agents.
	- [ ] Describe a way for implementing how an agent can avoid obstacles without carving.
	- [ ] Explain the difference in behavior between carving and non-carving options for a NavMeshObstacle. When and why should you use carving? What is the issue with making all obstacles carving? What is the issue with making all obstacles noncarving?
- [ ] Extra credit
	- [ ] Adversarial Agent
	- [ ] Extract to graph [Yanshi]



## A* path finding

1. Extract NavMesh to Graphs

```
UnityEngine.AI.NavMeshTriangulation triNavMesh;
triNavMesh = UnityEngine.AI.NavMesh.CalculateTriangulation();

triNavMesh.areas // 156: 0, 1, 2, 3, 4 as set
triNavMesh.indices // indices to draw a triangle 468: 468 / 3 = 156
triNavMesh.vertices // 362: unique indices
```

2. Graph Map

   Borrow and modify from https://github.com/jpinsonault/monograph map.cs

3. A_Star

   Prototype from [Wikipedia](https://en.wikipedia.org/wiki/A*_search_algorithm)

   - [ ] Duplicate StartNode, EndNode, ShortestPath in Map and AstarPath
   - [ ] heuristic function
   - [ ] Test
   
4. As straight as possible: smoothing?

5. Points in triangle