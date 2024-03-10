using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.ViewModel;

namespace Application.UseCases
{
    public interface ITagUseCase
    {
        IEnumerable<TagViewModel> GetAllTags();
        TagViewModel CreateTag(TagDto.CreateTag tag);
        Task<TagViewModel> UpdateTag(TagDto.UpdateTag tag);
        void RemoveTag(Guid id);
    }
}
