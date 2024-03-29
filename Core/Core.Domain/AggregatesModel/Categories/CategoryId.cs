﻿using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Categories;

public record CategoryId : EntityIdBase
{
    public CategoryId() { }
    public CategoryId(string id) : base(id) { }
}