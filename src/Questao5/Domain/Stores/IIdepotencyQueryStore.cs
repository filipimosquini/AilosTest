﻿using Questao5.Domain.Entities;
using System.Threading.Tasks;
using System;

namespace Questao5.Domain.Stores;

public interface IIdepotencyQueryStore
{
    Task<Idepotency> GetIdepotencyAsync(Guid idepotencyToken);
}