using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Interfaces;

public class GetRecordsByUserIdHandler: IRequestHandler<GetRecordsByUserIdQuery, IEnumerable<RecordInfoDto>>
{
    private readonly IRecordRepository _recordRepository;
    private readonly IMapper _mapper;
    public GetRecordsByUserIdHandler(IRecordRepository recordRepository, IMapper mapper)
    {
        _recordRepository = recordRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RecordInfoDto>> Handle(GetRecordsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var records = await _recordRepository.GetRecordsByUserId(userId);
        return records.Select(_mapper.Map<RecordInfoDto>);
    }
}