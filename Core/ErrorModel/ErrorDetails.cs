using System.Text.Json;

namespace Core.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        //Ve Tostring metodunu override edeceğiz.yukarıdaki 2 ifadeyi serilize edeceğiz.
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);//this ifadesi classın tamamını kapsar.
        }
    }
}
