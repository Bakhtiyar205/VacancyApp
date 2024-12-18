﻿using Core.Domain.Dtos;

namespace Application.Features.Questions.Dto;
public class GetQuestionDto : BaseDto
{
    public string? QuestionDetail { get; set; }
    public int VacancyId { get; set; }
    public string? VacancyName { get; set; }
    public int OptionCount { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
