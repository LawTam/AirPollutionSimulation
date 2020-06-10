### 1. Group members 

Lawrence Tam

Finnegan Damore Johann

Quan Gao

Attie Sit

### 2. Conceptual description of the idea, the "Why?" 

The quarantine situation isn’t ideal when we look at it upfront, but it has brought at least one good thing: a dramatic increase in worldwide air quality. For this project, we want to model how the air quality changes over time and how impactful it is to how we live in our physical environment. Our hope is that this project will incentivize more people to limit their carbon footprint even after the situation is over. 

### 3. Technical description of the project, the "How?" 

We need to write custom shaders to make air pollution fog that will change itself (density, speed, color, etc) based on real time data like wind speed and time so that it can simulate real life air pollution. We will do this by making particle-based fog that can be altered with sliders. We also need to make water, which will be done with 3d models and normal maps.

We also need to create and/or assemble 3D models that represent the cities of LA, Wuhan, and Hong Kong. A method of doing this is by importing 3D models of each city from OpenStreetMaps or google maps into blender and adding in models that’s not covered in the import. We also need to either texture the models or figure out how to export texture data before using it. We will use Unity for this project.

### 4. Main challenges of the project, the "What?" 

The primary challenges of this project will be finding ways of incorporating real world data for our pollution simulation. We decided to not use the fog class, and instead create our own fog using shaders and particle density to simulate increasing pollution. The data from real world statistics will integrate with these shaders, which will then reflect real world pollution changes. While this will add more work and challenge, we believe creating this heavily customized simulation will affect our audience the most.

### 5. Distribution of work between the team members (bullet points and keywords) link to a shared Git repo (just one per project)

https://github.com/LawTam/AirPollutionSimulation

Someone makes particles (randomly dispersed) * Finnegan & Lawrence

Changes density of particles UI slider * Finnegan

Make clouds appear from particles	* Lawrence & Finnegan

Make ocean * Finnegan

Day and Night cycle * Lawrence

Make the skyline (or more)* Attie & Finnegan

Move the particles (based on wind speed and direction)  * Finnegan & Quan

pull real-time data/ historical data (for time lapse)	* Finnegan & Quan

Script for camera location changes * Attie

Scripts for real world data manipulation of smog * Finnegan

User-interface for camera change * Attie & Finnegan



### Changes
1. We switched from Three.js to Unity because of more intuitive development and wider array of tools at our disposal.
2. For more accurate datasets, we went on a monthly by monthly basis for the smog simulation.
