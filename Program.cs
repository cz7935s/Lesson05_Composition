using Toolkit;
using Toolkit.Display;
using Toolkit.Rules;

// The party.  Bree is the wizard;  Tamsin is the fighter.
var bree   = Player.Create("Bree",   8, 14, 13, 12, 15, 10);
var tamsin = Player.Create("Tamsin", 16, 12, 15, 10, 13,  8);

// What they're up against.
// var goblinScores = AbilityScore.Create(8, 14, 10, 10, 8, 8);

var goblin = Creature.Create("Goblin", 7, 7, 8, 14, 10, 10, 8, 8, 50);

bree.ShowSheet();
tamsin.ShowSheet();
goblin.ShowSheet();

Console.WriteLine($"Tamsin swings at the goblin:  {tamsin.AttackBonus:+0;-0;+0} to hit, against AC {goblin.ArmorClass}.");
Console.WriteLine($"The goblin swings back:  {goblin.AttackBonus:+0;-0;+0} to hit, against AC {tamsin.ArmorClass}.");
