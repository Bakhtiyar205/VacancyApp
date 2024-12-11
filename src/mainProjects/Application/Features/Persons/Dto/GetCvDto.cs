using Core.Domain.Dtos;

namespace Application.Features.Persons.Dto;
public class GetCvDto(byte[] fileByte, string fileName, string fileType)
{
    public byte[] FileByte { get; set; } = fileByte;
    public string FilePath { get; set; } = fileName;
    public string FileType { get; set; } = fileType;
}
