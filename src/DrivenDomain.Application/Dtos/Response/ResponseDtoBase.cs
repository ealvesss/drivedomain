

using FluentValidation.Results;

namespace DrivenDomain.Application.Dtos.Response
{
    public class ResponseDto<T> where T : class
    {
        public List<T> Data { get; private set; } = new List<T>();
        public bool IsSuccess { get; private set; }
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public int Total { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = new ValidationResult();

        public static ResponseDto<T> Success(List<T> data, int? page, int? pageSize, int? total)
        {
            return new ResponseDto<T> { IsSuccess = true, Data = data, Page = page ?? 0, PageSize = pageSize ?? 0, Total = total ?? 0 };
        }

        public static ResponseDto<T> Failure(ValidationResult validationResult)
        {
            return new ResponseDto<T> { IsSuccess = false, ValidationResult = validationResult };
        }
    }
}