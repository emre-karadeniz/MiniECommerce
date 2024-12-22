using System.Text.Json.Serialization;

namespace MiniECommerce.Domain.Core
{
    public class Result<T>
    {
        public List<string> Message { get; set; }
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }


        //getir metotları, data döner
        public static Result<T> Success(string message, T data)
        {
            return new Result<T> { StatusCode = 200, Message = new List<string> { message }, Data = data };
        }

        //başarılı işlem, sadece mesaj
        public static Result<T> Success(string message)
        {
            return new Result<T> { StatusCode = 200, Message = new List<string> { message } };
        }

        //kaydet, genelde geri dönüş id'dir
        public static Result<T> Created(string message, T data)
        {
            return new Result<T> { StatusCode = 201, Message = new List<string> { message }, Data = data };
        }

        //kaydet, geri dönüş olmayan
        public static Result<T> Created(string message)
        {
            return new Result<T> { StatusCode = 201, Message = new List<string> { message } };
        }

        //kullanıcı hataları. Validasyonlar falan
        public static Result<T> BadRequest(string message)
        {
            return new Result<T> { StatusCode = 400, Message = new List<string> { message } };
        }

        //kullanıcı hataları. Validasyonlar falan
        public static Result<T> BadRequest(List<string> message)
        {
            return new Result<T> { StatusCode = 400, Message = message };
        }

        //Loginsiz giriş denemesi
        public static Result<T> Unauthorized(string message)
        {
            return new Result<T> { StatusCode = 401, Message = new List<string> { message } };
        }

        //Yetkisiz işlem
        public static Result<T> Forbidden(string message)
        {
            return new Result<T> { StatusCode = 403, Message = new List<string> { message } };
        }

        //Datanın bulunamama durumu
        public static Result<T> NotFound(string message)
        {
            return new Result<T> { StatusCode = 404, Message = new List<string> { message } };
        }

        //Sistemsel hatalar için
        public static Result<T> Error(string message)
        {
            return new Result<T> { StatusCode = 500, Message = new List<string> { message } };
        }
    }

    public class NoContentDto { }
}
