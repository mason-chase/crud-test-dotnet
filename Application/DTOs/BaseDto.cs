namespace Application.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }

        public BaseDto(int id)
        {
                Id= id;
        }
        public BaseDto()
        {
        }
    }
}
