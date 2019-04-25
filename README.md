# GameJamTemplate
A simple unity project set up for quick and easy game-jamming.

Contains three basic scenes with UI elements and transitions, plus an additional scene ready for testing model scale, particle effects, or other stand-alone things you plan to make a prefab of.

Has a working highscore system, clock (that can count up and down - currently rigged to 'game over' on time running out, but this is easily adapted for your needs), simple player health system, three basic object type interfaces (interactable - shows a prompt, and allows for input to trigger an event when within range, collectables - objects that can be 'picked up' or at least removed from the scene upon touching, and hazards that will deal damage but won't be removed) and examples of each in a very simple 2.5d platformer scene (main).
All modules can be easily added and removed to your scenes as required, with minimal dependancy between objects.

I'm still working on creating a save/load system, but there should be enough here to get you started with any game, and save you time implementing the basics and boring parts (like menus and score systems). 

More time = more polish = better game jam game!

Everything is provided 'as is' and I won't be updating this during Ludum Dare/Global Game Jam (because I do those myself). Using this template requires you to understand the fundamentals of building games in unity engine, and basic c# programming knowledge. This project was designed and built in unity 2017 (long-term support) and I have not tested it with older or newer versions of the engine. Update at your own risk!

Good Luck, Have Fun
