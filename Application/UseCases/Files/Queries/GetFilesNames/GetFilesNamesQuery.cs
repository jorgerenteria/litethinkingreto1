using Application.Common.Utils;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Application.UseCases.Files.Queries.GetFilesNames;
using MediatR;
using Microsoft.Extensions.Configuration;
namespace Application.UseCases.Transactions.Queries.GetTransactions;

public class GetFilesNamesQuery : IRequest<Result<GetFilesNamesQueryDto>>
{
    public class GetFilesNamesQueryHandler(
        IConfiguration configuration) : UseCaseHandler, IRequestHandler<GetFilesNamesQuery, Result<GetFilesNamesQueryDto>>
    {
        public async Task<Result<GetFilesNamesQueryDto>> Handle(GetFilesNamesQuery request, CancellationToken cancellationToken)
        {
            var blobStorage = new BlobStorageService(configuration);
            var resultData = new GetFilesNamesQueryDto
            {
                FilesName = await blobStorage.GetNameList()
            };

            return this.Succeded(resultData);
        }
    }
}
