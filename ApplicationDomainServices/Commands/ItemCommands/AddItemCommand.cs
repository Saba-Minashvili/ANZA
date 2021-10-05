using ApplicationDomainModels.Enums;
using MediatR;

namespace ApplicationDomainServices.Commands.ProductCommands
{
    public class AddItemCommand : IRequest<bool>
    {
        public string ItemPhoto { get; set; }
        public ItemType Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public DesignedFor DesignedFor { get; set; }
        public double Price { get; set; }
    }
}
