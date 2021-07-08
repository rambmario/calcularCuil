
Option Explicit On
Option Strict On

Imports System
Imports Microsoft.VisualBasic


Public Class Cuil

	Public Sub New()
		MyBase.New
	End Sub

	Public Shared Function calcularCuilCuit(ByVal document_number As String, ByVal gender As String) As String

		'* Cuil-Cuit format has 11 digits: AB - document_number - C
		'* Author: Mario Antonio Ramb
		'*
		'* @param {str} document_number -> string has only numbers
		'* @param {str} gender -> char has 3 options: M (masculino) F (femenino) S (sociedad)
		'*
		'* @return {str}

		Dim AB As String = ""
		Dim C As String = ""

		' Checks document_number has only numbers and length must be 8 digits.
		If IsNumeric(document_number) Then
			Select Case document_number.Length()
				Case 8
					' 8 digits is OK
				Case 7
					document_number = String.Concat("0", document_number)
				Case 6
					document_number = String.Concat("00", document_number)
				Case Else
					Console.WriteLine("El número de DNI debe contener como mínimo 6 dígitos")
					Return ""
			End Select
		Else
			Console.WriteLine("El número de DNI debe contener solo dígitos")
			Return ""
		End If

		' Converts gender char to upper case and calculates AB.
		gender = gender.ToUpper()

		If (gender = "M") Then
			AB = "20"
		ElseIf (gender = "F") Then
			AB = "27"
		Else
			AB = "30"
		End If

		' Fills an array with multipliers digits.
		Dim multiplicadores As Integer() = {3, 2, 7, 6, 5, 4, 3, 2}

		' Does calculations for 2 first digits (AB).
		Dim calculo As Integer = (Int32.Parse(AB.Substring(0, 1)) * 5) + (Int32.Parse(AB.Substring(1, 1)) * 4)

		' Loops through the array and do the calculations.
		For i As Integer = 0 To 7
			calculo += Int32.Parse(document_number.Substring(i, 1)) * multiplicadores(i)
		Next

		' Gets MOD and evaluates to get C value.
		Dim resto As Integer = calculo Mod 11

		If resto = 1 Then
			If gender = "M" Then
				C = "9"
			Else gender = "F"
				C = "4"
			End If
			AB = "23"

		ElseIf resto = 0 Then
			C = "0"
		Else
			C = (11 - resto).ToString()
		End If

		' Shows example
		Console.WriteLine(String.Join("-", AB, document_number, C))

		' Generates Cuil - Cuit
		Dim cuil_cuit As String = String.Join("", AB, document_number, C)

		Return cuil_cuit

	End Function

End Class
