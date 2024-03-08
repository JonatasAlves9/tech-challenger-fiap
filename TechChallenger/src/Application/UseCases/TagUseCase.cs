using Application.ViewModel;
﻿using Application.DTOs;
using Application.UseCases.Interfaces;
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

    public IEnumerable<TagViewModel> GetAllTags()
    {
        var tags = _tagRepository.GetAll(); 
        return TagViewModel.ToResultList(tags);
    }
    
    public TagViewModel CreateTag(TagDto.CreateTag tag)
    {
        var newTag = Tag.Create();

        newTag
            .SetName(tag.Name)
            .SetImageUrl(tag.ImageUrl);
        
        _tagRepository.Add(newTag);

        return TagViewModel.ToResult(newTag);
    }
    
    public async Task<TagViewModel> UpdateTag(TagDto.UpdateTag tag)
    {
        var existingTag = await _tagRepository.GetByIdAsync(tag.Id);

        if (existingTag == null)
        {
            throw new InvalidOperationException("Tag not found with the ID provided.");
        }

        existingTag
            .SetName(tag.Name)
            .SetImageUrl(tag.ImageUrl);

        _tagRepository.Update(existingTag);

        return TagViewModel.ToResult(existingTag);
    }
    
    public void RemoveTag(Guid id)
    {
        var tag = _tagRepository.GetByIdAsync(id).Result;
        _tagRepository.Remove(tag);
    }
}