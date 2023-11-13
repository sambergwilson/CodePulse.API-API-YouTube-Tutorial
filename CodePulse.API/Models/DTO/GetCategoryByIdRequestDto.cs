namespace CodePulse.API.Models.DTO
{
    public class GetCategoryByIdRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}
