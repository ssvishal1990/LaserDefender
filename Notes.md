# Camera View port

Viewport space represents a normalized position relative to the camera. 
That is what camera can see. 

Consider the left most corner of the screen as (0,0)

rightmostBottom Corner -> (1,0)

TopLeftCorner -> (0,1) 

TopRightCorner -> (1,1)

viewportToWorldPoint converts a normalised position on the to a 3D position in world space

# Enemy functionality description

## Wave config 
This sciptable object will contain information related to.

1 which enemies will be spawned;

2 The path enemies will follow

3 Time between enemy spawns

4 Enemy Movement speed

## Enemy Spawner
Action performed by this script will be to

1 Spawn enemy

2 Order of the waves

3 Time between waves

## Enemy Pathing 

Moves enemy along a specified path
