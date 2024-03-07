using Application.DTOs;
using Application.ViewModel;

namespace Application.UseCases.Interfaces
{
    public interface ITagUseCase
    {
        IEnumerable<TagViewModel> GetAllTags();
        TagViewModel CreateTag(TagDto.CreateTag tag);
        Task<TagViewModel> UpdateTag(TagDto.UpdateTag tag);
        void RemoveTag(Guid id);
    }
}
