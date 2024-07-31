﻿using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.SeriesPurchase.Add
{
    public sealed class AddSeriesPurchaseCommand : ICommand
    {

        public AddSeriesPurchaseCommand(int seriesId, int userId, DateTime purchaseDate)
        {
            SeriesId = seriesId;
            UserId = userId;
            PurchaseDate = purchaseDate;
        }

        public int SeriesId { get; }
        public int UserId { get;}
        public DateTime PurchaseDate { get; }
    }
}
