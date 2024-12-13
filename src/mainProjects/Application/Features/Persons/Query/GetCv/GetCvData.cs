using Application.Features.Persons.Dto;
using Application.Services.PersonServices;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Application.Features.Persons.Query.GetCv;
public class GetCvData(int id) : IRequest<GetCvDto>
{
    public int Id { get; set; } = id;
}

public class GetCvDataHandler(IPersonService personService, IMapper mapper) : IRequestHandler<GetCvData, GetCvDto>
{

    public async Task<GetCvDto> Handle(GetCvData request, CancellationToken cancellationToken)
    {
        //TODO: Refactor this code
        var person = await personService.GetAsync(request.Id, cancellationToken);

        if (person.CvPath == null) throw new BusinessException("Person does not have Cv");

        var dataPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\cvs", person.CvPath);

        return GetCv(request, dataPath);
    }

    private GetCvDto GetCv(GetCvData request, string dataPath)
    {
        var fileBytes = File.ReadAllBytes(dataPath);

        var fileExtension = Path.GetExtension(dataPath).ToLower();

        string contentType = fileExtension switch
        {
            ".pdf" => "application/pdf",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            _ => throw new BusinessException("File is not found")
        };

        return new GetCvDto(fileBytes, dataPath, contentType);
    }
}
