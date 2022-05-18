// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

AppDomain currentDomain = AppDomain.CurrentDomain;
currentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs args) =>
{
    Exception e = (Exception)args.ExceptionObject;

    Console.WriteLine("MyHandler caught : " + e.Message);
    Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
};

try
{
    throw new Exception("1");
}
catch (Exception e)
{
    Console.WriteLine ("Catch clause caught: {0} \n", e.Message );

}

throw new Exception("2");