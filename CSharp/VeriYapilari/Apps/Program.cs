// See https://aka.ms/new-console-template for more information

using Apps;
// Static olarak verildi direk erisim yapilabilir.

Console.WriteLine(Postfix.Run("235*+9-"));

// 2 3 5
// 2 3 * 5
// 2 15 + 
// 17
// 17 9
// 17 9 -
// 8