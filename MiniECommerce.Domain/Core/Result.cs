using System.Text.Json.Serialization;

namespace MiniECommerce.Domain.Core
{
    public class Result<T>
    {
        public List<string> Mesaj { get; set; }
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }


        //getir metotları, data döner
        public static Result<T> Success(string mesaj, T data)
        {
            return new Result<T> { StatusCode = 200, Mesaj = new List<string> { mesaj }, Data = data };
        }

        //başarılı işlem, sadece mesaj
        public static Result<T> Success(string mesaj)
        {
            return new Result<T> { StatusCode = 200, Mesaj = new List<string> { mesaj } };
        }

        //kaydet, genelde geri dönüş id'dir
        public static Result<T> Created(string mesaj, T data)
        {
            return new Result<T> { StatusCode = 201, Mesaj = new List<string> { mesaj }, Data = data };
        }

        //kaydet, geri dönüş olmayan
        public static Result<T> Created(string mesaj)
        {
            return new Result<T> { StatusCode = 201, Mesaj = new List<string> { mesaj } };
        }

        //kullanıcı hataları. Validasyonlar falan
        public static Result<T> BadRequest(string mesaj)
        {
            return new Result<T> { StatusCode = 400, Mesaj = new List<string> { mesaj } };
        }

        //kullanıcı hataları. Validasyonlar falan
        public static Result<T> BadRequest(List<string> mesaj)
        {
            return new Result<T> { StatusCode = 400, Mesaj = mesaj };
        }

        //Loginsiz giriş denemesi
        public static Result<T> Unauthorized(string mesaj)
        {
            return new Result<T> { StatusCode = 401, Mesaj = new List<string> { mesaj } };
        }

        //Yetkisiz işlem
        public static Result<T> Forbidden(string mesaj)
        {
            return new Result<T> { StatusCode = 403, Mesaj = new List<string> { mesaj } };
        }

        //Datanın bulunamama durumu
        public static Result<T> NotFound(string mesaj)
        {
            return new Result<T> { StatusCode = 404, Mesaj = new List<string> { mesaj } };
        }

        //Sistemsel hatalar için
        public static Result<T> Error(string mesaj)
        {
            return new Result<T> { StatusCode = 500, Mesaj = new List<string> { mesaj } };
        }
    }

    public class NoContentDto { }
}
