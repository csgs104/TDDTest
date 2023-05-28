using Microsoft.Extensions.DependencyInjection;

using TDDConsoleApp.IoC;
using TDDConsoleApp;
using TDDConsoleApp.Objects;


Console.WriteLine("Hello.");

Console.WriteLine("#### #### #### #### #### #### #### ####");

var start = Startup.CreateHostBuilder()
            ?? throw new Exception("Not Started.");
var host = start.Build()
           ?? throw new Exception("Host Not Found.");
// var greeting = host.Services.GetService<...>()
         // ?? throw new Exception("Greeting not Found.");
/*
var users = host.Services.GetService<IUserRepository>() 
            ?? throw new Exception("UserRepository not Found.");

var module = host.Services.GetService<IModule>()
            ?? throw new Exception("UserModule not Found."); 
*/

Console.WriteLine("Services Started.");

Console.WriteLine("#### #### #### #### #### #### #### ####");

var list = new List<string>();

list.Add("G01"); list.Add("V1"); list.Add("P1"); list.Add("50");
list.Add("G02"); list.Add("V1"); list.Add("P1"); list.Add("100");
list.Add("G03"); list.Add("V2"); list.Add("P1"); list.Add("100");
list.Add("G04"); list.Add("V2"); list.Add("P1"); list.Add("100");

list.Add("G05"); list.Add("V3"); list.Add("P2"); list.Add("50");
list.Add("G06"); list.Add("V3"); list.Add("P2"); list.Add("100");
list.Add("G07"); list.Add("V4"); list.Add("P2"); list.Add("100");
list.Add("G08"); list.Add("V4"); list.Add("P2"); list.Add("100");

list.Add("G09"); list.Add("V5"); list.Add("P3"); list.Add("50");
list.Add("G10"); list.Add("V5"); list.Add("P3"); list.Add("70");
list.Add("G11"); list.Add("V6"); list.Add("P3"); list.Add("100");
list.Add("G12"); list.Add("V6"); list.Add("P3"); list.Add("90");

list.Add("G13"); list.Add("V7"); list.Add("P4"); list.Add(null);
list.Add("G14"); list.Add("V7"); list.Add("P4"); list.Add("100");
list.Add("G15"); list.Add("V8"); list.Add("P4"); list.Add("100");
list.Add("G16"); list.Add("V8"); list.Add("P4"); list.Add("100");
list.Add("G17"); list.Add("V9"); list.Add("P4"); list.Add("100");

var data = new Data();
data.Input(list);
var output = data.Output();
Console.WriteLine(output);

Console.ReadLine();

Console.WriteLine("#### #### #### #### #### #### #### ####");

Console.WriteLine("Bye.");

