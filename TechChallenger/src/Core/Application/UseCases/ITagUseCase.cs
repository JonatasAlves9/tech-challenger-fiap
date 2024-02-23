using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.UseCases
{
    public interface ITagUseCase
    {
        IEnumerable<Tag> GetAllTags();
        void CreateTag(TagDto tag);
        void UpdateTag(Tag tag);
        void RemoveTag(Guid id);
    }
}
