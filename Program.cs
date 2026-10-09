using Toolkit;
using Toolkit.Display;
using Toolkit.Rules;

// The party.  Bree is the wizard;  Tamsin is the fighter.
var bree   = Player.Create("Bree",   3,  900, 16, 16,  8, 14, 13, 12, 15, 10, 40);
var tamsin = Player.Create("Tamsin", 3, 1100, 28, 28, 16, 12, 15, 10, 13,  8, 75);

// What they're up against.
var goblinScores = AbilityScore.Create(8, 14, 10, 10, 8, 8);

var goblin = Creature.Create("Goblin", 7, 7, goblinScores, 50);

bree.ShowSheet();
tamsin.ShowSheet();
goblin.ShowSheet();

Console.WriteLine($"Tamsin swings at the goblin:  {tamsin.AttackBonus:+0;-0;+0} to hit, against AC {goblin.ArmorClass}.");
Console.WriteLine($"The goblin swings back:  {goblin.AttackBonus:+0;-0;+0} to hit, against AC {tamsin.ArmorClass}.");
