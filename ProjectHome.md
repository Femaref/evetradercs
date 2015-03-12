public evetrader svn

To build the source, you will need the T4 Toolbox extension for Visual Studio 2010. Also, it might be possible that you need to update references. All needed external components should be included in /References. Some projects (ie. GoogleCode.Test) aren't in the svn, they can be safely removed and are not required for a working build of the project.

Known issues: Error 175 on Entity Framework schemas. This is expected and is not breaking the build. EF tries to find the provider system wide, which is not working unless you have the library in the GAC, it will work at runtime though, as the libraries are present in the executable location.