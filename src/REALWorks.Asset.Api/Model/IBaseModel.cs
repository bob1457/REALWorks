using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Model
{
    public interface IBaseModel
    {
        ObjectId Id { get; set; }
    }
}
