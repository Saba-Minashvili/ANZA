using MediatR;

namespace ApplicationDomainServices.Queries.PhotoQueiries
{
    public class ReadItemPhotoQuery : IRequest<string>
    {
        public int ItemId { get; set; }
    }
}
