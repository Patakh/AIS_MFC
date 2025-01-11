using System;

namespace AisLogistics.DataLayer.Utils;

public static class DataUtils
{
    public static string GenerateCaseId(string officeMnemo) => $"{officeMnemo}{DateTime.Now:ddMMyyHHmmssffff}{new Random().Next(10, 99)}";
    public static string GenerateCaseIdV2(string officeMnemo, string caseId)
    {
       var number = string.IsNullOrEmpty(caseId) ? "00000000" : caseId.Remove(0, caseId.Length - 8);
       int lastCaseNumber = int.Parse(number);
       int newCaseId = lastCaseNumber + 1;
       return  $"{officeMnemo}{newCaseId:D8}";
    } 
}