using Questao5.Infrastructure.CrossCutting.MessageCatalogs.Models;
using System.Collections.Generic;

namespace Questao5.Infrastructure.CrossCutting.MessageCatalogs.Interfaces;

public interface IMessageCatalog
{
    IEnumerable<Notification> Get(string key);
}