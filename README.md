# BattleShip
BattleShip in C# with Windows Form

#Tasks
2 parts 
	-> Network & Game Mechanics (which is using network)
	-> Graphical Part


#App Pipeline
Open on MAIN MENU (Host game, look for game, exit)
->Network (NetworkController.cs)
Host : Should open its socket for lan connection
Other : Should look for open socket in LAN & make connections
-> Game can start	(GameController.cs)
3 Phases :
1. Preparation
	* Init grid
	* Each player put their ship on the grid
		Rules : No ship can overlap
				No ship can be outside grid
				All ship must be used
	* Host start the first turn
	-> When Player is ready, send ready status to other player
	-> When on Host, All players are Ready, 
		-> send Play Status to other


2. GameTime
	* Turn by turn, player can pick a case to fire
		-> Pick a case -> send picked case to other -> other will check if touched or not -> send back result -> apply result
	* When all ship of a player are dead, this said player should trigger phase 3 : endgame 

3. Endgame
	* Display the ennemy grid & winner name

