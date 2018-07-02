# .NET-CORE-2
An intro to .NET CORE 2. 

Model: Data and Methods used to work with it
View: The interface
Controller: Coordinates interactions between the view and model

When installing ef core, 
use pmc and change active directory to the cspproj file eg: D:\CS\.NET-CORE-2\MvcFlashcards\MvcFlashcards
before running 

dotnet ef migrations add Initial
dotnet ef database update

reread this: 
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/controller-methods-views?view=aspnetcore-2.1
on controllers and anti-badstuff