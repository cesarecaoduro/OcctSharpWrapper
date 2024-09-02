using CppSharp.Passes;

public class GpModule : ILibrary
{
    private string _includePath;
    private string _libPath;
    private string _moduleName;
    public GpModule(string includePath, string libPath, string moduleName)
    {
        _includePath = includePath;
        _libPath = libPath;
        _moduleName = moduleName;
    }

    public void Postprocess(Driver driver, ASTContext ctx)
    {
        // Not implemented
    }

    public void Preprocess(Driver driver, ASTContext ctx)
    {
        // Not implemented
    }

    public void Setup(Driver driver)
    {
        var options = driver.Options;
        options.GeneratorKind = GeneratorKind.CSharp;
        //options.GenerationOutputMode = GenerationOutputMode.FilePerModule;
        options.OutputDir = "./OutDir";
        options.Compilation.Platform = TargetPlatform.Windows;
        options.Compilation.Target = CompilationTarget.StaticLibrary;
        options.Compilation.VsVersion = VisualStudioVersion.Latest;
        options.CommentKind = CommentKind.BCPLSlash;
        options.MarshalCharAsManagedChar = true;
        options.CompileCode = true;

        //options.GenerateClassTemplates = true;
        driver.ParserOptions.SkipPrivateDeclarations = false;


        driver.ParserOptions.EnableRTTI = true;
        driver.ParserOptions.AddArguments("-fcxx-exceptions");
        

        var headers = new List<string>()
        {
            "gp_Pnt.hxx",
        };

        var libraries = new List<string>()
        {
            "TKMath.lib",
        };

        var module = options.AddModule(_moduleName);
        module.IncludeDirs.Add(_includePath);
        module.Headers.AddRange(headers);
        module.LibraryDirs.Add(_libPath);        
        module.Libraries.AddRange(libraries);

        module.OutputNamespace = "Occt";
    }

    public void SetupPasses(Driver driver)
    {
    }
}
