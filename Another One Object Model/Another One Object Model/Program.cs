using ClassLibrary;

Manager manag = Manager.GetInstance;
BuildsManager buildManag = BuildsManager.Instance;
int counter = 0;
while (counter < 10)
{
    buildManag.AddResize();
    counter++;
}

Console.WindowHeight = 7;
manag.Starter();