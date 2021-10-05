using MediatR;

namespace ApplicationDomainServices.Queries.PhotoQueiries
{
    public class ReadAccountPhotoQuery : IRequest<string>
    {
        public int AccountId { get; set; }
    }
}
