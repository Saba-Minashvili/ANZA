using MediatR;

namespace ApplicationDomainServices.Commands
{
    public class AddMaterialTypesCommand : IRequest<bool>
    {
        public int ItemTypeId { get; set; }
        public string MaterialTypeName { get; set; }
    }
}
