using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Commands.ProductCommands;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.ProductHandlers
{
    public class UploadItemPhotoCommandHandler : IRequestHandler<ItemPictureCommand, bool>
    {
        private readonly IRepository<Item> _itemRepo = default;
        private readonly Cloudinary _cloud = new Cloudinary(new CloudinaryDotNet.Account("dkfjpuddb", "859347338356413", "A6IiVVsDyaMmpRaDD0aBJdV0xfA"));
        private readonly string _cloudinaryBaseImageUrl = "https://res.cloudinary.com/dkfjpuddb/image/upload/";

        public UploadItemPhotoCommandHandler(IRepository<Item> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public async Task<bool> Handle(ItemPictureCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepo.GetByIdAsync(request.ItemId);
            try
            {
                var imageLocation = Path.GetFileName(request.FileName);
                var imageUpload = new ImageUploadParams()
                {
                    File = new FileDescription(imageLocation),
                    PublicId = imageLocation.Split('\\').LastOrDefault().Split('.').FirstOrDefault()
                };

                var cloudinaryFullImageUrl = $"{_cloudinaryBaseImageUrl}{imageLocation.Split('\\').LastOrDefault()}";
                _cloud.Upload(imageUpload);

                item.ItemPhoto = cloudinaryFullImageUrl;
                return await _itemRepo.UpdateAsync(request.ItemId, item);
            }
            catch
            {
                return false;
            }
        }
    }
}
