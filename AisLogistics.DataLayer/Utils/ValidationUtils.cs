using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace AisLogistics.DataLayer.Utils;

//TODO Удалить если не нужно
public static class ValidationUtils
{
    public static bool PfrValidateSnils(string snils) => Regex.IsMatch(snils, "^(\\d| ){3}-(\\d| ){3}-(\\d| ){3} (\\d| ){2}$");

    public static bool FnsValidateInnFl(string innFl) => Regex.IsMatch(innFl, "^([0-9]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{10}$");

    public static bool FnsValidateInnUl(string innUl) => Regex.IsMatch(innUl, "^([0-9]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{8}$");
        
    public static bool FnsValidateKpp(string kpp) => new Regex("^\\d{4}[\\dA-Z][\\dA-Z]\\d{3}$").IsMatch(kpp);
        
    public static bool FnsValidateOgrnIp(string ogrnIp) => Regex.IsMatch(ogrnIp, "^[0-9]{15}$");
        
    public static bool FnsValidateOgrnUl(string ogrnUl) => Regex.IsMatch(ogrnUl, "^[0-9]{13}$");

    public static bool ValidateCadasterNum(string cadasterNum) => Regex.IsMatch(cadasterNum, "^\\d{2}:\\d{2}:\\d{6,7}:\\d{1,}$");
        
    public static bool IsEqualOrBelowZero(int value) => value <= 0;

    public static bool ValidateCadasterKvartNum(string cadasterNum) => Regex.IsMatch(cadasterNum, "^\\d{2}:\\d{2}:\\d{6,7}$");

    public static bool IsValidName(string name) => name is null or { Length: 0 } || name.All(a=>a is ' ');

    public static bool IsValidNames(params string[] names) => names.All(IsValidName);

    public static bool IsAnyValidNames(params string[] names) => names.Any(IsValidName);

    public static bool CheckCyrilic(string input) => input is not null && input.All(c => c is >= 'а' and <= 'я' or >= 'А' and <= 'Я' or '-' or ' ' or 'ё' or 'Ё');
        
    public static bool Check4DigitsSpace(string input) => Regex.IsMatch(input, "^\\d\\d \\d\\d$");
        
    public static bool Check2Digits(string input) => input is {Length: 2} && input.All(c => c is >= '0' and <= '9');
        
    public static bool Check4Digits(string input) => input is { Length: 4 } && input.All(c => c is >= '0' and <= '9');
        
    public static bool Check6Digits(string input) => input is {Length: 6} && input.All(c => c is >= '0' and <= '9');
        
    public static bool Check7Digits(string input) => input is {Length: 7} && input.All(c => c is >= '0' and <= '9');
        
    public static bool Check8Digits(string input) => input is { Length: 8 } && input.All(c => (c is >= '0' and <= '9'));
        
    public static bool Check10Digits(string input) => input is {Length: 10} && input.All(c => c is >= '0' and <= '9');
        
    public static bool Check11Digits(string input) => input is {Length: 11} && input.All(c => c is >= '0' and <= '9');
        
    public static bool Check12Digits(string input) => input is {Length: 12} && input.All(c => c is >= '0' and <= '9');
        
    public static bool CheckAllDigits(string input) => input is not null && input.All(c => c is >= '0' and <= '9');

    public static bool CheckAnyDigits(string input) => input is not null && input.Any(c => c is >= '0' and <= '9');
        
    public static bool ValidateEmail(string email) => Regex.IsMatch(email, "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,4})+)$");
        
    public static bool FkValidateKbk(string kbk) => Regex.IsMatch(kbk, "^[0-9a-zA-Zа-яА-Я]{20}$");

    //Идентификатор плательщика для ЮЛ – резидента РФ
    public static bool FkValidatePayerIdRfUl(string payerId) => Regex.IsMatch(payerId, "^200\\d{14}[A-Z0-9]{2}\\d{3}$");

    //Идентификатор плательщика для ФЛ
    public static bool FkValidatePayerIdFl(string payerId) => Regex.IsMatch(payerId, "^1((0[1-9])|(1[0-5])|(2[12456789])|(3[0]))[0-9a-zA-Zа-яА-Я]{19}$");

    //Идентификатор плательщика для ЮЛ – нерезидента РФ
    public static bool FkValidatePayerIdForeignUl(string payerId) => Regex.IsMatch(payerId, "^300\\d{14}[A-Z0-9]{2}\\d{3}|3[0]{7}\\d{9}[A-Z0-9]{2}\\d{3}$");
        
    //Идентификатора плательщика для ИП
    public static bool FkValidatePayerIdIp(string payerId) => Regex.IsMatch(payerId, "^4[0]{9}\\d{12}$");

    //Уникальный идентификатор возврата
    public static bool FkValidateUiv(string uiv) => Regex.IsMatch(uiv, "^\\d{8}((0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])\\d{4})\\d{9}$");

    public static bool ValidatePhoneMkgu(string phoneNumber) => Regex.IsMatch(phoneNumber, "^[+][7][0-9]{10}$");

    public static string StripReturns(string source) => source?.Replace("\r", string.Empty).Replace("\n", string.Empty);

    public static string FilterDigits(string source) => new(source.Where(c => c is >= '0' and <= '9').ToArray());

    public static bool CheckNull(object item) => item is null;

    public static bool IsInt(string value) => value is not null && int.TryParse(value, out _);

    public static bool IsGuid(string value) => value is not null && Guid.TryParse(value, out _);

    public static string LimitLength(string value, int maxSize) => value.Length < maxSize ? value : value[..maxSize];

    public static bool IsAllValidNames(params string[] names) => names.All(IsValidName);

    public static string CapitalizeFirstChar(string item) => string.IsNullOrWhiteSpace(item) ? item : $"{item.First().ToString().ToUpper()}{item[1..]}";

    public static bool ValidateIssuedCodePrimaryDoc(string input) => Regex.IsMatch(input, "\\d{3}-\\d{3}");

    public static bool ValidateSvedRozhSeriesPfr(string series) => Regex.IsMatch(series, "^[IVXLCDM]{1,10}[\\-][А-Я]{2}$");
    public static string StripDoubleSpaces(string item) => item.Replace("  ", " ");

    //Русский текст. Допускаются также пробелы, цифры, точки, запятые, тире, апострофы.
    public static bool ValidateRusNum(string input) => Regex.IsMatch(input, @"^[а-яА-ЯёЁ\-0-9][а-яА-ЯёЁ\-'\,\s\.0-9]*$"); 

    //Уникальный идентификатор платежа
    public static bool FkValidateUip(string uip) => Regex.IsMatch(uip, "^1\\d{15}((0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])\\d{4})\\d{8}$")
                                                    || Regex.IsMatch(uip, "^2\\d{4}0{11}((0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])\\d{4})\\d{8}$")
                                                    || Regex.IsMatch(uip, "^3[a-fA-F0-9]{6}((0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])\\d{4})\\d{17}$");

    //Уникальный идентификатор начисления
    public static bool FkValidateSupplierBillId(string supplierBillId)
    {
        //Набор весов
        List<int> weights = new();
        //Контрольный разряд
        var checkDigit = 0;

        //Заполнение весов
        for (var i = 1; i <= supplierBillId.Length - 1; i++)
        {
            weights.Add(i % 10 != 0 ? i % 10 : 10);
        }

        //Вычисление контрольного разряда
        for (var i = 0; i < 2; i++)
        {
            var sum = 0;
            for (var j = 0; j < supplierBillId.Length - 1; j++)
            {
                sum += int.Parse(supplierBillId[j].ToString()) * weights[j];
            }

            if (sum % 11 != 10)
            {
                checkDigit = sum % 11;
                break;
            }

            //Сдвиг весов
            for (var j = 0; j < weights.Count; j++)
                if (weights[j] < 9)
                {
                    weights[j] += 2;
                }
                else
                {
                    weights[j] -= 8;
                }
        }
        return int.Parse(supplierBillId.Last().ToString()) == checkDigit;
    }

    public static bool ValidateSvedRozhSeries(string series)
    {
        List<char> rm = new() { 'X', 'I', 'V', 'L', 'M', 'C' };
        var split = series.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        if (split.Count != 2) return false;
        if (split[0].Length > 5 || !split[0].All(rm.Contains)) return false;
        if (split[1].Length > 2 || !split[1].All(c => c is >= 'А' and <= 'Я')) return false;
        return true;
    }

    public static void TrimString(ref string item)
    {
        item = item.Replace("  ", " ").Trim();
    }

    public static string StripChars(string item, params char[] chars)
    {
        if (IsValidName(item)) return null;
          
        chars.ToList().ForEach(c =>
        {
            while (item.Contains(c))
            {
                item = item.Replace(c.ToString(CultureInfo.InvariantCulture), string.Empty);
            }
        });
            
        return item;
    }

    public static bool ValidateInnControlNumber(string inn)
    {
        try
        {
            if (inn.Length != 10 && inn.Length != 12 || !inn.All(c => c is >= '0' and <= '9')) return false;

            // проверка по контрольным цифрам
            if (inn.Length == 10) // для юридического лица
            {

                var dgt10 = (
                    2 * int.Parse(inn[..1])
                    + 4 * int.Parse(inn.Substring(1, 1))
                    + 10 * int.Parse(inn.Substring(2, 1))
                    + 3 * int.Parse(inn.Substring(3, 1))
                    + 5 * int.Parse(inn.Substring(4, 1))
                    + 9 * int.Parse(inn.Substring(5, 1))
                    + 4 * int.Parse(inn.Substring(6, 1))
                    + 6 * int.Parse(inn.Substring(7, 1))
                    + 8 * int.Parse(inn.Substring(8, 1))) % 11 % 10;

                return int.Parse(inn.Substring(9, 1)) == dgt10;
            }
            // ReSharper disable once RedundantIfElseBlock
            else // для физического лица
            {
                var dgt11 = (
                    7 * int.Parse(inn[..1])
                    + 2 * int.Parse(inn.Substring(1, 1))
                    + 4 * int.Parse(inn.Substring(2, 1))
                    + 10 * int.Parse(inn.Substring(3, 1))
                    + 3 * int.Parse(inn.Substring(4, 1))
                    + 5 * int.Parse(inn.Substring(5, 1))
                    + 9 * int.Parse(inn.Substring(6, 1))
                    + 4 * int.Parse(inn.Substring(7, 1))
                    + 6 * int.Parse(inn.Substring(8, 1))
                    + 8 * int.Parse(inn.Substring(9, 1))) % 11 % 10;
                var  dgt12 = (
                    3 * int.Parse(inn[..1])
                    + 7 * int.Parse(inn.Substring(1, 1))
                    + 2 * int.Parse(inn.Substring(2, 1))
                    + 4 * int.Parse(inn.Substring(3, 1))
                    + 10 * int.Parse(inn.Substring(4, 1))
                    + 3 * int.Parse(inn.Substring(5, 1))
                    + 5 * int.Parse(inn.Substring(6, 1))
                    + 9 * int.Parse(inn.Substring(7, 1))
                    + 4 * int.Parse(inn.Substring(8, 1))
                    + 6 * int.Parse(inn.Substring(9, 1))
                    + 8 * int.Parse(inn.Substring(10, 1))) % 11 % 10;
                      
                return int.Parse(inn.Substring(10, 1)) == dgt11
                       && int.Parse(inn.Substring(11, 1)) == dgt12;
            }
        }
        catch
        {
            return false;
        }
    }

    public static bool ValidateOgrnControlNumber(string ogrn)
    {
        if (ogrn.Length != 13 && ogrn.Length != 15||!long.TryParse(ogrn, out var number)) return false;

        // проверка по контрольным цифрам
        if (ogrn.Length == 13) // для юридического лица
        {
            // остаток от деления
            var num12 = (int)Math.Floor((double)number / 10 % 11);
            // если остаток равен 10, то берём 0, если нет, то берём его самого
            var dgt13 = num12 == 10 ? 0 : num12;
            // ну и теперь сравниваем с контрольной цифрой
            return int.Parse(ogrn.Substring(12, 1)) == dgt13;
        }
        // ReSharper disable once RedundantIfElseBlock
        else // для индивидуального предпринимателя
        {
            // остаток от деления
            var num14 = (int)Math.Floor((double)number / 10 % 13);
            var dgt15 = num14 % 10;
            // ну и теперь сравниваем с контрольной цифрой
            return int.Parse(ogrn.Substring(14, 1)) == dgt15;
        }
    }

    public static bool ValidateSnilsControlNumber(string snils)
    {
        if (snils == string.Empty) return false;

        snils = FilterDigits(snils);
        var sum = 0;
        for (var i = 0; i < 9; i++)
        {
            sum += int.Parse(snils[i].ToString()) * (9 - i);
        }
        var controlNum = int.Parse(snils.Substring(9, 2));
            
        return sum % 101 % 100 == controlNum;
    }

    public static string ReformatSnils(string snilsDigits)
    {
        if (IsValidName(snilsDigits)) return null;
        snilsDigits = FilterDigits(snilsDigits);
        return !Check11Digits(snilsDigits) ? snilsDigits : $"{snilsDigits[..3]}-{snilsDigits.Substring(3, 3)}-{snilsDigits.Substring(6, 3)} {snilsDigits.Substring(9, 2)}";
    }

    public static string FilterCyrilic(string input, int lengthLimit = 0, bool trim = true)
    {
        if (IsValidName(input)) return null;
        string result = new(input.Where(c => c is >= 'а' and <= 'я' or >= 'А' and <= 'Я' or '-' or ' ' or 'ё' or 'Ё').ToArray());
        if (lengthLimit != 0)
        {
            result = result[..Math.Min(result.Length, lengthLimit)];
        }

        if (trim)
        {
            result = result.Trim();
        }

        return result;
    }

    public static string FilterNcName(string input)
    {
        var result = string.Empty;
        var i = 0;
        input.ToCharArray().ToList().ForEach(c =>
        {
            // ReSharper disable once ArrangeRedundantParentheses
            if (c is >= 'a' and <= 'z' or >= 'A' and <= 'Z' or '_')
            {
                result += c;
                i++;
                return;
            }
            // ReSharper disable once ArrangeRedundantParentheses
            if (i != 0 && (c is >= '0' and <= '9' or '.' or '-'))
            {
                result += c;
                i++;
                return;
            }
            result += '_';
            i++;
        });
        return result;
    }
}