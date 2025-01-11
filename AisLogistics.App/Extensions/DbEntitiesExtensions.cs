using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Entities.Models;
using Clave.Expressionify;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace AisLogistics.App.Extensions;


public static class EnumExtensions
{
    public static string? GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            ?.GetName();
    }
}

public static partial class Extensions
{
    //https://github.com/ALMMa/datatables.aspnet/issues/26
    public static IQueryable<T> OrderByColums<T>(this IQueryable<T> source, IEnumerable<DataTables.AspNet.Core.IColumn>? sortModels)
    {
        if (sortModels is null)
            return source;

        var expression = source.Expression;
        int count = 0;
        foreach (var item in sortModels)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            //reflection по item.Field, т.к. в camelcase возвращает
            string orderField = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase).Where(x => x.CanWrite)
                .FirstOrDefault(x => x.Name.Equals(item.Field, StringComparison.OrdinalIgnoreCase))?.Name ?? item.Field;

            var selector = Expression.PropertyOrField(parameter, orderField);
            var method = item.Sort.Direction == DataTables.AspNet.Core.SortDirection.Descending ?
                (count == 0 ? "OrderByDescending" : "ThenByDescending") :
                (count == 0 ? "OrderBy" : "ThenBy");
            expression = Expression.Call(typeof(Queryable), method,
                new Type[] { source.ElementType, selector.Type },
                expression, Expression.Quote(Expression.Lambda(selector, parameter)));
            count++;
        }
        return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;
    }

    /// <summary>
    ///  Текущий этап услуги
    /// </summary>
    /// <param name="dService"></param>
    /// <returns></returns>
    //[Expressionify]
    public static DServicesRoutesStage? DservicesStageCurrent(this DService dService) {
        try
        {
            var a = dService.DServicesRoutesStages.OrderByDescending(m => m.DateAdd).FirstOrDefault();
            return a;
        }
        catch(Exception e)
        {
            return null;
        }
        
    }
}

public static class DbEntitiesExtensions
{

    /// <summary>
    ///  Определение статуса СМЭВ запроса
    /// </summary>
    /// <param name="dServicesSmevRequest"></param>
    /// <returns></returns>
    public static int SmevStatus(this DServicesSmevRequest dServicesSmevRequest)
    {
        return dServicesSmevRequest.DateFact switch
        {
            null when dServicesSmevRequest.DateReg < DateTime.Now && dServicesSmevRequest.RequestHtml is not null =>
                (int)SmevStatusType.Expired,
            null when dServicesSmevRequest.DateReg >= DateTime.Now && dServicesSmevRequest.RequestHtml is not null =>
                (int)SmevStatusType.Sent,
            not null or null when dServicesSmevRequest.RequestHtml is null => (int)SmevStatusType.Error,
            not null => (int)SmevStatusType.ResponseSuccess,
            _ => (int)SmevStatusType.Error
        };
    }
    /// <summary>
    ///  Определение статуса СМЭВ запроса
    /// </summary>
    /// <param name="dServicesSmevRequest"></param>
    /// <returns></returns>
    public static int SmevStatus(this AServicesSmevRequest dServicesSmevRequest)
    {
        return dServicesSmevRequest.DateFact switch
        {
            null when dServicesSmevRequest.DateReg < DateTime.Now && dServicesSmevRequest.RequestHtml is not null =>
                (int)SmevStatusType.Expired,
            null when dServicesSmevRequest.DateReg >= DateTime.Now && dServicesSmevRequest.RequestHtml is not null =>
                (int)SmevStatusType.Sent,
            not null or null when dServicesSmevRequest.RequestHtml is null => (int)SmevStatusType.Error,
            not null => (int)SmevStatusType.ResponseSuccess,
            _ => (int)SmevStatusType.Error
        };
    }
    /// <summary>
    ///  Составления путя к форме СМЭВ запроса
    /// </summary>
    /// <param name="smevRequest"></param>
    /// <returns></returns>
    public static string SmevFormPath(this SSmevRequest smevRequest) => String.IsNullOrWhiteSpace(smevRequest.Path) ? "" : $"~/Views/SmevForm/{smevRequest.Path}.cshtml";
    /// <summary>
    /// ФИО заявителя
    /// </summary>
    /// <param name="dServicesCustomer"></param>
    /// <returns></returns>
    public static string Fio(this DServicesCustomer dServicesCustomer) => $"{dServicesCustomer?.LastName} {dServicesCustomer?.FirstName} {dServicesCustomer?.SecondName}";
    public static string Fio(this DServicesCustomersLegal dServicesCustomer) => $"{dServicesCustomer?.HeadLastName} {dServicesCustomer?.HeadFirstName} {dServicesCustomer?.HeadSecondName}";
    public static string Fio(this AServicesCustomer aServicesCustomer) => $"{aServicesCustomer.LastName} {aServicesCustomer.FirstName} {aServicesCustomer.SecondName}";
    public static string Fio(this AServicesCustomersLegal aServicesCustomer) => $"{aServicesCustomer?.HeadLastName} {aServicesCustomer?.HeadFirstName} {aServicesCustomer?.HeadSecondName}";

    public static DateOnly DateOnlyToDay(this DateTime date) => DateOnly.FromDateTime(date);
}