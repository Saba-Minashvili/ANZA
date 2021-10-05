using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainServices.Commands;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.AccountHandlers
{
    public class UploadAccountPhotoCommandHandler : IRequestHandler<AccountPhotoCommand, bool>
    {
        private readonly IRepository<ApplicationDomainModels.Models.Account> _accountRepo = default;
        private readonly Cloudinary _cloud = new Cloudinary(new CloudinaryDotNet.Account("dkfjpuddb", "859347338356413", "A6IiVVsDyaMmpRaDD0aBJdV0xfA"));
        private readonly string _cloudinaryBaseImageUrl = "https://res.cloudinary.com/dkfjpuddb/image/upload/";

        public UploadAccountPhotoCommandHandler(IRepository<ApplicationDomainModels.Models.Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public async Task<bool> Handle(AccountPhotoCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepo.GetByIdAsync(request.AccountId);
            try
            {
                var imageLocation = request.FileName;
                var imageUpload = new ImageUploadParams()
                {
                    File = new FileDescription(imageLocation),
                    PublicId = imageLocation.Split('\\').LastOrDefault().Split('.').FirstOrDefault()
                };

                var cloudinaryFullImageUrl = $"{_cloudinaryBaseImageUrl}{imageLocation.Split('\\').LastOrDefault()}";

                account.AccountPhoto = cloudinaryFullImageUrl;
                _cloud.Upload(imageUpload);
                return await _accountRepo.UpdateAsync(request.AccountId, account);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
