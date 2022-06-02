using UnitTests;

var customer = new Account("Mikael Persbrandt", 10);
Console.WriteLine(customer.PointBalance);


var levelChecker = new LevelChecker();
Console.WriteLine(levelChecker.CheckLevel(customer));