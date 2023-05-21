using Gtk;

Application.Init();

using var game = new Dawngar.MainGame();
game.Run();

Application.Quit();