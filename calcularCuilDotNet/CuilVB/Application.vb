Imports Cuil

Public Class Application

	Public Shared Sub Main()
		System.Console.WriteLine("Examples Get Cuil")
		System.Console.WriteLine(calcularCuilCuit("22098567", "M"))
		System.Console.WriteLine(calcularCuilCuit("2098567", "F"))
		System.Console.WriteLine(calcularCuilCuit("198567", "m"))
		System.Console.WriteLine(calcularCuilCuit("22098567", "f"))
	End Sub
End Class
