using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class TagUseCase : ITagUseCase
{
    private readonly ITagRepository _tagRepository;

    public TagUseCase(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public IEnumerable<Tag> GetAllTags()
    {
        return _tagRepository.GetAll();
    }
    
    public void CreateTag(TagDto tag)
    {
        var model = Tag.Create(tag.Name, tag.ImageUrl);
        
        _tagRepository.Add(model);
    }
    
    public void UpdateTag(Tag tag)
    {
        _tagRepository.Update(tag);
    }
    
    public void RemoveTag(Guid id)
    {
        var tag = _tagRepository.GetByIdAsync(id).Result;
        _tagRepository.Remove(tag);
    }
}