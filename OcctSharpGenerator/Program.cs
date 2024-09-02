DotNetEnv.Env.TraversePath().Load();
var includePath = DotNetEnv.Env.GetString("OPENCASCADE_INC_FOLDER");
var libPath = DotNetEnv.Env.GetString("OPENCASCADE_LIB_FOLDER");

ConsoleDriver.Run(new GpModule(includePath, libPath, "Gp"));

Console.WriteLine("Hello, World!");
Console.ReadLine();
