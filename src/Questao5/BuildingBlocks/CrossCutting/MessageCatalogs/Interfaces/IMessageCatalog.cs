using Questao5.BuildingBlocks.CrossCutting.MessageCatalogs.Models;
using System.Collections.Generic;

namespace Questao5.BuildingBlocks.CrossCutting.MessageCatalogs.Interfaces;

public interface IMessageCatalog
{
    IEnumerable<Notification> Get(string key);
}