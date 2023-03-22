namespace PTH.services.DTO_s
{
    public class ResponseDto<T>
    {
        public ResponseDto()
        {
            error = "no Exception Error";
            message = "I'm Still Alive...";//portal refrences :)
            existError = false;
            results = null;
            result = default(T);
        }
        public string message { get; set; }
        public string error { get; set; }
        public bool existError { get; set; }
        public IEnumerable<T>? results { get; set; }
        public T? result { get; set; }

    }
}
