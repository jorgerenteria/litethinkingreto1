using Application.Common.Utils;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.Files.Commands.CreateFile;

public class CreateFileCommand : CreateFileCommandModel, IRequest<Result<CreateFileCommandDto>>
{
    public class CreateFileCommandHandler(
        IConfiguration configuration) : UseCaseHandler, IRequestHandler<CreateFileCommand, Result<CreateFileCommandDto>>
    {
        public async Task<Result<CreateFileCommandDto>> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var cosmosDB = new CosmosDB(configuration);

            foreach (var transaction in request.Transactions)
            {
                var file = new FileEntity
                {
                    id = transaction.Id,
                    FileName = transaction.FileName,
                    TransactionName = transaction.TransactionName,
                };

                await cosmosDB.InsertDataOperation(file);
            }

            var resultData = new CreateFileCommandDto { Created = true };

            return Succeded(resultData);
        }
    }
}

