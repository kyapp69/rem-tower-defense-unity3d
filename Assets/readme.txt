Group Members: Erwin Haryantho <eharyantho> <664480>, 
			   Richard <rsiem> <716039>, 
               Michael Lee <michlee> <563550>


---------------------
| Table of Contents |
---------------------
1. Description of Application
2. How to use Application
3. Modelling of Objects and Entities
4. Handling of Graphics and Camera Motion
5. References of Code used


1. Description of Application

Tower Defence in 3D made with Unity. The objective of the game is to destroy all the
enemies that are being spawned in waves using turrets you can build with gold.
Each turrets differs in price and the projectile it shoots, with the higher priced turrets
being more effective in destroying the enemies. Each enemy you destroy will give the player
gold where he/she can build more turrets strategically.



2. How to use Application

App is meant to be used via tablet using touch input. If not, the game can also be played
using keyboard/mouse. When the game is first runned, you are brought to the main menu,
where you can: 

	Start   - Play the game
	Rules   - View the ground rules and objective
	Options - Change the difficulty (default is Beginner)
	Quit    - Quite the game

When playing the game, the "Main Menu", and "Restart" buttons are always there
so that the player can click on those if needed.

To play the game, one keeps building turrets to fend off the mulitude of waves of enemies.
If one reaches the end point, it is game over. To win the game, the player has to 
destroy all the enemies using the turrets that will shoot off the projectiles to
defeat them.



3. Modelling of Objects and Entities

Map - The Tower Defence Map, made up of a bunch of cubes that has a texure applied to it
Originally, it was a square of cubes but some were deleted to allow a Path to form
for Tower Defence

Enemies - They are spawned, using the 'Spawner' script, and they follow waypoints
that are set along the path using the script 'Movement'. It also uses the script 
'Zombie', which contains the health of the enemy, which in turn uses the 'Enemy'
script since the latter is of an abstract class. For the Boss Zombie Prefab, it simply
uses the script 'BossZombie' instead.

Path - Numerous scaled cubes placed at the empty cube slots

Waypoints - Unrendered Cubes along the path which enemies follow

Plane - A 3D Object that has a texture applied to it to beautify
the backdrop of the  game

Fog Effect - It is a particle system, with a shader called 'Fog' attached to it,
to shield the spawning of enemies from the player

Trees - taken from the asset store to give the playing field a forest like feeling,
as do the Map, Path and Plane.

Manager Objects:
_Manager - Uses the '_ManagerScript' to load scenes, exit, restart the game,
set the difficulty.
Gold Manager - Uses the 'Gold' script to manage the amount of gold that is held
by the player and the cost of the turrets
Shop Manager - Uses the 'Shop' script to manage the purchases of the turrets
made by the player


4. Handling of Graphics

The custom shaders 'BetterDiffuse' and 'CelShadingForward' were used to alter
the textures applied to objects, such as Map and Path. A point light was also
placed near the end of the path to demonstrate the effect of shadow volumes
the objects give against the Map and Ground. There are point lights for the Zombies
as well to brighten the game.



5. Handling of Camera Motion

With the app being based on tower defence, the camera does not move in the along the y-axis,
only the x and z axises. This is to ensure the user has an optimal view when playing
the game. If played with the keyboard, the arrow keys will enable the camera to move
to see hidden areas. For the tablet, tilting it  will achieve the same results.
We have also set min and max values of the x and z axises so that the camera will not lose
track of the game stage.



6. References of Code used

Asset Store

Turrets         - "Turrets Pack" by Vertex Studio
Grass Texture   - "Foliage Pack Free" by Jake Sullivan
Ground Texture  - "Yughues Free Ground Materials" by Nobiax / Yughues
Zombies         - "Survival Shooter" by Unity Technologies

Material - Explosions
https://www.dropbox.com/s/70r7gr1tfytv9o9/Aerial%20Explosion%20Tutorial%20Materials.unitypackage?dl=0

Shader - Multi-Light Pixel Shader, BetterDiffuse
http://kylehalladay.com/blog/tutorial/bestof/2013/10/13/Multi-Light-Diffuse.html

Shader - Cel Shading, Forward Rendering
http://www.gamasutra.com/blogs/DavidLeon/20150702/247602/NextGen_Cel_Shading_in_Unity_5.php

Shader - Fog
http://answers.unity3d.com/questions/1068035/fog-not-working-in-my-own-vertext-shader.html

Touch Controls
https://unity3d.com/learn/tutorials/topics/mobile-touch/pinch-zoom

Accelerometer
http://answers.unity3d.com/questions/60734/accelerometer-auto-rotate-issue.html