namespace pokemon.Models.dto
{
    public class SuccessDto<T>
    {

        public bool Success { get;  } = true;
        public T Data { get; set; }

    }
}
