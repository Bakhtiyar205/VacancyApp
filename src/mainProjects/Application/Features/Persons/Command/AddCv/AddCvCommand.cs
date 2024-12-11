using Application.Services.PersonServices;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Persons.Command.AddCv;
public class AddCvCommand : IRequest<Unit>
{
    public AddCvCommand(int personId, IFormFile file)
    {
        PersonId = personId;
        File = file;
    }
    public int PersonId { get; }
    public IFormFile File { get; }
}

public class AddCvCommandHandler(IPersonService personService, IConfiguration configuration, IMapper mapper) : IRequestHandler<AddCvCommand, Unit>
{
    public async Task<Unit> Handle(AddCvCommand request, CancellationToken cancellationToken)
    {
        //TODO: Refactor this code
        var person = await personService.GetAsync(request.PersonId, cancellationToken);

        if (!configuration.GetSection("IFormFileContents").Get<string[]>()!.Contains(request.File.ContentType))
            throw new BusinessException("Only Word and Pdf are acceptable");

        if(request.File.Length > Math.Pow(1024,2) * configuration.GetSection("IFormFileLengthLimit").Get<int>())
            throw new BusinessException($"File size must be less than {configuration.GetSection("IFormFileLengthLimit")} MB");

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\cvs", request.File.FileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await request.File.CopyToAsync(fileStream);
        }

        person.CvPath = request.File.FileName;
        await personService.UpdateAsync(person, cancellationToken);

        return Unit.Value;
    }
}
